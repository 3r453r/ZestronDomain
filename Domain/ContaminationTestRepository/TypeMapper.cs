using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainRepository
{
    public static class TypeMapper
    {
        public static Type GetType(SqlDbType dbType)
        {
            switch(dbType)
            {
                case SqlDbType.NVarChar:
                case SqlDbType.VarChar:
                case SqlDbType.Xml:
                    return typeof(string);
                case SqlDbType.DateTime:
                case SqlDbType.DateTime2:
                case SqlDbType.Time:
                case SqlDbType.Date:
                    return typeof(DateTime?);
                case SqlDbType.Bit:
                    return typeof(bool);
                case SqlDbType.Int:
                case SqlDbType.TinyInt:
                    return typeof(int);
                case SqlDbType.Binary:
                case SqlDbType.VarBinary:
                case SqlDbType.Image:
                    return typeof(byte[]);
                case SqlDbType.Float:
                case SqlDbType.Decimal:
                case SqlDbType.Money:
                    return typeof(decimal);
                default:
                    throw new ArgumentException($"Unmapped type: {dbType}");
            }
        }
    }
}
