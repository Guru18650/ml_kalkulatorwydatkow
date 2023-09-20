using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ml_kalkulatorwydatkow.Data
{
    [Table("DEntry")]
    public class DEntry
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Ammount { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
    }

    public class SQLiteDbContext
    {
        static string DatabasePath => System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "db.db4");

        SQLiteConnection db;

        public string direction = "Malejąco";
        public DateTime from = DateTime.MinValue;
        public DateTime to = DateTime.Now;
        public string filtr = "Wszystko";
        public string sortType = "Data";
        public int limit = 10;

        /**********************************************
            nazwa funkcji: Init
            opis funkcji: Inicializuje połączenie z bazą danych i wybiera tabele
            parametry: brak, funkcja void
            zwracany typ i opis: brak, funkcja void
            autor: 2137
        ***********************************************/


        void Init()
        {
            var dbPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "db.db3");
            db = new SQLiteConnection(dbPath);
            db.CreateTable<DEntry>();
            if (db.Table<DEntry>().Count() == 0)
            {
                var testEntry = new DEntry()
                {
                    Name = "Test",
                    Ammount = -20f,
                    Date = new DateTime(2023, 2, 5),
                    Category = "Transport"
                };
                var result = db.CreateTable<DEntry>();
                db.Insert(testEntry);
            }
        }
        public List<DEntry> getEntries()
        {
            Init();
            var entries = db.Table<DEntry>().ToList();
            if (sortType == "Data")
                entries.Sort((x, y) => DateTime.Compare(x.Date, y.Date));
            else
                entries = entries.OrderBy(entry => entry.Ammount).ToList();

            if (direction == "Malejąco")
                entries.Reverse();
            if (from == new DateTime())
                from = DateTime.MinValue;
            if (to == new DateTime())
                to = DateTime.MaxValue;
            var filtered = entries.Where(i => i.Date >= from && i.Date <= to);
            if (filtr != "Wszystko")
                filtered = filtered.Where(i => i.Category == filtr);
            return filtered.Take(limit).ToList();
        }

        public void addEntry(DEntry e)
        {
            Init();
            db.Insert(e);
        }

        public void updateEntry(DEntry e) {
            Init();
            db.Update(e);
        }

        public void deleteEntry(DEntry e) {  
            Init(); 
            db.Delete(e); 
        }


    }

}
