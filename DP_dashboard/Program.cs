using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DP_dashboard
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

            if (Properties.Settings.Default.StationType == "CalibrationStation")
            {
                Application.Run(new CalibForm());
            }
            else if (Properties.Settings.Default.StationType == "ProgramStation")
            {
               Application.Run(new StartForm());
            }


        }
    }
}
