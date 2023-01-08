using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KorteksKantar
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);

            String[] CmdLine = Environment.CommandLine.Split(' ');

            bool PanelAc = false;

            foreach (string item in CmdLine)
            {
                if (item.ToUpperInvariant() == "/SETUP")
                {
                    PanelAc = true;
                }
            }

            if (PanelAc)
            {
                Application.Run(new FrmKorteksKantar());
            }
            else
            {
                Application.Run(new FrmKorteksKantar("Tartim"));
            }

        }
    }
}
