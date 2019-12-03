using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainRepository.DBTables
{
    public class CleaningTrial : Table
    {
        public static string Name => "Cleaning_Trial";
        public static string IdFieldName => "Cleaning_Trial_Id";
        public override string TableName => "Cleaning_Trial";
        public override TableField IdField => new TableField("Cleaning_Trial_Id", System.Data.SqlDbType.Binary, 8);
        private static TableField[] fields;
        public override IEnumerable<TableField> Fields { get; } = new TableField[]
            {
                new TableField("Trial_Name", System.Data.SqlDbType.NVarChar),
                new TableField("Company_Id", System.Data.SqlDbType.Binary, 8)
            };
    }
}
