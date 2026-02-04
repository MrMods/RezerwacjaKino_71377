namespace RezerwacjaKino.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgv_Seanse = new DataGridView();
            btn_Rezerwuj = new Button();
            pic_Poster = new PictureBox();
            lbl_Startod = new Label();
            btn_anuluj = new Button();
            lbl_cena = new Label();
            pnlNaglowek = new Panel();
            lbl_FilmTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)dgv_Seanse).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pic_Poster).BeginInit();
            pnlNaglowek.SuspendLayout();
            SuspendLayout();
            // 
            // dgv_Seanse
            // 
            dgv_Seanse.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Seanse.Location = new Point(12, 12);
            dgv_Seanse.Name = "dgv_Seanse";
            dgv_Seanse.Size = new Size(440, 302);
            dgv_Seanse.TabIndex = 0;
            dgv_Seanse.CellClick += dgv_Seanse_CellClick;
            // 
            // btn_Rezerwuj
            // 
            btn_Rezerwuj.Location = new Point(65, 347);
            btn_Rezerwuj.Name = "btn_Rezerwuj";
            btn_Rezerwuj.Size = new Size(157, 44);
            btn_Rezerwuj.TabIndex = 1;
            btn_Rezerwuj.Text = "Rezerwuj";
            btn_Rezerwuj.UseVisualStyleBackColor = true;
            btn_Rezerwuj.Click += btn_Rezerwuj_Click;
            // 
            // pic_Poster
            // 
            pic_Poster.Location = new Point(13, 13);
            pic_Poster.Name = "pic_Poster";
            pic_Poster.Size = new Size(255, 302);
            pic_Poster.TabIndex = 2;
            pic_Poster.TabStop = false;
            // 
            // lbl_Startod
            // 
            lbl_Startod.AutoSize = true;
            lbl_Startod.Font = new Font("Segoe UI", 12F);
            lbl_Startod.Location = new Point(13, 392);
            lbl_Startod.Name = "lbl_Startod";
            lbl_Startod.Size = new Size(52, 21);
            lbl_Startod.TabIndex = 4;
            lbl_Startod.Text = "label1";
            // 
            // btn_anuluj
            // 
            btn_anuluj.Location = new Point(238, 347);
            btn_anuluj.Name = "btn_anuluj";
            btn_anuluj.Size = new Size(157, 44);
            btn_anuluj.TabIndex = 5;
            btn_anuluj.Text = "Anuluj";
            btn_anuluj.UseVisualStyleBackColor = true;
            btn_anuluj.Click += btn_anuluj_Click;
            // 
            // lbl_cena
            // 
            lbl_cena.AutoSize = true;
            lbl_cena.Font = new Font("Segoe UI", 14F);
            lbl_cena.Location = new Point(186, 421);
            lbl_cena.Name = "lbl_cena";
            lbl_cena.Size = new Size(63, 25);
            lbl_cena.TabIndex = 6;
            lbl_cena.Text = "label1";
            // 
            // pnlNaglowek
            // 
            pnlNaglowek.Controls.Add(pic_Poster);
            pnlNaglowek.Controls.Add(lbl_cena);
            pnlNaglowek.Controls.Add(lbl_FilmTitle);
            pnlNaglowek.Controls.Add(lbl_Startod);
            pnlNaglowek.Location = new Point(452, -1);
            pnlNaglowek.Name = "pnlNaglowek";
            pnlNaglowek.Size = new Size(303, 460);
            pnlNaglowek.TabIndex = 7;
            // 
            // lbl_FilmTitle
            // 
            lbl_FilmTitle.AutoEllipsis = true;
            lbl_FilmTitle.Font = new Font("Segoe UI", 16F);
            lbl_FilmTitle.Location = new Point(13, 328);
            lbl_FilmTitle.MaximumSize = new Size(320, 0);
            lbl_FilmTitle.Name = "lbl_FilmTitle";
            lbl_FilmTitle.Size = new Size(255, 64);
            lbl_FilmTitle.TabIndex = 3;
            lbl_FilmTitle.Text = "label1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(748, 454);
            Controls.Add(pnlNaglowek);
            Controls.Add(btn_anuluj);
            Controls.Add(btn_Rezerwuj);
            Controls.Add(dgv_Seanse);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)dgv_Seanse).EndInit();
            ((System.ComponentModel.ISupportInitialize)pic_Poster).EndInit();
            pnlNaglowek.ResumeLayout(false);
            pnlNaglowek.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgv_Seanse;
        private Button btn_Rezerwuj;
        private PictureBox pic_Poster;
        private Label lbl_Startod;
        private Label lbl_FilmTitle;
        private Button btn_anuluj;
        private Label lbl_cena;
        private Panel pnlNaglowek;
    }
}