using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainRepository.DBTables
{
    public class TableField
    {
        public TableField(string name, SqlDbType type, int length = 0)
        {
            Name = name;
            SqlDbType = type;
            Length = length;
        }

        public string Name { get; }
        public SqlDbType SqlDbType { get; }
        public int Length { get; }
    }
}
