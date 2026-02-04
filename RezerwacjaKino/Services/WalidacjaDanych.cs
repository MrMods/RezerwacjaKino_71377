using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RezerwacjaKino.Services
{
    internal static class WalidacjaDanych
    {
        public static string SprawdzTekst(string wartosc, string nazwaPola, int maxDlugosc = 60)
        {
            wartosc = (wartosc ?? "").Trim();

            if (wartosc.Length == 0)
                throw new ArgumentException($"{nazwaPola} nie może być puste.");

            if (wartosc.Length > maxDlugosc)
                throw new ArgumentException($"{nazwaPola} jest za długie (max {maxDlugosc} znaków).");

            if (wartosc.Contains('<') || wartosc.Contains('>'))
                throw new ArgumentException($"{nazwaPola} zawiera niedozwolone znaki.");

            return wartosc;
        }

        public static string? NormalizujEmail(string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return null;

            email = email.Trim().ToLowerInvariant();

            if (email.Length > 254)
                throw new ArgumentException("Email jest za długi.");

            try
            {
                _ = new MailAddress(email); // walidacja formatu
            }
            catch (FormatException)
            {
                throw new ArgumentException("Niepoprawny format email.");
            }

            return email;
        }

        public static string? NormalizujTelefon(string? telefon)
        {
            if (string.IsNullOrWhiteSpace(telefon))
                return null;

            telefon = telefon.Trim();
            var wynik = new string(telefon.Where(c => char.IsDigit(c) || c == '+').ToArray());

            if (wynik.Length < 7)
                throw new ArgumentException("Numer telefonu jest za krótki.");

            if (wynik.Length > 15)
                throw new ArgumentException("Numer telefonu jest za długi.");

            return wynik;
        }
        public static void SprawdzKontakt(string? email, string? telefon)
        {
            if (string.IsNullOrWhiteSpace(email) && string.IsNullOrWhiteSpace(telefon))
                throw new ArgumentException("Podaj email lub numer telefonu.");
        }
    }
}
