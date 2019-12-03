using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainRepository.DBTables
{
    public abstract class Table
    {
        public virtual string TableName { get; }
        public virtual TableField IdField { get; }
        public virtual IEnumerable<TableField> Fields { get; }
    }
}
