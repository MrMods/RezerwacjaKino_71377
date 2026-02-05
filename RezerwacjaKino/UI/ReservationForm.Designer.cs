namespace RezerwacjaKino.UI
{
    partial class ReservationForm
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
            lbl_Salainfo = new Label();
            tbl_Miejsca = new TableLayoutPanel();
            txt_Imie = new TextBox();
            txt_Nazwisko = new TextBox();
            txt_Email = new TextBox();
            txt_Telefon = new TextBox();
            cmb_TypBiletu = new ComboBox();
            lbl_LiczbaWybranych = new Label();
            btn_Zapisz = new Button();
            btn_Anuluj = new Button();
            pnlPanel = new Panel();
            flpLegenda = new FlowLayoutPanel();
            pnlLegenda = new Panel();
            pnlNaglowek = new Panel();
            lbl_data = new Label();
            lbl_tytul = new Label();
            panel1 = new Panel();
            pnlKontoPlace = new Panel();
            pnlKonto = new Panel();
            btn_wyczysc = new Button();
            label5 = new Label();
            lblCena = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pnlPanel.SuspendLayout();
            pnlLegenda.SuspendLayout();
            pnlNaglowek.SuspendLayout();
            panel1.SuspendLayout();
            pnlKontoPlace.SuspendLayout();
            pnlKonto.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_Salainfo
            // 
            lbl_Salainfo.AutoSize = true;
            lbl_Salainfo.Location = new Point(520, 72);
            lbl_Salainfo.Name = "lbl_Salainfo";
            lbl_Salainfo.Size = new Size(38, 15);
            lbl_Salainfo.TabIndex = 0;
            lbl_Salainfo.Text = "label1";
            // 
            // tbl_Miejsca
            // 
            tbl_Miejsca.AutoSize = true;
            tbl_Miejsca.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tbl_Miejsca.ColumnCount = 2;
            tbl_Miejsca.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbl_Miejsca.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbl_Miejsca.Location = new Point(-194, 3);
            tbl_Miejsca.Margin = new Padding(0);
            tbl_Miejsca.Name = "tbl_Miejsca";
            tbl_Miejsca.RowCount = 2;
            tbl_Miejsca.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tbl_Miejsca.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tbl_Miejsca.Size = new Size(0, 0);
            tbl_Miejsca.TabIndex = 1;
            // 
            // txt_Imie
            // 
            txt_Imie.Location = new Point(26, 37);
            txt_Imie.Name = "txt_Imie";
            txt_Imie.Size = new Size(130, 23);
            txt_Imie.TabIndex = 2;
            // 
            // txt_Nazwisko
            // 
            txt_Nazwisko.Location = new Point(200, 37);
            txt_Nazwisko.Name = "txt_Nazwisko";
            txt_Nazwisko.Size = new Size(132, 23);
            txt_Nazwisko.TabIndex = 3;
            // 
            // txt_Email
            // 
            txt_Email.Location = new Point(26, 128);
            txt_Email.Name = "txt_Email";
            txt_Email.Size = new Size(131, 23);
            txt_Email.TabIndex = 4;
            // 
            // txt_Telefon
            // 
            txt_Telefon.Location = new Point(201, 128);
            txt_Telefon.Name = "txt_Telefon";
            txt_Telefon.Size = new Size(130, 23);
            txt_Telefon.TabIndex = 5;
            // 
            // cmb_TypBiletu
            // 
            cmb_TypBiletu.FormattingEnabled = true;
            cmb_TypBiletu.Location = new Point(27, 182);
            cmb_TypBiletu.Name = "cmb_TypBiletu";
            cmb_TypBiletu.Size = new Size(130, 23);
            cmb_TypBiletu.TabIndex = 6;
            cmb_TypBiletu.SelectedIndexChanged += cmb_TypBiletu_SelectedIndexChanged;
            // 
            // lbl_LiczbaWybranych
            // 
            lbl_LiczbaWybranych.AutoSize = true;
            lbl_LiczbaWybranych.Location = new Point(334, 62);
            lbl_LiczbaWybranych.Name = "lbl_LiczbaWybranych";
            lbl_LiczbaWybranych.Size = new Size(38, 15);
            lbl_LiczbaWybranych.TabIndex = 7;
            lbl_LiczbaWybranych.Text = "label1";
            // 
            // btn_Zapisz
            // 
            btn_Zapisz.Location = new Point(48, 241);
            btn_Zapisz.Name = "btn_Zapisz";
            btn_Zapisz.Size = new Size(75, 23);
            btn_Zapisz.TabIndex = 8;
            btn_Zapisz.Text = "Zapisz";
            btn_Zapisz.UseVisualStyleBackColor = true;
            // 
            // btn_Anuluj
            // 
            btn_Anuluj.Location = new Point(225, 241);
            btn_Anuluj.Name = "btn_Anuluj";
            btn_Anuluj.Size = new Size(75, 23);
            btn_Anuluj.TabIndex = 9;
            btn_Anuluj.Text = "Zamknij";
            btn_Anuluj.UseVisualStyleBackColor = true;
            // 
            // pnlPanel
            // 
            pnlPanel.BorderStyle = BorderStyle.FixedSingle;
            pnlPanel.Controls.Add(tbl_Miejsca);
            pnlPanel.Dock = DockStyle.Top;
            pnlPanel.Location = new Point(0, 100);
            pnlPanel.Name = "pnlPanel";
            pnlPanel.Size = new Size(760, 369);
            pnlPanel.TabIndex = 11;
            // 
            // flpLegenda
            // 
            flpLegenda.Anchor = AnchorStyles.None;
            flpLegenda.AutoSize = true;
            flpLegenda.Location = new Point(121, 17);
            flpLegenda.Name = "flpLegenda";
            flpLegenda.Size = new Size(251, 26);
            flpLegenda.TabIndex = 12;
            flpLegenda.WrapContents = false;
            // 
            // pnlLegenda
            // 
            pnlLegenda.Controls.Add(flpLegenda);
            pnlLegenda.Controls.Add(lbl_LiczbaWybranych);
            pnlLegenda.Dock = DockStyle.Top;
            pnlLegenda.Location = new Point(0, 469);
            pnlLegenda.Name = "pnlLegenda";
            pnlLegenda.Size = new Size(760, 80);
            pnlLegenda.TabIndex = 13;
            // 
            // pnlNaglowek
            // 
            pnlNaglowek.Controls.Add(lbl_data);
            pnlNaglowek.Controls.Add(lbl_tytul);
            pnlNaglowek.Controls.Add(lbl_Salainfo);
            pnlNaglowek.Dock = DockStyle.Top;
            pnlNaglowek.Location = new Point(0, 0);
            pnlNaglowek.Name = "pnlNaglowek";
            pnlNaglowek.Size = new Size(760, 100);
            pnlNaglowek.TabIndex = 14;
            // 
            // lbl_data
            // 
            lbl_data.AutoSize = true;
            lbl_data.Location = new Point(520, 47);
            lbl_data.Name = "lbl_data";
            lbl_data.Size = new Size(38, 15);
            lbl_data.TabIndex = 1;
            lbl_data.Text = "label1";
            // 
            // lbl_tytul
            // 
            lbl_tytul.AutoSize = true;
            lbl_tytul.Location = new Point(159, 47);
            lbl_tytul.Name = "lbl_tytul";
            lbl_tytul.Size = new Size(38, 15);
            lbl_tytul.TabIndex = 0;
            lbl_tytul.Text = "label1";
            // 
            // panel1
            // 
            panel1.Controls.Add(pnlKontoPlace);
            panel1.Controls.Add(pnlLegenda);
            panel1.Controls.Add(pnlPanel);
            panel1.Controls.Add(pnlNaglowek);
            panel1.Location = new Point(3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(760, 909);
            panel1.TabIndex = 15;
            // 
            // pnlKontoPlace
            // 
            pnlKontoPlace.Controls.Add(pnlKonto);
            pnlKontoPlace.Dock = DockStyle.Top;
            pnlKontoPlace.Location = new Point(0, 549);
            pnlKontoPlace.Name = "pnlKontoPlace";
            pnlKontoPlace.Size = new Size(760, 379);
            pnlKontoPlace.TabIndex = 16;
            // 
            // pnlKonto
            // 
            pnlKonto.Controls.Add(btn_wyczysc);
            pnlKonto.Controls.Add(label5);
            pnlKonto.Controls.Add(lblCena);
            pnlKonto.Controls.Add(txt_Imie);
            pnlKonto.Controls.Add(label4);
            pnlKonto.Controls.Add(txt_Telefon);
            pnlKonto.Controls.Add(label3);
            pnlKonto.Controls.Add(cmb_TypBiletu);
            pnlKonto.Controls.Add(label2);
            pnlKonto.Controls.Add(btn_Zapisz);
            pnlKonto.Controls.Add(label1);
            pnlKonto.Controls.Add(txt_Email);
            pnlKonto.Controls.Add(btn_Anuluj);
            pnlKonto.Controls.Add(txt_Nazwisko);
            pnlKonto.Location = new Point(159, 31);
            pnlKonto.Name = "pnlKonto";
            pnlKonto.Size = new Size(346, 286);
            pnlKonto.TabIndex = 14;
            // 
            // btn_wyczysc
            // 
            btn_wyczysc.Location = new Point(138, 241);
            btn_wyczysc.Name = "btn_wyczysc";
            btn_wyczysc.Size = new Size(75, 23);
            btn_wyczysc.TabIndex = 17;
            btn_wyczysc.Text = "Wyczyść";
            btn_wyczysc.UseVisualStyleBackColor = true;
            btn_wyczysc.Click += btn_wyczysc_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F);
            label5.Location = new Point(199, 182);
            label5.Name = "label5";
            label5.Size = new Size(59, 28);
            label5.TabIndex = 16;
            label5.Text = "Cena:";
            // 
            // lblCena
            // 
            lblCena.AutoSize = true;
            lblCena.Font = new Font("Segoe UI", 12F);
            lblCena.Location = new Point(264, 188);
            lblCena.Name = "lblCena";
            lblCena.Size = new Size(52, 21);
            lblCena.TabIndex = 15;
            lblCena.Text = "label6";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(201, 97);
            label4.Name = "label4";
            label4.Size = new Size(78, 28);
            label4.TabIndex = 13;
            label4.Text = "Telefon:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(27, 97);
            label3.Name = "label3";
            label3.Size = new Size(63, 28);
            label3.TabIndex = 12;
            label3.Text = "Email:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(201, 6);
            label2.Name = "label2";
            label2.Size = new Size(99, 28);
            label2.TabIndex = 11;
            label2.Text = "Nazwisko:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(26, 6);
            label1.Name = "label1";
            label1.Size = new Size(53, 28);
            label1.TabIndex = 10;
            label1.Text = "Imie:";
            // 
            // ReservationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HighlightText;
            ClientSize = new Size(767, 912);
            ControlBox = false;
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReservationForm";
            Text = "Rezerwacja";
            TransparencyKey = SystemColors.ActiveBorder;
            pnlPanel.ResumeLayout(false);
            pnlPanel.PerformLayout();
            pnlLegenda.ResumeLayout(false);
            pnlLegenda.PerformLayout();
            pnlNaglowek.ResumeLayout(false);
            pnlNaglowek.PerformLayout();
            panel1.ResumeLayout(false);
            pnlKontoPlace.ResumeLayout(false);
            pnlKonto.ResumeLayout(false);
            pnlKonto.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lbl_Salainfo;
        private TableLayoutPanel tbl_Miejsca;
        private TextBox txt_Imie;
        private TextBox txt_Nazwisko;
        private TextBox txt_Email;
        private TextBox txt_Telefon;
        private ComboBox cmb_TypBiletu;
        private Label lbl_LiczbaWybranych;
        private Button btn_Zapisz;
        private Button btn_Anuluj;
        private Panel pnlPanel;
        private FlowLayoutPanel flpLegenda;
        private Panel pnlLegenda;
        private Panel pnlNaglowek;
        private Label lbl_data;
        private Label lbl_tytul;
        private Panel panel1;
        private Panel pnlKontoPlace;
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label3;
        private Panel pnlKonto;
        private Label label5;
        private Label lblCena;
        private Button btn_wyczysc;
    }
}