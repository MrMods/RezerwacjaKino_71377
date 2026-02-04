using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezerwacjaKino.Data
{
    internal class Db
    {
       public static SqliteConnection OpenConnection()
        {
            var conn = new SqliteConnection("Data Source=cinema.db");
            conn.Open();

            using var pragma = conn.CreateCommand();
            pragma.CommandText = "PRAGMA foreign_keys = ON;";
            pragma.ExecuteNonQuery();

            return conn;
        }

        public static void EnsureCreated()
        {
            using var conn = OpenConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
            PRAGMA foreign_keys = ON;

            CREATE TABLE IF NOT EXISTS Film (
              id_film        INTEGER PRIMARY KEY AUTOINCREMENT,
              tytul          TEXT NOT NULL,
              opis           TEXT,
              czas_min       INTEGER NOT NULL,
              poster_path    TEXT,
              omdb_id        TEXT
            );

            CREATE TABLE IF NOT EXISTS Sala (
              id_sala        INTEGER PRIMARY KEY AUTOINCREMENT,
              nazwa          TEXT NOT NULL,
              liczba_rzedow  INTEGER NOT NULL,
              miejsca_w_rzedzie INTEGER NOT NULL
            );

            CREATE TABLE IF NOT EXISTS Seans (
              id_seans       INTEGER PRIMARY KEY AUTOINCREMENT,
              fk_id_film     INTEGER NOT NULL,
              fk_id_sala     INTEGER NOT NULL,
              start_at       TEXT NOT NULL,
              cena_podstawowa REAL NOT NULL DEFAULT 25.0,
              ograniczenia   TEXT,
              FOREIGN KEY (fk_id_film) REFERENCES Film(id_film) ON DELETE RESTRICT,
              FOREIGN KEY (fk_id_sala) REFERENCES Sala(id_sala) ON DELETE RESTRICT
            );

            CREATE TABLE IF NOT EXISTS Klient (
              id_klient      INTEGER PRIMARY KEY AUTOINCREMENT,
              imie           TEXT NOT NULL,
              nazwisko       TEXT NOT NULL,
              email          TEXT,
              telefon        TEXT
            );

            CREATE TABLE IF NOT EXISTS Bilet (
              id_bilet       INTEGER PRIMARY KEY AUTOINCREMENT,
              fk_id_seans    INTEGER NOT NULL,
              fk_id_klient   INTEGER NOT NULL,
              rzad           INTEGER NOT NULL,
              numer          INTEGER NOT NULL,
              typ_biletu     TEXT NOT NULL,
              cena           REAL NOT NULL,
              status         TEXT NOT NULL DEFAULT 'Aktywny',
              created_at     TEXT NOT NULL DEFAULT (datetime('now')),
              FOREIGN KEY (fk_id_seans) REFERENCES Seans(id_seans) ON DELETE CASCADE,
              FOREIGN KEY (fk_id_klient) REFERENCES Klient(id_klient) ON DELETE CASCADE,
              UNIQUE (fk_id_seans, rzad, numer)
            );

            CREATE INDEX IF NOT EXISTS idx_bilet_seans ON Bilet(fk_id_seans);
            CREATE INDEX IF NOT EXISTS idx_bilet_klient ON Bilet(fk_id_klient);
";
            cmd.ExecuteNonQuery();
            SeedIfEmpty(conn);
        }

        private static void SeedIfEmpty(SqliteConnection conn)
        {
            long filmCount;
            using (var c = conn.CreateCommand())
            {
                c.CommandText = "select count(*) from Film;";
                filmCount = (long)c.ExecuteScalar()!;
            }
            if (filmCount > 0) return;

            using var tx = conn.BeginTransaction();
            using (var cmd = conn.CreateCommand()) 
            { 
                cmd.Transaction = tx;
                cmd.CommandText = @"
                INSERT INTO Film (tytul, opis, czas_min, poster_path, omdb_id) VALUES
                ('Dune', 'Sci-fi', 155, 'Posters/DUNE.jpg', NULL),
                ('Incepcja', 'Thriller', 148, 'Posters/INCEPCJA.jpg', NULL);

                INSERT INTO Sala (nazwa, liczba_rzedow, miejsca_w_rzedzie) VALUES
                ('Sala 1', 6, 10),
                ('Sala 2', 8, 12);

                INSERT INTO Seans (fk_id_film, fk_id_sala, start_at, cena_podstawowa, ograniczenia) VALUES
                (1, 1, '2026-01-10 18:00', 25.0, '16+'),
                (1, 1, '2026-01-10 20:30', 27.0, '16+'),
                (2, 2, '2026-01-11 09:00', 26.0, '16+');";

                cmd.ExecuteNonQuery();
            }
            tx.Commit();

        }
    }
}
