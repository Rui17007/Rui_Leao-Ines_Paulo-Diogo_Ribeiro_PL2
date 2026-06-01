using Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Rui_Leao_Ines_Paulo_Diogo_Ribeiro_PL2
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Database.SetInitializer(new IShoppingInitializer());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                using (var db = new IShopping())
                {

                    db.Database.Initialize(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<IShopping>());
            Application.Run(new Login());
        }
    }
}
