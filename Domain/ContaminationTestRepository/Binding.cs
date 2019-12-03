using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainRepository
{
    public class Binding
    {
        public Binding(DataRow primaryRow, string primaryRowIdFieldName, DataRow secondaryRow, string secondaryRowBindingFieldName, int saveOrder)
        {
            PrimaryRow = primaryRow;
            PrimaryRowIdFieldName = primaryRowIdFieldName;
            SecondaryRow = secondaryRow;
            SecondaryRowBindingFieldName = secondaryRowBindingFieldName;
            SaveOrder = saveOrder;
        }
        public DataRow PrimaryRow { get; }
        public string PrimaryRowIdFieldName { get; }
        public DataRow SecondaryRow { get; }
        public string SecondaryRowBindingFieldName { get; }
        public int SaveOrder { get; }
    }
}
