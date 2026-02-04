using RezerwacjaKino.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RezerwacjaKino.Services.RezerwacjaService;

namespace RezerwacjaKino.UI
{
    public partial class CancelReservationForm : Form
    {
        private readonly RezerwacjaService service;
        public CancelReservationForm(RezerwacjaService service)
        {
            InitializeComponent();
            this.service = service;

            //Wyglad formularza
            panel1.BackColor = Color.FromArgb(190, 205, 220);
            panel2.BackColor = Color.FromArgb(140, 160, 175);
            label1.ForeColor = Color.FromArgb(35, 45, 55);
            label2.ForeColor = Color.FromArgb(35, 45, 55);
            btnAnuluj.ForeColor = Color.FromArgb(35, 45, 55);
            btnszukaj.ForeColor = Color.FromArgb(35, 45, 55);
            btnZamknij.ForeColor = Color.FromArgb(35, 45, 55);

            dgvRezerwacje.AutoGenerateColumns = false;
            dgvRezerwacje.MultiSelect = false;
            dgvRezerwacje.ReadOnly = true;

            dgvRezerwacje.EnableHeadersVisualStyles = false;

            dgvRezerwacje.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(140, 160, 175);
            dgvRezerwacje.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvRezerwacje.ColumnHeadersDefaultCellStyle.Font =
                new Font(dgvRezerwacje.Font, FontStyle.Bold);

            dgvRezerwacje.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                dgvRezerwacje.ColumnHeadersDefaultCellStyle.BackColor;
            dgvRezerwacje.ColumnHeadersDefaultCellStyle.SelectionForeColor =
                dgvRezerwacje.ColumnHeadersDefaultCellStyle.ForeColor;

            dgvRezerwacje.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvRezerwacje.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRezerwacje.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvRezerwacje.RowHeadersVisible = false;
            dgvRezerwacje.BorderStyle = BorderStyle.None;
            dgvRezerwacje.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRezerwacje.GridColor = SystemColors.ControlLight;

            dgvRezerwacje.ColumnHeadersHeight = 36;
            dgvRezerwacje.ColumnHeadersDefaultCellStyle.Font =
                new Font(dgvRezerwacje.Font, FontStyle.Bold);

            dgvRezerwacje.DefaultCellStyle.Padding = new Padding(6, 4, 6, 4);
            dgvRezerwacje.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            dgvRezerwacje.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;

            dgvRezerwacje.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgvRezerwacje.BackgroundColor = Color.FromArgb(190, 205, 220);

            dgvRezerwacje.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Data", DataPropertyName = "StartOd", Width = 140 });
            dgvRezerwacje.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Film", DataPropertyName = "FilmTytul", Width = 220 });
            dgvRezerwacje.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Sala", DataPropertyName = "SalaNazwa", Width = 80 });
            dgvRezerwacje.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Miejsca", DataPropertyName = "MiejscaText", Width = 140 });
            dgvRezerwacje.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Kwota", DataPropertyName = "KwotaText", Width = 80 });
        }
        private void btnszukaj_Click(object sender, EventArgs e)
        {
            var key = txtemailtel.Text.Trim();
            if (string.IsNullOrWhiteSpace(key))
            {
                MessageBox.Show("Podaj e-mail lub telefon.");
                return;
            }

            string? email = null;
            string? tel = null;

            if (key.Contains("@"))
                email = WalidacjaDanych.NormalizujEmail(key);
            else
                tel = WalidacjaDanych.NormalizujTelefon(key);

            var lista = service.SzukajRezerwacji(email, tel);

            dgvRezerwacje.DataSource = lista;
        }
        private void btnZamknij_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAnuluj_Click(object sender, EventArgs e)
        {
            if (dgvRezerwacje.CurrentRow?.DataBoundItem is not RezerwacjaRow row)
            {
                MessageBox.Show("Wybierz rezerwację z listy.");
                return;
            }

            var confirm = MessageBox.Show($"Anulowac rezerwację? \n\n{row.FilmTytul}\n{row.StartOd}\nMiejsca: {row.MiejscaText}", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            var (ok, wiadomosc) = service.AnulujRezerwacje(row.IdBilet, txtemailtel.Text);
            MessageBox.Show(wiadomosc);

            if (ok)
            {
                btnszukaj_Click(sender, e);
            }
        }
    }
}
