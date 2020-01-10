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

        private const string TableName = "UnsafeRecords";

        public UnsafeRecordDAL()
        {
            db = new LiteDatabase(@"UnsafeRecords.db");
        }

        public int Create(UnsafeRecord _record)
        {
            try
            {
                var reports = db.GetCollection<UnsafeRecord>(TableName);

                // Insert new customer document (Id will be auto-incremented)
                return reports.Insert(_record);
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public bool Update(UnsafeRecord _record)
        {
            try
            {
                var reports = db.GetCollection<UnsafeRecord>(TableName);
                return reports.Update(_record);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<UnsafeRecord> RetrieveAll()
        {
            try
            {
                var reports = db.GetCollection<UnsafeRecord>(TableName);
                return reports.FindAll().ToList();
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public int Delete(int _id) {
            try
            {
                var reports = db.GetCollection<UnsafeRecord>(TableName);
                return reports.Delete(r => r.Id == _id);
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
