using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RezerwacjaKino.Models;
using RezerwacjaKino.Services;
using static System.Windows.Forms.AxHost;

namespace RezerwacjaKino.UI
{
    public partial class ReservationForm : Form
    {
        private readonly Seans seans;
        
        private readonly HashSet<Seat> wybrane = new();
        private readonly RezerwacjaService service;
        private HashSet<Seat> zajete = new();
        private bool zapiswtrakcie = false;
        private bool rezerwacjazakonczona = false;


        public ReservationForm(Seans seans, RezerwacjaService service)
        {
            InitializeComponent();
            this.service = service;
            //Wyglad formularza
            BackColor = Color.FromArgb(160, 175, 190);
            tbl_Miejsca.BackColor = Color.FromArgb(190, 205, 220);
            pnlNaglowek.BackColor = Color.FromArgb(140, 160, 175);

            pnlKontoPlace.BackColor = Color.FromArgb(140, 160, 175);
            pnlKonto.Left = (pnlKontoPlace.Width - pnlKonto.Width) / 2;
            pnlKonto.Top = (pnlKontoPlace.Height - pnlKonto.Height) / 2;
            this.seans = seans;
            Load += ReservationForm_Load;
            btn_Zapisz.Click += btn_Zapisz_Click;
            btn_Anuluj.Click += btn_Anuluj_Click;

            cmb_TypBiletu.Items.Clear();
            cmb_TypBiletu.Items.AddRange(new object[] { "Normalny", "Ulgowy" });
            cmb_TypBiletu.SelectedIndex = 0;
        }

        private void ReservationForm_Load(object? sender, EventArgs e)
        {
            //Ustawienia naglowka kolory
            lbl_tytul.Font = new Font("Segoe UI Semibold", 16f);
            lbl_tytul.ForeColor = Color.FromArgb(35, 45, 55);
            lbl_tytul.TextAlign = ContentAlignment.MiddleCenter;

            lbl_data.Font = new Font("Segoe UI", 9.5f);
            lbl_data.ForeColor = Color.FromArgb(35, 45, 55);
            lbl_data.TextAlign = ContentAlignment.MiddleCenter;
            lbl_Salainfo.Font = new Font("Segoe UI", 9.5f);
            lbl_Salainfo.ForeColor = Color.FromArgb(35, 45, 55);
            lbl_Salainfo.TextAlign = ContentAlignment.MiddleCenter;

            lbl_tytul.Text = seans.FilmTytul;
            lbl_data.Text = $"{seans.StartOd:yyyy-MM-dd, HH:MM}";
            lbl_Salainfo.Text = seans.SalaNazwa;
            //odswiezanie miejsca
            OdswiezMiejsce();
        }

        private void OdswiezMiejsce()
        {
            zajete = service.PobierzZajeteMiejsca(seans.IdSeans);
            wybrane.Clear();

            //Ustawienia obiektow kolory, dzialanie, itp
            int seatW = 55;
            int seatH = 55;
            int seatMargin = 6;

            pnlPanel.AutoScroll = true;
            pnlPanel.BackColor = Color.FromArgb(140, 160, 175);

            tbl_Miejsca.SuspendLayout();
            tbl_Miejsca.Controls.Clear();
            tbl_Miejsca.ColumnStyles.Clear();
            tbl_Miejsca.RowStyles.Clear();

            tbl_Miejsca.Margin = Padding.Empty;
            tbl_Miejsca.Padding = Padding.Empty;
            tbl_Miejsca.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;

            tbl_Miejsca.AutoSize = true;
            tbl_Miejsca.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tbl_Miejsca.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;

            tbl_Miejsca.ColumnCount = seans.SalaMiejsc + 1;
            tbl_Miejsca.RowCount = seans.SalaRzedow + 1;

            //Tworzenie miejsc
            tbl_Miejsca.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70));

