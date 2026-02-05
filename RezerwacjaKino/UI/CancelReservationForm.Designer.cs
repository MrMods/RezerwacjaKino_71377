namespace RezerwacjaKino.UI
{
    partial class CancelReservationForm
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
            txtemailtel = new TextBox();
            btnszukaj = new Button();
            dgvRezerwacje = new DataGridView();
            btnAnuluj = new Button();
            btnZamknij = new Button();
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRezerwacje).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // txtemailtel
            // 
            txtemailtel.Location = new Point(245, 168);
            txtemailtel.Name = "txtemailtel";
            txtemailtel.Size = new Size(147, 23);
            txtemailtel.TabIndex = 0;
            // 
            // btnszukaj
            // 
            btnszukaj.Location = new Point(284, 197);
            btnszukaj.Name = "btnszukaj";
            btnszukaj.Size = new Size(75, 23);
            btnszukaj.TabIndex = 1;
            btnszukaj.Text = "Szukaj";
            btnszukaj.UseVisualStyleBackColor = true;
            btnszukaj.Click += btnszukaj_Click;
            // 
            // dgvRezerwacje
            // 
            dgvRezerwacje.AllowUserToAddRows = false;
            dgvRezerwacje.AllowUserToDeleteRows = false;
            dgvRezerwacje.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRezerwacje.Location = new Point(12, 21);
            dgvRezerwacje.Name = "dgvRezerwacje";
            dgvRezerwacje.Size = new Size(605, 107);
            dgvRezerwacje.TabIndex = 2;
            // 
            // btnAnuluj
            // 
            btnAnuluj.Location = new Point(284, 35);
            btnAnuluj.Name = "btnAnuluj";
            btnAnuluj.Size = new Size(75, 23);
            btnAnuluj.TabIndex = 3;
            btnAnuluj.Text = "Anuluj";
            btnAnuluj.UseVisualStyleBackColor = true;
            btnAnuluj.Click += btnAnuluj_Click;
            // 
            // btnZamknij
            // 
            btnZamknij.Location = new Point(284, 76);
            btnZamknij.Name = "btnZamknij";
            btnZamknij.Size = new Size(75, 23);
            btnZamknij.TabIndex = 4;
            btnZamknij.Text = "Zamknij";
            btnZamknij.UseVisualStyleBackColor = true;
            btnZamknij.Click += btnZamknij_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtemailtel);
            panel1.Controls.Add(btnszukaj);
            panel1.Controls.Add(dgvRezerwacje);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(629, 236);
            panel1.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(42, 140);
            label1.Name = "label1";
            label1.Size = new Size(538, 25);
            label1.TabIndex = 3;
            label1.Text = "Podaj e-mail lub numer telefonu w celu anulowania rezerwacji";
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Controls.Add(btnAnuluj);
            panel2.Controls.Add(btnZamknij);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 232);
            panel2.Name = "panel2";
            panel2.Size = new Size(629, 111);
            panel2.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(219, 7);
            label2.Name = "label2";
            label2.Size = new Size(203, 25);
            label2.TabIndex = 5;
            label2.Text = "Anulowanie rezerwacji";
            // 
            // CancelReservationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(629, 343);
            ControlBox = false;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "CancelReservationForm";
            Text = "Anulowanie rezerwacji";
            ((System.ComponentModel.ISupportInitialize)dgvRezerwacje).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtemailtel;
        private Button btnszukaj;
        private DataGridView dgvRezerwacje;
        private Button btnAnuluj;
        private Button btnZamknij;
        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Label label2;
    }
}