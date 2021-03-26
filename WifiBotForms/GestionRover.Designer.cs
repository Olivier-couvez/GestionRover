namespace WifiBotForms
{
    partial class GestionRover
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
            this.ControlerRover = new System.Windows.Forms.Button();
            this.SupprimerRover = new System.Windows.Forms.Button();
            this.AjoutRover = new System.Windows.Forms.Button();
            this.listBoxRovers = new System.Windows.Forms.ListBox();
            this.labelRoverSelect = new System.Windows.Forms.Label();
            this.BoxRoverSelect = new System.Windows.Forms.TextBox();
            this.buttonQuitter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ControlerRover
            // 
            this.ControlerRover.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ControlerRover.Location = new System.Drawing.Point(95, 165);
            this.ControlerRover.Name = "ControlerRover";
            this.ControlerRover.Size = new System.Drawing.Size(175, 31);
            this.ControlerRover.TabIndex = 6;
            this.ControlerRover.Text = "Controler le rover";
            this.ControlerRover.UseVisualStyleBackColor = true;
            this.ControlerRover.Click += new System.EventHandler(this.ControlerRover_Click);
            // 
            // SupprimerRover
            // 
            this.SupprimerRover.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SupprimerRover.Location = new System.Drawing.Point(96, 109);
            this.SupprimerRover.Name = "SupprimerRover";
            this.SupprimerRover.Size = new System.Drawing.Size(174, 31);
            this.SupprimerRover.TabIndex = 5;
            this.SupprimerRover.Text = "Supprimer un rover";
            this.SupprimerRover.UseVisualStyleBackColor = true;
            this.SupprimerRover.Click += new System.EventHandler(this.SupprimerRover_Click);
            // 
            // AjoutRover
            // 
            this.AjoutRover.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AjoutRover.Location = new System.Drawing.Point(97, 51);
            this.AjoutRover.Name = "AjoutRover";
            this.AjoutRover.Size = new System.Drawing.Size(174, 31);
            this.AjoutRover.TabIndex = 4;
            this.AjoutRover.Text = "Ajouter un rover";
            this.AjoutRover.UseVisualStyleBackColor = true;
            this.AjoutRover.Click += new System.EventHandler(this.AjoutRover_Click);
            // 
            // listBoxRovers
            // 
            this.listBoxRovers.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.listBoxRovers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxRovers.FormattingEnabled = true;
            this.listBoxRovers.ItemHeight = 20;
            this.listBoxRovers.Location = new System.Drawing.Point(363, 51);
            this.listBoxRovers.Name = "listBoxRovers";
            this.listBoxRovers.Size = new System.Drawing.Size(357, 244);
            this.listBoxRovers.TabIndex = 8;
            this.listBoxRovers.SelectedIndexChanged += new System.EventHandler(this.listBoxRovers_SelectedIndexChanged);
            // 
            // labelRoverSelect
            // 
            this.labelRoverSelect.AutoSize = true;
            this.labelRoverSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRoverSelect.Location = new System.Drawing.Point(54, 388);
            this.labelRoverSelect.Name = "labelRoverSelect";
            this.labelRoverSelect.Size = new System.Drawing.Size(133, 16);
            this.labelRoverSelect.TabIndex = 11;
            this.labelRoverSelect.Text = "Rover sélectionnés : ";
            // 
            // BoxRoverSelect
            // 
            this.BoxRoverSelect.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BoxRoverSelect.Enabled = false;
            this.BoxRoverSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxRoverSelect.Location = new System.Drawing.Point(193, 385);
            this.BoxRoverSelect.Name = "BoxRoverSelect";
            this.BoxRoverSelect.Size = new System.Drawing.Size(247, 22);
            this.BoxRoverSelect.TabIndex = 10;
            // 
            // buttonQuitter
            // 
            this.buttonQuitter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonQuitter.Location = new System.Drawing.Point(615, 388);
            this.buttonQuitter.Name = "buttonQuitter";
            this.buttonQuitter.Size = new System.Drawing.Size(105, 33);
            this.buttonQuitter.TabIndex = 12;
            this.buttonQuitter.Text = "Quitter";
            this.buttonQuitter.UseVisualStyleBackColor = true;
            this.buttonQuitter.Click += new System.EventHandler(this.buttonQuitter_Click);
            // 
            // GestionRover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WifiBotForms.Properties.Resources.terrain2;
            this.ClientSize = new System.Drawing.Size(778, 450);
            this.Controls.Add(this.buttonQuitter);
            this.Controls.Add(this.labelRoverSelect);
            this.Controls.Add(this.BoxRoverSelect);
            this.Controls.Add(this.listBoxRovers);
            this.Controls.Add(this.ControlerRover);
            this.Controls.Add(this.SupprimerRover);
            this.Controls.Add(this.AjoutRover);
            this.Name = "GestionRover";
            this.Text = "GestionRover";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ControlerRover;
        private System.Windows.Forms.Button SupprimerRover;
        private System.Windows.Forms.Button AjoutRover;
        private System.Windows.Forms.ListBox listBoxRovers;
        private System.Windows.Forms.Label labelRoverSelect;
        private System.Windows.Forms.TextBox BoxRoverSelect;
        private System.Windows.Forms.Button buttonQuitter;
    }
}