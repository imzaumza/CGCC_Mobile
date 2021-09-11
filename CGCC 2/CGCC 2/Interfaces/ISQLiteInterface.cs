using SQLite;
//sing SQLite.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace CGCC_2.Interfaces
{
    public interface ISQLiteInterface
    {
        SQLiteConnection GetSQLiteConnection();
    }
}
