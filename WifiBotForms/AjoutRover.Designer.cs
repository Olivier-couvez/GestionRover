namespace WifiBotForms
{
    partial class AjoutRover
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
            this.BoxIp4 = new System.Windows.Forms.MaskedTextBox();
            this.BoxIp3 = new System.Windows.Forms.MaskedTextBox();
            this.BoxIp2 = new System.Windows.Forms.MaskedTextBox();
            this.BoxIp1 = new System.Windows.Forms.MaskedTextBox();
            this.comboBoxTCP = new System.Windows.Forms.ComboBox();
            this.AnnulerConfig = new System.Windows.Forms.Button();
            this.CreerConfig = new System.Windows.Forms.Button();
            this.labelNomRover = new System.Windows.Forms.Label();
            this.labelPort = new System.Windows.Forms.Label();
            this.labelAdrIP = new System.Windows.Forms.Label();
            this.BoxNomRover = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BoxIp4
            // 
            this.BoxIp4.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BoxIp4.Location = new System.Drawing.Point(289, 64);
            this.BoxIp4.Mask = "###";
            this.BoxIp4.Name = "BoxIp4";
            this.BoxIp4.Size = new System.Drawing.Size(28, 20);
            this.BoxIp4.TabIndex = 4;
            // 
            // BoxIp3
            // 
            this.BoxIp3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BoxIp3.Location = new System.Drawing.Point(255, 64);
            this.BoxIp3.Mask = "###";
            this.BoxIp3.Name = "BoxIp3";
            this.BoxIp3.Size = new System.Drawing.Size(28, 20);
            this.BoxIp3.TabIndex = 3;
            // 
            // BoxIp2
            // 
            this.BoxIp2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BoxIp2.Location = new System.Drawing.Point(221, 64);
            this.BoxIp2.Mask = "###";
            this.BoxIp2.Name = "BoxIp2";
            this.BoxIp2.Size = new System.Drawing.Size(28, 20);
            this.BoxIp2.TabIndex = 2;
            // 
            // BoxIp1
            // 
            this.BoxIp1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BoxIp1.Location = new System.Drawing.Point(187, 64);
            this.BoxIp1.Mask = "###";
            this.BoxIp1.Name = "BoxIp1";
            this.BoxIp1.Size = new System.Drawing.Size(28, 20);
            this.BoxIp1.TabIndex = 1;
            // 
            // comboBoxTCP
            // 
            this.comboBoxTCP.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBoxTCP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTCP.FormattingEnabled = true;
            this.comboBoxTCP.Items.AddRange(new object[] {
            "15015"});
            this.comboBoxTCP.Location = new System.Drawing.Point(186, 104);
            this.comboBoxTCP.Name = "comboBoxTCP";
            this.comboBoxTCP.Size = new System.Drawing.Size(130, 21);
            this.comboBoxTCP.TabIndex = 5;
            // 
            // AnnulerConfig
            // 
            this.AnnulerConfig.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.AnnulerConfig.Location = new System.Drawing.Point(241, 167);
            this.AnnulerConfig.Name = "AnnulerConfig";
            this.AnnulerConfig.Size = new System.Drawing.Size(75, 23);
            this.AnnulerConfig.TabIndex = 7;
            this.AnnulerConfig.Text = "Annuler";
            this.AnnulerConfig.UseVisualStyleBackColor = true;
            // 
            // CreerConfig
            // 
            this.CreerConfig.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CreerConfig.Location = new System.Drawing.Point(125, 167);
            this.CreerConfig.Name = "CreerConfig";
            this.CreerConfig.Size = new System.Drawing.Size(75, 23);
            this.CreerConfig.TabIndex = 6;
            this.CreerConfig.Text = "Créer";
            this.CreerConfig.UseVisualStyleBackColor = true;
            this.CreerConfig.Click += new System.EventHandler(this.CreerConfig_Click);
            // 
            // labelNomRover
            // 
            this.labelNomRover.AutoSize = true;
            this.labelNomRover.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.labelNomRover.Location = new System.Drawing.Point(73, 27);
            this.labelNomRover.Name = "labelNomRover";
            this.labelNomRover.Size = new System.Drawing.Size(80, 13);
            this.labelNomRover.TabIndex = 24;
            this.labelNomRover.Text = "Nom du rover : ";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.labelPort.Location = new System.Drawing.Point(94, 107);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(59, 13);
            this.labelPort.TabIndex = 23;
            this.labelPort.Text = "Port TCP : ";
            // 
            // labelAdrIP
            // 
            this.labelAdrIP.AutoSize = true;
            this.labelAdrIP.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.labelAdrIP.Location = new System.Drawing.Point(86, 67);
            this.labelAdrIP.Name = "labelAdrIP";
            this.labelAdrIP.Size = new System.Drawing.Size(67, 13);
            this.labelAdrIP.TabIndex = 22;
            this.labelAdrIP.Text = "Adresse IP : ";
            // 
            // BoxNomRover
            // 
            this.BoxNomRover.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BoxNomRover.Location = new System.Drawing.Point(186, 27);
            this.BoxNomRover.Name = "BoxNomRover";
            this.BoxNomRover.Size = new System.Drawing.Size(150, 20);
            this.BoxNomRover.TabIndex = 0;
            // 
            // AjoutRover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WifiBotForms.Properties.Resources.terrain2;
            this.ClientSize = new System.Drawing.Size(418, 244);
            this.Controls.Add(this.BoxIp4);
            this.Controls.Add(this.BoxIp3);
            this.Controls.Add(this.BoxIp2);
            this.Controls.Add(this.BoxIp1);
            this.Controls.Add(this.comboBoxTCP);
            this.Controls.Add(this.AnnulerConfig);
            this.Controls.Add(this.CreerConfig);
            this.Controls.Add(this.labelNomRover);
            this.Controls.Add(this.labelPort);
            this.Controls.Add(this.labelAdrIP);
            this.Controls.Add(this.BoxNomRover);
            this.Name = "AjoutRover";
            this.Text = "Ajouter un rover";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox BoxIp4;
        private System.Windows.Forms.MaskedTextBox BoxIp3;
        private System.Windows.Forms.MaskedTextBox BoxIp2;
        private System.Windows.Forms.MaskedTextBox BoxIp1;
        private System.Windows.Forms.ComboBox comboBoxTCP;
        private System.Windows.Forms.Button AnnulerConfig;
        private System.Windows.Forms.Button CreerConfig;
        private System.Windows.Forms.Label labelNomRover;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Label labelAdrIP;
        private System.Windows.Forms.TextBox BoxNomRover;
    }
}