using System;
using System.Data.SQLite;
using System.IO;
using System.Windows;
using log4net;

namespace Jarvis.Database {
   public class SqlLiteDatabase : Database {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SqlLiteDatabase));

        public SqlLiteDatabase() {
        }
    }
}
