using RezerwacjaKino.Models;
using RezerwacjaKino.Repositories;
using Microsoft.Data.Sqlite;
using RezerwacjaKino.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezerwacjaKino.Services
{
    public class RezerwacjaService
    {
        private readonly BiletRepository biletRepo = new();

        //Pobiera zajęte miejsca z repozytorium bilet
        public HashSet<Seat> PobierzZajeteMiejsca(long idSeans) => biletRepo.GetZajeteMiejsca(idSeans);

        public (bool ok, bool wymaganeOdswiezenie, string wiadomosc) Zarezerwuj(long idSeans, Klient klient, List<Seat> wybrane, string typBiletu, decimal cenaJednostkowa)
        {
            if (wybrane.Count == 0)
                return (false, false, "Wybierz przynajmniej jedno miejsce.");
            //Walidacja danych klienta
            try
            {
                klient.Imie = WalidacjaDanych.SprawdzTekst(klient.Imie, "Imię");
                klient.Nazwisko = WalidacjaDanych.SprawdzTekst(klient.Nazwisko, "Nazwisko");

                klient.Email = WalidacjaDanych.NormalizujEmail(klient.Email);
                klient.Telefon = WalidacjaDanych.NormalizujTelefon(klient.Telefon);

                WalidacjaDanych.SprawdzKontakt(klient.Email, klient.Telefon);
            }
            catch (ArgumentException ex)
            {
                return (false, false, ex.Message);
            }


            using var conn = Db.OpenConnection();
            using var tx = conn.BeginTransaction();
            //Dodanie klienta do tabeli Klient
            try
            {
                //Klient
                long idKlient;
                {
                    using var cmd = conn.CreateCommand();
                    cmd.Transaction = tx;
                    cmd.CommandText = @"
                    INSERT INTO Klient (imie, nazwisko, email, telefon)
                    VALUES ($imie, $nazw, $email, $tel);
                    SELECT last_insert_rowid();";

                    cmd.Parameters.AddWithValue("$imie", klient.Imie);
                    cmd.Parameters.AddWithValue("$nazw", klient.Nazwisko);
                    cmd.Parameters.AddWithValue("$email", (object?)klient.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("$tel", (object?)klient.Telefon ?? DBNull.Value);
                    idKlient = (long)cmd.ExecuteScalar()!;
                }
                //Tworzenie listy biletow
                var bilety = wybrane.Select(s => new Bilet
                {
                    FkIdSeans = idSeans,
                    FkIdKlient = idKlient,
                    Rzad = s.Rzad,
                    Numer = s.Numer,
                    TypBiletu = typBiletu,
                    Cena = cenaJednostkowa
                }).ToList();
                //Zapis biletów
                biletRepo.DodajIlosc(conn, tx, bilety);

                tx.Commit();
                return (true, false, $"Zapisano rezerwację: {wybrane.Count} miejsc.");
            }
            catch (SqliteException ex) when (ex.SqliteErrorCode == 19)
            {
                tx.Rollback();
                return (false, true, "Ktoś zajął jedno z miejsc przed Tobą. Odświeżam mape");
            }
            catch (Exception ex)
            {
                tx.Rollback();
                return (false, false, $"Błąd zapisu: {ex.Message}");
            }
        }
        public (bool ok, string wiadomosc) AnulujRezerwacje(int idBiletu, string emailPhone)
        {
            //Walidacja danych
            try
            {
                if (string.IsNullOrWhiteSpace(emailPhone))
                    return (false, "Podaj email lub telefon do wyszukiwania rezerwacji.");

                string? email = null;
                string? telefon = null;

                if (emailPhone.Contains("@"))
                    email = WalidacjaDanych.NormalizujEmail(emailPhone);
                else
                    telefon = WalidacjaDanych.NormalizujTelefon(emailPhone);

                WalidacjaDanych.SprawdzKontakt(email, telefon);

                string klucz = email ?? telefon ?? "";
                //Wywloanie metody w repozytorium bilet w celu anulacji
                var zmiana = biletRepo.AnulujBilet(idBiletu, klucz);
                if (zmiana == 0)
                    return (false, "Nie znaleziono aktywnej rezerwacji dla podanych danych.");
                return (true, $"Anulowano {zmiana} bilet.");
            }
            catch (ArgumentException ex)
            {
                return (false, ex.Message);
            }
        }
        //Dane do tabeli z rezerwacjami
        public class RezerwacjaRow
        {
            public int IdBilet { get; set; }
            public string FilmTytul { get; set; } = "";
            public string StartOd { get; set; } = "";
            public string SalaNazwa { get; set; } = "";

            public string MiejscaText { get; set; } = "";
            public decimal Kwota { get; set; }

            public string KwotaText => $"{Kwota:0.00} zł";
        }

        public List<RezerwacjaRow> SzukajRezerwacji(string? email, string? telefon)
        {
            //Walidacja, normalizacja
            try
            {
                email = WalidacjaDanych.NormalizujEmail(email);
                telefon = WalidacjaDanych.NormalizujTelefon(telefon);
                WalidacjaDanych.SprawdzKontakt(email, telefon);
            }
            catch (ArgumentException)
            {
                return new List<RezerwacjaRow>();
            }

            var list = new List<RezerwacjaRow>();
            using var conn = Db.OpenConnection();
            //Wyszukiwanie rezerwacji
            string sql = @"
            SELECT
                b.id_bilet AS IdBilet,
                f.tytul    AS FilmTytul,
                s.start_at AS StartOd,
                sa.nazwa   AS SalaNazwa,
                (b.rzad || '-' || b.numer) AS Miejsce,
                b.cena     AS Cena
            FROM Bilet b
            JOIN Klient k ON k.id_klient = b.fk_id_klient
            JOIN Seans s  ON s.id_seans  = b.fk_id_seans
            JOIN Film f   ON f.id_film   = s.fk_id_film
            JOIN Sala sa  ON sa.id_sala  = s.fk_id_sala
            WHERE b.status = 'Aktywny'
              AND (
                    (@email IS NOT NULL AND k.email = @email)
                    OR
                    (@telefon IS NOT NULL AND k.telefon = @telefon)
                  )
            ORDER BY b.created_at DESC;";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@email", (object?)email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@telefon", (object?)telefon ?? DBNull.Value);
            //Dodawanie do listy rezerwacji
            using var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                list.Add(new RezerwacjaRow
                {
                    IdBilet = rd.GetInt32(0),
                    FilmTytul = rd.IsDBNull(1) ? "" : rd.GetString(1),
                    StartOd = rd.IsDBNull(2) ? "" : rd.GetString(2),
                    SalaNazwa = rd.IsDBNull(3) ? "" : rd.GetString(3),

                    MiejscaText = rd.IsDBNull(4) ? "" : rd.GetString(4),
                    Kwota = rd.IsDBNull(5) ? 0m : Convert.ToDecimal(rd.GetValue(5))
                });
            }
            return list;
        }
    }
}