            for (int c = 0; c < tbl_Miejsca.ColumnCount; c++)
                tbl_Miejsca.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, seatW + seatMargin * 2));

            tbl_Miejsca.RowStyles.Add(new RowStyle(SizeType.Absolute, 26));
            for (int r = 0; r < tbl_Miejsca.RowCount; r++)
                tbl_Miejsca.RowStyles.Add(new RowStyle(SizeType.Absolute, seatH + seatMargin * 2));

            tbl_Miejsca.Controls.Add(NaglowekLabel(""), 0, 0);
            for (int c = 1; c <= seans.SalaMiejsc; c++)
            {
                tbl_Miejsca.Controls.Add(NaglowekLabel(c.ToString()), c, 0);
            }

            for (int r = 1; r <= seans.SalaRzedow; r++)
            {
                tbl_Miejsca.Controls.Add(NaglowekLabel($"Rząd {r}", leftAlign: true), 0, r);
            }

            for (int r = 1; r <= seans.SalaRzedow; r++)
            {
                for (int n = 1; n <= seans.SalaMiejsc; n++)
                {
                    var seat = new Seat(r, n);
                    var btn = new Button
                    {
                        Text = $"{r}-{n}",
                        Tag = seat,
                        AutoSize = false,
                        Size = new Size(seatW, seatH),
                        Margin = new Padding(seatMargin),
                        Padding = Padding.Empty,
                        FlatStyle = FlatStyle.Flat,
                        Anchor = AnchorStyles.None
                    };


                    if (zajete.Contains(seat))
                    {//Zajete miejsce + kolor
                        btn.Enabled = false;
                        btn.BackColor = Color.FromArgb(235, 85, 85);
                    }
                    else
                    {//Wolne miejsce + kolor
                        btn.BackColor = Color.FromArgb(140, 225, 95);
                        btn.Click += MiejscaButton_Click;
                    }
                    //Dodawanie miejsc do gridu
                    tbl_Miejsca.Controls.Add(btn, n, r);
                    //Ustawienia obramowania
                    btn.FlatAppearance.BorderSize = 1;
                    btn.FlatAppearance.BorderColor = Color.FromArgb(70, 80, 95);
                    btn.ForeColor = Color.Black;
                }
            }
            //Ustawienie lokacji, odswiezanie, wyswietlanie panelu i legendy
            tbl_Miejsca.Location = new Point(0, 0);
            tbl_Miejsca.ResumeLayout();
            PanelLegenda();
            OdswiezWybraneMiejsce();
            OdswiezCene();
        }
        private Label NaglowekLabel(string text, bool leftAlign = false)
        {
            return new Label
            {
                Text = text,
                Dock = DockStyle.Fill,
                TextAlign = leftAlign ? ContentAlignment.MiddleLeft : ContentAlignment.MiddleCenter,
                ForeColor = Color.FromArgb(35, 45, 55),
                Font = new Font("Segoe UI", 9f, FontStyle.Regular),
                Padding = leftAlign ? new Padding(6, 0, 0, 0) : Padding.Empty,
                BackColor = Color.Transparent
            };
        }
        private void PanelLegenda()
        {
            flpLegenda.Controls.Clear();
            flpLegenda.Height = 40;

            flpLegenda.Left = (pnlLegenda.Width - flpLegenda.Width) / 2;
            flpLegenda.Top = (pnlLegenda.Height - flpLegenda.Height) / 2;

            flpLegenda.Controls.Add(LegendItem("Wolne", Color.FromArgb(140, 225, 95)));
            flpLegenda.Controls.Add(LegendItem("Zajęte", Color.FromArgb(235, 85, 85)));
            flpLegenda.Controls.Add(LegendItem("Twój wybór", Color.FromArgb(74, 156, 255)));
        }
        private Control LegendItem(string text, Color color)
        {
            var wrap = new FlowLayoutPanel
            {
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Margin = new Padding(12, 0, 0, 0),
                BackColor = Color.Transparent
            };

            var box = new Panel
            {
                Left = 0,
                Top = 5,
                Width = 14,
                Height = 14,
                BackColor = color
            };

            var lbl = new Label
            {
                Left = 22,
                Top = 2,
                AutoSize = true,
                Text = text,
                ForeColor = Color.FromArgb(35, 45, 55),
                Font = new Font("Segoe UI", 9f)
            };

            wrap.Controls.Add(box);
            wrap.Controls.Add(lbl);
            return wrap;
        }
        private void OdswiezWybraneMiejsce()
        {
            lbl_LiczbaWybranych.Text = $"Wybrane miejsca: {wybrane.Count}";
        }

        private void MiejscaButton_Click(object? sender, EventArgs e)
        {
            var btn = (Button)sender!;
            var seat = (Seat)btn.Tag!;

            if (wybrane.Contains(seat))
            {//Wolne miejsce
                wybrane.Remove(seat);
                btn.BackColor = Color.FromArgb(140, 225, 95);
                btn.ForeColor = Color.Black;
            }
            else
            {//Wybrane miejsce
                wybrane.Add(seat);
                btn.BackColor = Color.FromArgb(74, 156, 255); ;
                btn.ForeColor = Color.White;
            }

            OdswiezWybraneMiejsce();
            OdswiezCene();
        }
        private decimal ObliczCene()
        {
            int liczbaMiejsc = wybrane.Count;
            if (liczbaMiejsc == 0) return 0m;

            decimal cenaZaBilet = seans.CenaPodstawowa;

            var typ = string.IsNullOrWhiteSpace(cmb_TypBiletu.Text) ? "Normalny" : cmb_TypBiletu.Text.Trim();

            if (typ.Equals("Ulgowy", StringComparison.OrdinalIgnoreCase))
                cenaZaBilet = Math.Round(seans.CenaPodstawowa * 0.8m, 2);

            return Math.Round(liczbaMiejsc * cenaZaBilet, 2);
        }
        private void OdswiezCene()
        {
            decimal suma = ObliczCene();
            lblCena.Text = $"{suma:,0} zł";
        }
        private void btn_Zapisz_Click(object sender, EventArgs e)
        {
            //Zabezpieczenie przeciw double click i podwojnemu przesylaniu informacji
            if (zapiswtrakcie || rezerwacjazakonczona) return;
            zapiswtrakcie = true;
            btn_Zapisz.Enabled = false;

            try
            {
                var kilent = new Klient
                {
                    Imie = txt_Imie.Text.Trim(),
                    Nazwisko = txt_Nazwisko.Text.Trim(),
                    Email = string.IsNullOrWhiteSpace(txt_Email.Text) ? null : txt_Email.Text.Trim(),
                    Telefon = string.IsNullOrWhiteSpace(txt_Telefon.Text) ? null : txt_Telefon.Text.Trim()
                };

                var typ = string.IsNullOrWhiteSpace(cmb_TypBiletu.Text) ? "Normalny" : cmb_TypBiletu.Text.Trim();
                var cena = seans.CenaPodstawowa;
                if (typ.Equals("Ulgowy", StringComparison.OrdinalIgnoreCase))
                    cena = Math.Round(seans.CenaPodstawowa * 0.8m, 2);

                var (ok, refresh, wiadomosc) = service.Zarezerwuj(seans.IdSeans, kilent, wybrane.ToList(), typ, cena);
                MessageBox.Show(wiadomosc);
                if (refresh)
                {
                    OdswiezMiejsce();
                    wybrane.Clear();
                    OdswiezWybraneMiejsce();
                }

                if (ok)
                {
                    rezerwacjazakonczona = true;
                    wybrane.Clear();
                    OdswiezMiejsce();
                    return;
                }
            }
            finally
            {
                btn_Zapisz.Enabled = true;
                zapiswtrakcie = false;
                rezerwacjazakonczona = false;
            }
        }

        private void btn_Anuluj_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void WyczyscFormularz()
        {
            wybrane.Clear();
            OdswiezMiejsce();
            OdswiezWybraneMiejsce();

            txt_Imie.Clear();
            txt_Nazwisko.Clear();
            txt_Email.Clear();
            txt_Telefon.Clear();

            if (cmb_TypBiletu.Items.Count > 0)
                cmb_TypBiletu.SelectedIndex = 0;

            OdswiezCene();

            btn_Zapisz.Enabled = false;

            zapiswtrakcie = false;
            rezerwacjazakonczona = false;
        }

        private void cmb_TypBiletu_SelectedIndexChanged(object sender, EventArgs e)
        {
            OdswiezCene();
        }

        private void btn_wyczysc_Click(object sender, EventArgs e)
        {
            WyczyscFormularz();
        }
    }
}
