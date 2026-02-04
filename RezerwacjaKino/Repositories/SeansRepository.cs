using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RezerwacjaKino.Data;
using RezerwacjaKino.Models;

namespace RezerwacjaKino.Repositories
{
    public class SeansRepository
    {
        //Pobieranie listy seansow
        public List<Seans> GetAllFilmSala()
        {
            using var conn= Db.OpenConnection();
            using var cmd= conn.CreateCommand();
            cmd.CommandText = @"
            SELECT 
              s.id_seans,
              s.fk_id_film,
              s.fk_id_sala,
              s.start_at,
              s.cena_podstawowa,
              s.ograniczenia,
              f.tytul,
              f.poster_path,
              sa.nazwa,
              sa.liczba_rzedow,
              sa.miejsca_w_rzedzie
            FROM Seans s
            JOIN Film f ON f.id_film = s.fk_id_film
            JOIN Sala sa ON sa.id_sala = s.fk_id_sala
            ORDER BY s.start_at;";

            using var r = cmd.ExecuteReader();
            var list = new List<Seans>();
            while (r.Read())
            {
                list.Add(new Seans
                {
                    IdSeans = r.GetInt64(0),
                    FkIdFilm = r.GetInt64(1),
                    FkIdSala = r.GetInt64(2),
                    StartOd = DateTime.Parse(r.GetString(3)),
                    CenaPodstawowa = r.GetDecimal(4),

                    Ograniczenia = r.IsDBNull(5) ? null : r.GetString(5),
                    FilmTytul = r.GetString(6),
                    PosterPath = r.IsDBNull(7) ? null : r.GetString(7),
                    SalaNazwa = r.GetString(8),
                    SalaRzedow = r.GetInt32(9),
                    SalaMiejsc = r.GetInt32(10)
                });
            }
            return list;

        }
    }
}
