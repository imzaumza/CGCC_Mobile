using CGCC_2.Interfaces;
using CGCC_2.iOS;
using Foundation;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(ISQLiteDbInterface_IOS))]
namespace CGCC_2.iOS
{
    public class ISQLiteDbInterface_IOS : ISQLite
    {
        public ISQLiteDbInterface_IOS()
        {

        }
        public SQLiteConnection GetSQLiteConnection()
        {
            var fileName = "Student.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, fileName);

            var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var connection = new SQLiteConnection(path);

            return connection;
        }
    }
}