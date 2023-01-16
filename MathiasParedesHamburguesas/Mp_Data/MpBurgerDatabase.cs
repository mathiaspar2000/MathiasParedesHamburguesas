using System;
using SQLite;
using MathiasParedesHamburguesas.Mp_Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathiasParedesHamburguesas.Mp_Data
{
    public class MpBurgerDatabase
    {
        string _dbPath;
        private SQLiteConnection conn;
        public MpBurgerDatabase(string DatabasePath)
        {
            _dbPath = DatabasePath;
        }

        private void Init()
        {
            if (conn != null)
                return;
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<MpBurger>();
        }
        public int AddNewBurger(MpBurger Mpburger)
        {
            //Init();
            //int result = conn.Insert(Mpburger);
            //return result;
            if (Mpburger.Id !=0)
            {
                return conn.Update(Mpburger);
            }
            return conn.Insert(Mpburger);
        }

        public List<MpBurger> GetAllBurgers()
        {
            Init();
            List<MpBurger> Mpburgers = conn.Table<MpBurger>().ToList();
            return Mpburgers;
        }

        public MpBurger getID(int id)
        {
            Init();
            var Mpburger = from b in conn.Table<MpBurger>()
                         where b.Id == id
                         select b;

            return Mpburger.FirstOrDefault();
        }
        public void updateData(int id, string name, string description, bool haveCheese)
        {
            Init();
            var Mpburger = conn.Table<MpBurger>().Where(r => r.Id == id).FirstOrDefault();
            if (Mpburger != null)
            {
                Mpburger.Name = name;
                Mpburger.Description = description;
                Mpburger.WithExtraCheese = haveCheese;

                conn.Update(Mpburger);
            }
        }
        public int deleteBurger(MpBurger Item)
        {
            Init();
            return conn.Delete(Item);   
        }
    }
}
