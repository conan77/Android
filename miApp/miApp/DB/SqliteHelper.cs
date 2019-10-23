using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using miApp.DB.Models;
using SQLite;
using Xamarin.Forms;

namespace miApp.DB
{
    public class SqliteHelper
    {
        public static readonly SqliteHelper Instance = new SqliteHelper();
        private SQLiteConnection db;
        
        private SqliteHelper()
        {
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "settings.db");
            db=new SQLiteConnection(path);
        }

        public void Init()
        {
            try
            {
                db.Get<settings>("settings");
            }
            catch
            {
                // 不存在，新建
                db.CreateTable<settings>();
            }
        }

    }
}