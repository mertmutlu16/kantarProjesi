using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kantar_b
{
    class Program
    {

        static System.IO.Ports.SerialPort Kantar;

        static System.IO.Ports.SerialDataReceivedEventArgs LastPortDataReceived;
       
        static string Kantar_StringVarmi = "EVET";

        static string Kantar_String = "A";

        static string Kantar_Port = "COM1";

        static string Kantar_Directory = @"C:\KORWOS\Paketleme.OZC\Kantar";

        static string Kantar_File = @"KGH.OZC";

        static string KantarKgOutFile
        {
            get
            {
                return Kantar_Directory + "\\" + Kantar_File;
            }
        }

        static int SayTekrar = 0;

        static string KantardanGelenVeri = ";0:";

        static Boolean KantarDatasiGeldimi = false;

        static void Main(string[] args)
        {


            try
            {
                Console.WriteLine("Kantar Hazırlanıyor Version 1.0.2");

                ConfigOku();


                //byte Emir = (byte)Kantar_String[0];

                //Console.WriteLine("Okuma Kodu : {0}", Emir);

                //Console.ReadLine();

                //return;

                if (File.Exists(KantarKgOutFile)) File.Delete(KantarKgOutFile);

                Kantar = new System.IO.Ports.SerialPort();

                Kantar.PortName = Kantar_Port;

                Kantar.Open();

                Kantar.DataReceived += KantarSeriPort_DataReceived;

                //KantarOku_YontemA();

                Kantar_Oku_Opals();

                Kantar.Close();

                Console.WriteLine("Kantar Okuma Tamamlandı");
                

            }
            catch (Exception Ex)
            {

                WriteErrorMsg = Ex.Message;
                
            }
        }

        static void Kantar_Oku_Opals()
        {
            try
            {
                Console.WriteLine("Kantar Okuma Başladı");

                if (Kantar_StringVarmi == "EVET")
                {
                    byte Emir = (byte)Kantar_String[0];

                    Console.WriteLine("Okuma Kodu : {0}", Emir);

                    //byte[] EmirKantarAc = new byte[] { 65, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

                    byte[] EmirKantarAc = new byte[] { Emir, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

                    foreach (byte item in EmirKantarAc)
                    {
                        Console.Write("{0}", item);
                    }

                    byte[] VeriKantar = new byte[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

                    if (Kantar.IsOpen) Kantar.Close();

                    KantarDatasiGeldimi = false;

                    Kantar.Open();


                    KantardanGelenVeri = ";0:";

                    Kantar.Write(EmirKantarAc, 0, 15);

                    int TekrarSayisi = 0;

                    while (!KantarDatasiGeldimi && TekrarSayisi < 900)
                    {
                        TekrarSayisi++;

                        Console.WriteLine("Waiting .. {0}", TekrarSayisi);

                        System.Threading.Thread.Sleep(10);

                    }

                    if (!KantarDatasiGeldimi)
                    {
                        WriteErrorMsg = "Kantar Bekleme Suresi Sona Erdi...";

                        return;
                    }

                    System.Threading.Thread.Sleep(200);


                    if (KantarDatasiGeldimi)
                    {
                        string KantarKgDegeri = KgParcala(KantardanGelenVeri);

                        if (KgVar)
                        {
                            KgYazFile = KantarKgDegeri;
                        }
                        else
                        {
                            KgYazFile = "0";
                        }

                        
                    }

                    //Console.WriteLine("Emir {0}", EmirKantarAc.ToString());

                    //Console.WriteLine("Veri {0}",VeriKantar);

                    //VeriKantar = KantardanGelenVeri

                    if (VeriKantar[0] == 59 && VeriKantar[8] == 58)
                    {
                        Console.WriteLine("Okuma Çözümleniyor");

                        string YKntr = ((char)VeriKantar[1]).ToString() +
                                       ((char)VeriKantar[2]).ToString() +
                                       ((char)VeriKantar[3]).ToString() +
                                       ((char)VeriKantar[4]).ToString() +
                                       ((char)VeriKantar[5]).ToString() +
                                       ((char)VeriKantar[6]).ToString() +
                                       ((char)VeriKantar[7]).ToString();

                        KgYazFile = YKntr;

                        Console.WriteLine("KG - YKntr :  {0}", YKntr);

                    }
                    else
                    {
                        Console.WriteLine("KG - Hatalı Veri :  {0}", VeriKantar);
                    }


                }


            }
            catch (Exception Ex)
            {

                WriteErrorMsg = Ex.Message;

            }
        }

        static void KantarOku_YontemA()
        {


            if (Kantar_StringVarmi == "EVET")
            {
                Console.WriteLine("Kanatara Okuma Emri Gönderiliyor. {0}", Kantar_String);

                Kantar.WriteLine(Kantar_String);

                Console.WriteLine("Kanatara Okuma Emri Gönderildi");

                // System.Threading.Thread.Sleep(5500);



                string Kg = Kantar.ReadExisting();

                Console.WriteLine("Gelen Değer {0}", Kg);

                Kg = Kantar.ReadLine();

                Console.WriteLine("Gelen Değer 2-  {0}", Kg);


            }

            // Console.ReadLine();
            while (SayTekrar < 10 && !KgVar)
            {
                System.Threading.Thread.Sleep(1500);

                Console.WriteLine("Bekleniyor ... {0}", SayTekrar);

                SayTekrar++;
            }
        }

        static string WriteErrorMsg
        {
            set
            {
                Console.WriteLine( value );

                Console.ReadLine();
            }
        }

        static Boolean KgVar = false;

        static private string KgParcala(string Veri)
        {
            KgVar = false;

            string[] EskiKantar = Veri.Split(';');

            if (EskiKantar.Length == 2)
            {
                // KgVar = true;

                string[] KgEskiDeger = EskiKantar[1].Split(':');

                if (KgEskiDeger.Length == 2)
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

        static private string KgYazFile //(string KgValue)
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
                catch (Exception Ex)
                {

                    WriteErrorMsg = Ex.Message;

                }
            }
        }

        static private void KantarSeriPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                LastPortDataReceived = e;

                Console.WriteLine("Kantar Verisi Geldi - DataReceived [e]->{0}",e.EventType);

                //string GelenMesaj = Kantar.ReadExisting();

                KantardanGelenVeri = Kantar.ReadExisting();

                Console.WriteLine("DataReceived ->[GelenMesaj] {0}", KantardanGelenVeri);

                KantarDatasiGeldimi = true;


                //if (File.Exists(KantarKgOutFile)) File.Delete(KantarKgOutFile);

                //string GelenMesaj = Kantar.ReadExisting();

                //Console.WriteLine("Kantar Gelen Veri", GelenMesaj);

                //string KgDegeri = KgParcala(GelenMesaj);

                //if (KgVar)
                //{
                //    KgYazFile = KgDegeri;
                //}

            }
            catch (Exception Ex)
            {

               // Console.WriteLine(Ex.Message);
                WriteErrorMsg = "DataReceived-> " + Ex.Message;


            }
        }

        static public string ConfigOkuA(string Anahtar, string Varsayilan)
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
                //MessageBox.Show(Ex.Message);

                WriteErrorMsg = Ex.Message;

                return Varsayilan;
            }


        }

        static public void ConfigOku()
        {
            try
            {

                Kantar_Directory = ConfigOkuA("Kantar_Directory", "C:\\KORWOS");

                Kantar_File = ConfigOkuA("Kantar_File", "KWKantar.TXT");

                Kantar_Port = ConfigOkuA("Kantar_Port", "COM1");

                Kantar_StringVarmi = ConfigOkuA("Kantar_StringVarmi", "EVET");

                Kantar_String = ConfigOkuA("Kantar_String", "A");

               // OtomatikInterVal = ConfigOkuA("OtomatikInterVal", "500");

            }
            catch (Exception Ex)
            {

               // MessageBox.Show(Ex.Message);
                WriteErrorMsg = Ex.Message;

            }
        }
    }
}
