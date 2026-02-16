using RezerwacjaKino.Models;
using RezerwacjaKino.Repositories;
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

namespace RezerwacjaKino.UI
{
    public partial class MainForm : Form
    {
        private readonly SeansRepository seansRepo = new();
        private readonly RezerwacjaService service;
        private List<Seans> seanse = new();
        //Zabezpieczenie przed ponownym otwiraniem double click
        private bool rezerwacjaOtwarta = false;
        private DateTime cooldown = DateTime.MinValue;

        public MainForm()
        {
            InitializeComponent();
            service = new RezerwacjaService();
            Load += MainForm_Load;
            dgv_Seanse.CellClick += dgv_Seanse_CellClick;
            btn_Rezerwuj.Click += btn_Rezerwuj_Click;

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            seanse = seansRepo.GetAllFilmSala();

            //Wyglad formularza
            dgv_Seanse.AutoGenerateColumns = false;
            dgv_Seanse.RowTemplate.Height = 110;
            dgv_Seanse.AllowUserToAddRows = false;
            dgv_Seanse.ReadOnly = true;
            dgv_Seanse.MultiSelect = false;
            dgv_Seanse.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Seanse.RowHeadersVisible = false;
            dgv_Seanse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Seanse.Columns.Clear();

            BackColor = Color.FromArgb(160, 175, 190);
            pnlNaglowek.BackColor = Color.FromArgb(140, 160, 175);
            lbl_FilmTitle.ForeColor = Color.FromArgb(35, 45, 55);
            lbl_Startod.ForeColor = Color.FromArgb(35, 45, 55);
            lbl_cena.ForeColor = Color.FromArgb(35, 45, 55);
            lbl_FilmTitle.Font = new Font(lbl_FilmTitle.Font, FontStyle.Bold);
            lbl_cena.Font = new Font(lbl_cena.Font, FontStyle.Bold);


            dgv_Seanse.EnableHeadersVisualStyles = false;

            dgv_Seanse.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(140, 160, 175);
            dgv_Seanse.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv_Seanse.ColumnHeadersDefaultCellStyle.Font =
                new Font(dgv_Seanse.Font, FontStyle.Bold);

            dgv_Seanse.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                dgv_Seanse.ColumnHeadersDefaultCellStyle.BackColor;
            dgv_Seanse.ColumnHeadersDefaultCellStyle.SelectionForeColor =
                dgv_Seanse.ColumnHeadersDefaultCellStyle.ForeColor;
            dgv_Seanse.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_Seanse.RowHeadersVisible = false;
            dgv_Seanse.BorderStyle = BorderStyle.None;
            dgv_Seanse.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_Seanse.GridColor = SystemColors.ControlLight;

            dgv_Seanse.ColumnHeadersHeight = 36;
            dgv_Seanse.ColumnHeadersDefaultCellStyle.Font =
                new Font(dgv_Seanse.Font, FontStyle.Bold);

            dgv_Seanse.DefaultCellStyle.Padding = new Padding(6, 4, 6, 4);
            dgv_Seanse.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            dgv_Seanse.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;

            dgv_Seanse.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgv_Seanse.BackgroundColor = Color.FromArgb(190, 205, 220);

            dgv_Seanse.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Film",
                DataPropertyName = "FilmTytul",
                Width = 200
            });
            dgv_Seanse.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Data",
                DataPropertyName = "StartOd",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd-MM-yyyy" },
                Width = 160
            });
            dgv_Seanse.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Start",
                DataPropertyName = "StartOd",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "HH:mm" },
                Width = 160
            });

            dgv_Seanse.DataSource = seanse;

            if (dgv_Seanse.Rows.Count > 0)
            {
                dgv_Seanse.Rows[0].Selected = true;
                dgv_Seanse.CurrentCell = dgv_Seanse.Rows[0].Cells[0];

                DefaultPoster();
            }
        }

        private void btn_Rezerwuj_Click(object sender, EventArgs e)
        {
            if (DateTime.UtcNow < cooldown) return;

            if (rezerwacjaOtwarta) return;
            rezerwacjaOtwarta = true;
            btn_Rezerwuj.Enabled = false;

            try
            {
                if (dgv_Seanse.CurrentRow?.DataBoundItem is not Seans s)
                {
                    MessageBox.Show("Wybierz seans.");
                    return;
                }

                using var frm = new ReservationForm(s, service);
                frm.ShowDialog(this);
            }
            finally
            {
                cooldown = DateTime.UtcNow.AddMilliseconds(300);

                btn_Rezerwuj.Enabled = true;
                rezerwacjaOtwarta = false;
            }
        }

        private void dgv_Seanse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Seanse.CurrentRow?.DataBoundItem is not Seans s) return;

            lbl_FilmTitle.Text = s.FilmTytul;
            lbl_Startod.Text = $"| {s.StartOd:dd-MM-yyyy HH:mm} | {s.SalaNazwa} | {s.Ograniczenia} |";
            lbl_cena.Text = $"{s.CenaPodstawowa:0.00} zł";

            if (!string.IsNullOrWhiteSpace(s.PosterPath))
            {
                var full = Path.Combine(AppContext.BaseDirectory, s.PosterPath);
                pic_Poster.SizeMode = PictureBoxSizeMode.Zoom;
                pic_Poster.Image = File.Exists(full) ? Image.FromFile(full) : null;
            }
            else pic_Poster.Image = null;
        }
        private readonly Dictionary<string, Image> _posterCache = new();

        private Image? GetPosterImage(string? posterPath)
        {
            if (string.IsNullOrWhiteSpace(posterPath)) return null;

            var full = Path.Combine(AppContext.BaseDirectory, posterPath);

            if (_posterCache.TryGetValue(full, out var img))
                return img;

            if (!File.Exists(full)) return null;

            // wczytanie bez blokowania pliku
            using var fs = new FileStream(full, FileMode.Open, FileAccess.Read);
            var loaded = Image.FromStream(fs);

            _posterCache[full] = loaded;
            return loaded;
        }
        private void DefaultPoster()
        {
            if (dgv_Seanse.CurrentRow?.DataBoundItem is not Seans s)
                return;

            lbl_FilmTitle.Text = s.FilmTytul;
            lbl_Startod.Text = $"| {s.StartOd:dd:MM:yyy HH:mm} | {s.SalaNazwa} | {s.Ograniczenia} |";
            lbl_cena.Text = $"{s.CenaPodstawowa:0.00} zł";

            pic_Poster.SizeMode = PictureBoxSizeMode.Zoom;
            pic_Poster.Image = GetPosterImage(s.PosterPath);
        }

        private void btn_anuluj_Click(object sender, EventArgs e)
        {
            using var f = new CancelReservationForm(service);
            f.ShowDialog(this);
        }
    }
}
