using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainRepository.DBTables
{
    public class ContaminationTest : Table
    {
        public static string Name => "Contamination_Test";
        public static string IdFieldName => "Contamination_Test_Id";
        public override string TableName => "Contamination_Test";
        public override TableField IdField => new TableField("Contamination_Test_Id", System.Data.SqlDbType.Binary, 8);
        private static TableField[] fields;     
        public override IEnumerable<TableField> Fields { get; } = new TableField[]
            {
                new TableField("Test_Name", System.Data.SqlDbType.NVarChar),
                new TableField("Cleaning_Trial_Id", System.Data.SqlDbType.Binary, 8)
            };
    }
}
