using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KorteksKantar
{
    public partial class FrmKorteksKantar : Form
    {

        public delegate void KantardanGelenMesajYaz(string Mesaj);

        void LCDGoster(string KgValue)
        {
            try
            {
                olblLCDKantar.Text = KgValue;
            }
            catch (Exception Ex)
            {

                MesajYaz = " LCDGoster" + Ex.Message;

            }
        }

        void LCDHataYaz(string HataMesaji)
        {
            try
            {
                // olblLCDKantar.Text = KgValue;

                MesajYaz = HataMesaji;

            }
            catch (Exception Ex)
            {

                MesajYaz = " LCDGoster" + Ex.Message;

            }
        }

        private Boolean KgVar = false;

        private string KgParcala(string Veri)
        {
            KgVar = false;

            string[] EskiKantar = Veri.Split(';');

            if (EskiKantar.Length == 2)
            {
               // KgVar = true;

                string[] KgEskiDeger = EskiKantar[1].Split(':');

                if (KgEskiDeger.Length == 2 )
                {
                    KgVar = true;

                    return KgEskiDeger[0];
                }


                //return EskiKantar[1];
            }

            if (Veri.Contains("+") && Veri.Contains("kg"))
            {
                KgVar = true;

                return Veri.Substring(Veri.IndexOf('+') + 1, 7).Trim();

            }

            if (Veri.Contains("-") && Veri.Contains("kg"))
            {
                KgVar = true;

                return Veri.Substring(Veri.IndexOf('-') + 1, 7).Trim();

            }

            return Veri;
        }

        private string  KgYazFile //(string KgValue)
        {
            set
            {
                try
                {
                    if (File.Exists(KantarKgOutFile)) File.Delete(KantarKgOutFile);

                    if (!Directory.Exists(Kantar_Directory)) Path.GetDirectoryName(Kantar_Directory);
                    //string dizin = Path.GetDirectoryName(outputFile);

                    //StreamWriter Swr = new StreamWriter(Kantar_File);
                    StreamWriter Swr = new StreamWriter(KantarKgOutFile);

                    Swr.WriteLine(value);

                    Swr.Flush();

                    Swr.Close();


                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        string MesajYaz
        {
            set
            {
                olsltMesajlar.Items.Insert(0, value);
            }
        }

        string Kantar_StringVarmi = "EVET";

        string Kantar_String = "A";

        string Kantar_Port = "COM1";

        string Kantar_Directory = @"C:\KORWOS\Paketleme.OZC\Kantar";

        string Kantar_File = @"KGH.OZC";

        string KantarKgOutFile
        {
            get
            {
                return Kantar_Directory + "\\" + Kantar_File;
            }
        }

        Boolean OtomatikMod = false;

        string OtomatikInterVal = "500";

        Boolean OtomatikKantarAcikmi = false;


        public FrmKorteksKantar(string ModTartim)
        {
            InitializeComponent();

            ConfigOku();

            KgYazFile = "0";

            olblLCDKantar.Text = "... Waiting ...";

            panel2.Visible = false;

            panel3.Visible = false;

            this.Height = panel1.Height + 45;

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

            this.ControlBox = false;

            OtomatikMod = true;

            tmotomatikTart.Interval = int.Parse(OtomatikInterVal);

            tmotomatikTart.Enabled = true;

            OtomatikKantarAcikmi = false;

            if (Kantar_Baglan() )
            {
                OtomatikKantarAcikmi = true;
               
            }

        }

        public FrmKorteksKantar()
        {
            InitializeComponent();

            tmotomatikTart.Enabled = false;

            ConfigOku();

            ocmbPortList.SelectedIndex = 0;

            ShowConfig();


        }

        public void ShowConfig()
        {
            try
            {
                otxtOutputFile.Text = KantarKgOutFile;

                if (Kantar_StringVarmi == "EVET")
                {
                    ordBtn_EVET.Checked = true;
                }

                otxtKantarStr.Text = Kantar_StringVarmi == "EVET" ? Kantar_String : "";

                ocmbPortList.Text = Kantar_Port;


            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);

            }
        }

        public string ConfigOkuA(string Anahtar, string Varsayilan)
        {
            try
            {
                string tmp = ConfigurationManager.AppSettings[Anahtar];

                if (tmp == null)
                {
                    return Varsayilan;
                }


                if (tmp == "")
                {
                    return Varsayilan;
                }

                return tmp;

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                
                return Varsayilan;
            }
            

        }

        public void ConfigOku()
        {
            try
            {

                Kantar_Directory = ConfigOkuA("Kantar_Directory", "C:\\KORWOS");

                Kantar_File = ConfigOkuA("Kantar_File", "KWKantar.TXT");

                Kantar_Port = ConfigOkuA("Kantar_Port", "COM1");

                Kantar_StringVarmi = ConfigOkuA("Kantar_StringVarmi", "EVET");

                Kantar_String = ConfigOkuA("Kantar_String", "A");

                OtomatikInterVal = ConfigOkuA("OtomatikInterVal", "500");

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);

            }
        }

        private void KantarOku()
        {
            try
            {
                if (OtomatikMod)
                {
                    if (Kantar_StringVarmi == "EVET")
                    {

                        KantarSeriPort.WriteLine(Kantar_String);

                    }

                    return;
                }


                if (!KantarSeriPort.IsOpen)
                {
                    MesajYaz = "Kantar Açık Değil ";

                    return;
                }

                KantarSeriPort.WriteLine(otxtKantarStr.Text);

                MesajYaz = "Mesaj Gönderildi";


            }
            catch (Exception Ex)
            {

                MesajYaz = Ex.Message;
            }
        }

        private void KantarSeriPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                                
                //e.EventType == System.IO.Ports.SerialData.
                olsltMesajlar.Invoke(new KantardanGelenMesajYaz(LCDGoster), "000");

                if (File.Exists(KantarKgOutFile)) File.Delete(KantarKgOutFile);

                string GelenMesaj = KantarSeriPort.ReadExisting();

                string KgDegeri = KgParcala(GelenMesaj);

                if (KgVar)
                {
                    olsltMesajlar.Invoke(new KantardanGelenMesajYaz(LCDGoster), KgDegeri);

                    KgYazFile = KgDegeri;

                    if (OtomatikMod)
                    {
                        KantarSeriPort.Close();

                        tmotomatikTart.Enabled = false;

                        this.Close();

                        return;
                    }
                }
                else
                {
                    olsltMesajlar.Invoke(new KantardanGelenMesajYaz(LCDGoster), "Error");

                    olsltMesajlar.Invoke(new KantardanGelenMesajYaz(LCDHataYaz), GelenMesaj);
                }

            }
            catch (Exception Ex)
            {

                olsltMesajlar.Invoke(new KantardanGelenMesajYaz(LCDHataYaz), Ex.Message);

            }
        }

        private Boolean Kantar_Baglan()
        {
            try
            {
                if (KantarSeriPort.IsOpen) return true;

                KantarSeriPort.PortName = Kantar_Port; // ocmbPortList.Text;

                KantarSeriPort.Open();

                return true;
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);

                return false;
            }
        }

        private void BtnBaglan_Click(object sender, EventArgs e)
        {
            try
            {
                //if (KantarSeriPort.IsOpen)
                //{
                //    MesajYaz = "Kantar Zaten Açık";

                //    return;
                //}

                if (!Kantar_Baglan() )
                {
                    return;
                }

                MesajYaz = string.Format("Kantar Açıldı. Port No", KantarSeriPort.PortName);

                BtnBaglantiyiKes.Visible = true;

            }
            catch (Exception Ex)
            {

                MesajYaz = "Bağlantı Açarken Hata " + Ex.Message;
            }
        }

        private void BtnBaglantiyiKes_Click(object sender, EventArgs e)
        {
            try
            {
                if (!KantarSeriPort.IsOpen)
                {
                    MesajYaz = "Kantar Zaten Kapalı";

                    return;
                }

                KantarSeriPort.Close();

                MesajYaz = "Kantar Kapatıldı";

                BtnBaglantiyiKes.Visible = false;

            }
            catch (Exception Ex)
            {

                MesajYaz = "Bağlantı Açarken Hata " + Ex.Message;
            }
        }

        private void BtnKantaraGonder_Click(object sender, EventArgs e)
        {
            KantarOku();
        }

        private void BtnAyarKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigurationManager.AppSettings.Add("Kantar_Directory", "C:\\KORWOSX");

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);

            }
        }

        private void olblLCDKantar_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tmotomatikTart_Tick(object sender, EventArgs e)
        {
            try
            {
                olblLCDKantar.Text = "... Wait ...";

                if(! OtomatikKantarAcikmi)
                {
                    Application.DoEvents();

                    System.Threading.Thread.Sleep(100);

                    Application.Exit();

                    return;
                }

                KantarOku();

                olblLCDKantar.Text = "... Waiting ...";

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);

            }
        }

        private void olsltMesajlar_DoubleClick(object sender, EventArgs e)
        {
            otxtKantarStr.Text = olsltMesajlar.Items[0].ToString();
        }
    }
}
