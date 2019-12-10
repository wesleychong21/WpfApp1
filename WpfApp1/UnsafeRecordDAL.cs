using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiteDB;

namespace WpfApp1
{
    class UnsafeRecordDAL : IDisposable
    {
        LiteDatabase db;

        public UnsafeRecordDAL()
        {
            db = new LiteDatabase(@"UnsafeRecords.db");
        }

        public int Create(UnsafeRecord _record)
        {
            try
            {
                var reports = db.GetCollection<UnsafeRecord>("UnsafeRecords");

                // Insert new customer document (Id will be auto-incremented)
                return reports.Insert(_record);
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
