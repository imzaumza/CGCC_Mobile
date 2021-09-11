
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CGCC_2.Interfaces
{
    public interface ISQLite
    {
        SQLiteConnection GetSQLiteConnection();
    }
}
