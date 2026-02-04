using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RezerwacjaKino.Data;
using RezerwacjaKino.Models;
using Microsoft.Data.Sqlite;

namespace RezerwacjaKino.Repositories
{
    public class BiletRepository
    {
        //Zwraca zajete miejsca dla aktywnych biletow
        public HashSet<Seat> GetZajeteMiejsca(long idSeans)
        {
            using var conn = Db.OpenConnection();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
            SELECT rzad, numer
            FROM Bilet
            WHERE fk_id_seans = $id AND status = 'Aktywny';";

            cmd.Parameters.AddWithValue("$id", idSeans);

            using var r = cmd.ExecuteReader();
            var set = new HashSet<Seat>();
            while (r.Read())
            {
                var seat = new Seat(r.GetInt32(0), r.GetInt32(1));
                set.Add(seat);
            }
            return set;
        }
        //Zapis biletow w transakcji
        public void DodajIlosc(SqliteConnection conn, SqliteTransaction tx, IEnumerable<Bilet> bilety)
        {
            foreach(var b in bilety)
            {
                using var cmd = conn.CreateCommand();
                cmd.Transaction = tx;

                cmd.Parameters.AddWithValue("$seans", b.FkIdSeans);
                cmd.Parameters.AddWithValue("$klient", b.FkIdKlient);
                cmd.Parameters.AddWithValue("$rzad", b.Rzad);
                cmd.Parameters.AddWithValue("$nr", b.Numer);
                cmd.Parameters.AddWithValue("$typ", b.TypBiletu);
                cmd.Parameters.AddWithValue("$cena", (double)b.Cena);
                cmd.CommandText = @"
                UPDATE Bilet
                SET fk_id_klient = $klient,
                    typ_biletu = $typ,
                    cena = $cena,
                    status = 'Aktywny'
                WHERE fk_id_seans = $seans
                  AND rzad = $rzad
                  AND numer = $nr
                  AND status = 'Anulowany';";
                var zmiana = cmd.ExecuteNonQuery();

                if (zmiana == 0)
                {
                    cmd.CommandText = @"
                    INSERT INTO Bilet (fk_id_seans, fk_id_klient, rzad, numer, typ_biletu, cena, status)
                    VALUES ($seans, $klient, $rzad, $nr, $typ, $cena, 'Aktywny');";
                    cmd.ExecuteNonQuery();
                }
            }
        }
        //Ustawianie biletu na Anulowany po anulacji biletu
        public int AnulujBilet(int idBiletu, string emailPhone)
        {
            using var conn = Db.OpenConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
            UPDATE Bilet
            SET status = 'Anulowany'
            WHERE id_bilet = $bilet
              AND status = 'Aktywny'
              AND fk_id_klient IN (
                SELECT id_klient FROM Klient
                WHERE (email IS NOT NULL AND email = $key)
                   OR (telefon IS NOT NULL AND telefon = $key));";

            cmd.Parameters.AddWithValue("$bilet", idBiletu);
            cmd.Parameters.AddWithValue("$key", emailPhone);
            return cmd.ExecuteNonQuery();
        }
    }
}
