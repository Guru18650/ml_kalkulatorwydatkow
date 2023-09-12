using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace ml_kalkulatorwydatkow
{
    internal class DataHandler
    {
        static string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "db.db3");

        SQLiteConnection db = new SQLiteConnection(dbPath);

    }
}