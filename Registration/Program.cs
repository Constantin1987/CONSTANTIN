using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Registration
{

    public static class us

    {
        public static string emaill,fname,sname ,of1,of2,of3,of4,of5,h1,h2,h3,h4;

        //311 
        public static string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Constantin\\Desktop\\New folder\\EnigmaProject\\Enigma\\Registration\\EnigmaDB.mdf;Integrated Security=True;Connect Timeout=30";
        //308
        // public static string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=H:\\EnigmaProject\\Enigma\\Registration\\EnigmaDB.mdf;Integrated Security=True;Connect Timeout=30";
        //304
       // public static string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=H:\\EnigmaProject\\Enigma\\Registration\\EnigmaDB.mdf;Integrated Security=True;Connect Timeout=30";
        //home
       //public static string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\kostika\\Desktop\\EnigmaProject\\Enigma\\Registration\\EnigmaDB.mdf;Integrated Security=True;Connect Timeout=30";


    }
    public static class a

    {
        public static int of11,of22,of33,of44,of55,h11,h22,h33,h44,minim1, minim2, minim3, minim4;
    }

    public static class d
    {
        public static double point;
    }
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
            Application.Run(new Start1());
        }
    }
}
