using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace util.lib
{
    internal static class List
    {
        public static List<T> DataTableToList<T>(this DataTable dt) where T : class, new()
        {
            List<T> Result = new List<T>();
            List<PropertyInfo> ps = new List<PropertyInfo>();

            foreach (PropertyInfo p in typeof(T).GetProperties())
                ps.Add(p);

            foreach (DataRow Row in dt.Rows)
            {
                T obj = new T();
                foreach (PropertyInfo p in ps)
                {
                    if (dt.Columns.IndexOf(p.Name) != -1 && Row[p.Name] != DBNull.Value) 
                        p.SetValue(obj, Row[p.Name], null);
                }
                Result.Add(obj);
            }

            return Result;
        }

        public static List<T> DataRowToList<T>(this DataRow[] Rows) where T : class, new()
        {
            List<T> Result = new List<T>();
            List<PropertyInfo> ps = new List<PropertyInfo>();

            foreach (PropertyInfo p in typeof(T).GetProperties())
                ps.Add(p);

            foreach (DataRow Row in Rows)
            {
                T obj = new T();
                foreach (PropertyInfo p in ps)
                {
                    if (Row.Table.Columns.IndexOf(p.Name) != -1 && Row[p.Name] != DBNull.Value)
                        p.SetValue(obj, Row[p.Name], null);
                }
                Result.Add(obj);
            }

            return Result;
        }

        public static T DataTableToObj<T>(this DataTable dt) where T : class, new() 
        {
            T obj = new T();

            if (dt.Rows.Count > 0) {
                List<PropertyInfo> ps = new List<PropertyInfo>();
                foreach (PropertyInfo p in typeof(T).GetProperties())
                    ps.Add(p);


                foreach (PropertyInfo p in ps)
                {
                    if (dt.Columns.IndexOf(p.Name) != -1 && dt.Rows[0][p.Name] != DBNull.Value)
                        p.SetValue(obj, dt.Rows[0][p.Name], null);
                }
            }
            
            return obj;
        }
    }
}
