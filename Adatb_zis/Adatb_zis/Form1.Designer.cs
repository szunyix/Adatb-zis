namespace Adatb_zis
{
    partial class Form1
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
            this.dvg_noveny = new System.Windows.Forms.DataGridView();
            this.buttonFelvisz = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxKor = new System.Windows.Forms.TextBox();
            this.textBoxFajta = new System.Windows.Forms.TextBox();
            this.textBoxAra = new System.Windows.Forms.TextBox();
            this.textBoxUzletek = new System.Windows.Forms.TextBox();
            this.buttonFrissit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvg_noveny)).BeginInit();
            this.SuspendLayout();
            // 
            // dvg_noveny
            // 
            this.dvg_noveny.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvg_noveny.Location = new System.Drawing.Point(32, 20);
            this.dvg_noveny.Name = "dvg_noveny";
            this.dvg_noveny.Size = new System.Drawing.Size(756, 270);
            this.dvg_noveny.TabIndex = 0;
            // 
            // buttonFelvisz
            // 
            this.buttonFelvisz.Location = new System.Drawing.Point(32, 308);
            this.buttonFelvisz.Name = "buttonFelvisz";
            this.buttonFelvisz.Size = new System.Drawing.Size(144, 36);
            this.buttonFelvisz.TabIndex = 1;
            this.buttonFelvisz.Text = "növény felvitele";
            this.buttonFelvisz.UseVisualStyleBackColor = true;
            this.buttonFelvisz.Click += new System.EventHandler(this.buttonFelvisz_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(31, 351);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(145, 33);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "növény eltávolítása";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(500, 308);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(210, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(238, 308);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(166, 20);
            this.textBoxID.TabIndex = 5;
            this.textBoxID.Tag = "";
            this.textBoxID.Text = "növény neve (ID)";
            this.textBoxID.Enter += new System.EventHandler(this.textBoxID_Enter);
            // 
            // textBoxKor
            // 
            this.textBoxKor.Location = new System.Drawing.Point(238, 351);
            this.textBoxKor.Name = "textBoxKor";
            this.textBoxKor.Size = new System.Drawing.Size(165, 20);
            this.textBoxKor.TabIndex = 6;
            this.textBoxKor.Text = "növény kora";
            this.textBoxKor.Enter += new System.EventHandler(this.textBoxKor_Enter);
            // 
            // textBoxFajta
            // 
            this.textBoxFajta.Location = new System.Drawing.Point(238, 394);
            this.textBoxFajta.Name = "textBoxFajta";
            this.textBoxFajta.Size = new System.Drawing.Size(167, 20);
            this.textBoxFajta.TabIndex = 7;
            this.textBoxFajta.Text = "növény fajtája";
            this.textBoxFajta.Enter += new System.EventHandler(this.textBoxFajta_Enter);
            // 
            // textBoxAra
            // 
            this.textBoxAra.Location = new System.Drawing.Point(500, 351);
            this.textBoxAra.Name = "textBoxAra";
            this.textBoxAra.Size = new System.Drawing.Size(208, 20);
            this.textBoxAra.TabIndex = 8;
            this.textBoxAra.Text = "növény ára";
            this.textBoxAra.Enter += new System.EventHandler(this.textBoxAra_Enter);
            // 
            // textBoxUzletek
            // 
            this.textBoxUzletek.Location = new System.Drawing.Point(499, 395);
            this.textBoxUzletek.Name = "textBoxUzletek";
            this.textBoxUzletek.Size = new System.Drawing.Size(210, 20);
            this.textBoxUzletek.TabIndex = 9;
            this.textBoxUzletek.Text = "megtalálható a boltban (ID)";
            this.textBoxUzletek.Enter += new System.EventHandler(this.textBoxUzletek_Enter);
            // 
            // buttonFrissit
            // 
            this.buttonFrissit.Location = new System.Drawing.Point(31, 394);
            this.buttonFrissit.Name = "buttonFrissit";
            this.buttonFrissit.Size = new System.Drawing.Size(145, 34);
            this.buttonFrissit.TabIndex = 10;
            this.buttonFrissit.Text = "Frissít";
            this.buttonFrissit.UseVisualStyleBackColor = true;
            this.buttonFrissit.Click += new System.EventHandler(this.buttonFrissit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonFrissit);
            this.Controls.Add(this.textBoxUzletek);
            this.Controls.Add(this.textBoxAra);
            this.Controls.Add(this.textBoxFajta);
            this.Controls.Add(this.textBoxKor);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonFelvisz);
            this.Controls.Add(this.dvg_noveny);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvg_noveny)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dvg_noveny;
        private System.Windows.Forms.Button buttonFelvisz;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxKor;
        private System.Windows.Forms.TextBox textBoxFajta;
        private System.Windows.Forms.TextBox textBoxAra;
        private System.Windows.Forms.TextBox textBoxUzletek;
        private System.Windows.Forms.Button buttonFrissit;
    }
}

