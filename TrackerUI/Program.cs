using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TournamentTracker;
using TrackerUI;
using System.Net;
using System.Net.Mail;

namespace ApplicationUI
{
    static class Program
    {
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            TournamentTracker.GlobalConfig.InitializeConnections(TrackerLibrary.DatabaseType.Sql);
            Application.Run(new TournamentDashboardForm());
        }
    }
}