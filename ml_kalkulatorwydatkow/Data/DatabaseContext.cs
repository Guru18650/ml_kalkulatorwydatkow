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
        int x = 0;
        public List<DEntry> filtered;
        List<DEntry> testData = new List<DEntry>()
        {
            new DEntry {Name="Bilet miesięczny", Ammount=50, Category="Transport", Date=DateTime.Today.AddDays(-1)},
            new DEntry {Name="Pizza", Ammount=50, Category="Jedzenie", Date=DateTime.Today.AddDays(-1)},
            new DEntry {Name="Kino", Ammount=25, Category="Rozrywka", Date=DateTime.Today.AddDays(-1)},
            new DEntry {Name="Dentysta", Ammount=300, Category="Inne", Date=DateTime.Today.AddDays(-1)},
        };

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
            x = db.Table<DEntry>().Count();
            if (x == 0)
                db.InsertAll(testData);

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
            filtered = entries.Where(i => i.Date >= from && i.Date <= to).ToList();
            if (filtr != "Wszystko")
                filtered = filtered.Where(i => i.Category == filtr).ToList();
            return filtered;
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

        public void clearTable() { 
            db.DeleteAll<DEntry>();
        }

    }

}
