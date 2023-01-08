namespace KorteksKantar
{
    partial class FrmKorteksKantar
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.olblLCDKantar = new System.Windows.Forms.Label();
            this.KantarSeriPort = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ocmbPortList = new System.Windows.Forms.ComboBox();
            this.otxtOutputFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.otxtKantarStr = new System.Windows.Forms.TextBox();
            this.BtnKantaraGonder = new System.Windows.Forms.Button();
            this.BtnAyarKaydet = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnBaglantiyiKes = new System.Windows.Forms.Button();
            this.BtnBaglan = new System.Windows.Forms.Button();
            this.olsltMesajlar = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ordBtn_EVET = new System.Windows.Forms.RadioButton();
            this.ordBtn_HAYIR = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tmotomatikTart = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.olblLCDKantar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(673, 81);
            this.panel1.TabIndex = 0;
            // 
            // olblLCDKantar
            // 
            this.olblLCDKantar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.olblLCDKantar.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.olblLCDKantar.Location = new System.Drawing.Point(0, 0);
            this.olblLCDKantar.Name = "olblLCDKantar";
            this.olblLCDKantar.Size = new System.Drawing.Size(671, 79);
            this.olblLCDKantar.TabIndex = 0;
            this.olblLCDKantar.Text = "000,000";
            this.olblLCDKantar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.olblLCDKantar.DoubleClick += new System.EventHandler(this.olblLCDKantar_DoubleClick);
            // 
            // KantarSeriPort
            // 
            this.KantarSeriPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.KantarSeriPort_DataReceived);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seri Port :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Text File :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ocmbPortList
            // 
            this.ocmbPortList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ocmbPortList.FormattingEnabled = true;
            this.ocmbPortList.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10"});
            this.ocmbPortList.Location = new System.Drawing.Point(187, 17);
            this.ocmbPortList.Name = "ocmbPortList";
            this.ocmbPortList.Size = new System.Drawing.Size(109, 28);
            this.ocmbPortList.TabIndex = 3;
            // 
            // otxtOutputFile
            // 
            this.otxtOutputFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.otxtOutputFile.Location = new System.Drawing.Point(186, 50);
            this.otxtOutputFile.Name = "otxtOutputFile";
            this.otxtOutputFile.Size = new System.Drawing.Size(332, 26);
            this.otxtOutputFile.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(13, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Kantar String :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // otxtKantarStr
            // 
            this.otxtKantarStr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.otxtKantarStr.Location = new System.Drawing.Point(186, 125);
            this.otxtKantarStr.Name = "otxtKantarStr";
            this.otxtKantarStr.Size = new System.Drawing.Size(148, 26);
            this.otxtKantarStr.TabIndex = 6;
            this.otxtKantarStr.Text = "A";
            // 
            // BtnKantaraGonder
            // 
            this.BtnKantaraGonder.Location = new System.Drawing.Point(369, 93);
            this.BtnKantaraGonder.Name = "BtnKantaraGonder";
            this.BtnKantaraGonder.Size = new System.Drawing.Size(149, 54);
            this.BtnKantaraGonder.TabIndex = 7;
            this.BtnKantaraGonder.Text = "Kantara Gönder";
            this.BtnKantaraGonder.UseVisualStyleBackColor = true;
            this.BtnKantaraGonder.Click += new System.EventHandler(this.BtnKantaraGonder_Click);
            // 
            // BtnAyarKaydet
            // 
            this.BtnAyarKaydet.Location = new System.Drawing.Point(370, 17);
            this.BtnAyarKaydet.Name = "BtnAyarKaydet";
            this.BtnAyarKaydet.Size = new System.Drawing.Size(149, 29);
            this.BtnAyarKaydet.TabIndex = 8;
            this.BtnAyarKaydet.Text = "Ayarları Kaydet";
            this.BtnAyarKaydet.UseVisualStyleBackColor = true;
            this.BtnAyarKaydet.Visible = false;
            this.BtnAyarKaydet.Click += new System.EventHandler(this.BtnAyarKaydet_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnBaglantiyiKes);
            this.panel2.Controls.Add(this.BtnBaglan);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 81);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(673, 41);
            this.panel2.TabIndex = 9;
            // 
            // BtnBaglantiyiKes
            // 
            this.BtnBaglantiyiKes.Location = new System.Drawing.Point(185, 6);
            this.BtnBaglantiyiKes.Name = "BtnBaglantiyiKes";
            this.BtnBaglantiyiKes.Size = new System.Drawing.Size(142, 29);
            this.BtnBaglantiyiKes.TabIndex = 9;
            this.BtnBaglantiyiKes.Text = "Bağlantıyı Kapat";
            this.BtnBaglantiyiKes.UseVisualStyleBackColor = true;
            this.BtnBaglantiyiKes.Visible = false;
            this.BtnBaglantiyiKes.Click += new System.EventHandler(this.BtnBaglantiyiKes_Click);
            // 
            // BtnBaglan
            // 
            this.BtnBaglan.Location = new System.Drawing.Point(15, 6);
            this.BtnBaglan.Name = "BtnBaglan";
            this.BtnBaglan.Size = new System.Drawing.Size(138, 28);
            this.BtnBaglan.TabIndex = 9;
            this.BtnBaglan.Text = "Bağlan";
            this.BtnBaglan.UseVisualStyleBackColor = true;
            this.BtnBaglan.Click += new System.EventHandler(this.BtnBaglan_Click);
            // 
            // olsltMesajlar
            // 
            this.olsltMesajlar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.olsltMesajlar.FormattingEnabled = true;
            this.olsltMesajlar.ItemHeight = 16;
            this.olsltMesajlar.Location = new System.Drawing.Point(0, 162);
            this.olsltMesajlar.Name = "olsltMesajlar";
            this.olsltMesajlar.Size = new System.Drawing.Size(673, 276);
            this.olsltMesajlar.TabIndex = 10;
            this.olsltMesajlar.DoubleClick += new System.EventHandler(this.olsltMesajlar_DoubleClick);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(13, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Kantar String Varmı :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ordBtn_EVET
            // 
            this.ordBtn_EVET.AutoSize = true;
            this.ordBtn_EVET.Location = new System.Drawing.Point(186, 91);
            this.ordBtn_EVET.Name = "ordBtn_EVET";
            this.ordBtn_EVET.Size = new System.Drawing.Size(66, 20);
            this.ordBtn_EVET.TabIndex = 11;
            this.ordBtn_EVET.TabStop = true;
            this.ordBtn_EVET.Text = "EVET";
            this.ordBtn_EVET.UseVisualStyleBackColor = true;
            // 
            // ordBtn_HAYIR
            // 
            this.ordBtn_HAYIR.AutoSize = true;
            this.ordBtn_HAYIR.Location = new System.Drawing.Point(262, 91);
            this.ordBtn_HAYIR.Name = "ordBtn_HAYIR";
            this.ordBtn_HAYIR.Size = new System.Drawing.Size(72, 20);
            this.ordBtn_HAYIR.TabIndex = 11;
            this.ordBtn_HAYIR.TabStop = true;
            this.ordBtn_HAYIR.Text = "HAYIR";
            this.ordBtn_HAYIR.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.olsltMesajlar);
            this.panel3.Controls.Add(this.ordBtn_HAYIR);
            this.panel3.Controls.Add(this.ocmbPortList);
            this.panel3.Controls.Add(this.ordBtn_EVET);
            this.panel3.Controls.Add(this.BtnAyarKaydet);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.otxtOutputFile);
            this.panel3.Controls.Add(this.BtnKantaraGonder);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.otxtKantarStr);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 122);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(673, 438);
            this.panel3.TabIndex = 12;
            // 
            // tmotomatikTart
            // 
            this.tmotomatikTart.Interval = 500;
            this.tmotomatikTart.Tick += new System.EventHandler(this.tmotomatikTart_Tick);
            // 
            // FrmKorteksKantar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 560);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmKorteksKantar";
            this.Text = "Korteks Kantar";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label olblLCDKantar;
        private System.IO.Ports.SerialPort KantarSeriPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ocmbPortList;
        private System.Windows.Forms.TextBox otxtOutputFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox otxtKantarStr;
        private System.Windows.Forms.Button BtnKantaraGonder;
        private System.Windows.Forms.Button BtnAyarKaydet;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnBaglantiyiKes;
        private System.Windows.Forms.Button BtnBaglan;
        private System.Windows.Forms.ListBox olsltMesajlar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton ordBtn_EVET;
        private System.Windows.Forms.RadioButton ordBtn_HAYIR;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Timer tmotomatikTart;
    }
}

