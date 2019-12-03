using CdcSoftware.Pivotal.Applications.Core.Server;
using CdcSoftware.Pivotal.Engine;
using CdcSoftware.Pivotal.Engine.Server;
using Domain.Persistence;
using DomainRepository.DBTables;
using DomainRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(DataAccess dataAccess, SystemServer systemServer, Table[] tables)
        {
            DataAccess = dataAccess;
            SystemServer = systemServer;
            Tables = tables;
            ContaminationTestRepository = new ContaminationTestRepository(this);
        }

        private SystemServer SystemServer { get; }
        private DataAccess DataAccess { get; }
        private List<DataRow> RowsToSave { get; } = new List<DataRow>();
        private Table[] Tables { get; }
        public List<Binding> Bindings { get; } = new List<Binding>();
        public IContaminationTestRepository ContaminationTestRepository { get; } 

        public void SaveChanges()
        {
            SavingChanges();

            if(Bindings.Any())
            {
                var saveOrderList = CreateSavingOrder(Bindings, RowsToSave);
                for (int i = 0; i < saveOrderList.Count; i++ )
                {
                    DataAccess.SaveDataTable(saveOrderList[i]);
                    UpdateBindingsAndSavingOrder(Bindings, saveOrderList, i);
                }
            }
            else
            {
                foreach (DataTable table in DataSet.Tables)
                {
                    DataAccess.SaveDataTable(table);
                }
            }

            foreach(DataTable table in DeletionsDataSet.Tables)
            {
                DataAccess.DeleteDataTable(table);
            }

            ChangesSaved();
        }

        private List<DataTable> CreateSavingOrder(List<Binding> bindings, DataSet dataSet)
        {
            return new List<DataTable>();
        }

        private void UpdateBindingsAndSavingOrder(List<Binding> bindings, List<DataTable> savingOrder, int currentIndex)
        {
            var bindingsToRemove = new List<Binding>();
            var rowsToRemove = new List<DataRow>();
            for (int i = 0; i < currentIndex; i++)
            {
                var dataTable = savingOrder[i];
                foreach(DataRow row in dataTable.Rows)
                {
                    var bindingsWithRowAsPrimaryRow = bindings.Where(b => b.PrimaryRow.Equals(row));
                    foreach(var binding in bindingsWithRowAsPrimaryRow)
                    {
                        binding.SecondaryRow[binding.SecondaryRowBindingFieldName] = binding.PrimaryRow[binding.PrimaryRowIdFieldName];
                        bindingsToRemove.Add(binding);
                    }

                    foreach(var binding in bindingsToRemove)
                    {
                        bindings.Remove(binding);
                    }
                    bindingsToRemove.Clear();

                    var anyBindingsWithRowAsSecondaryRow = bindings.Any(b => b.SecondaryRow.Equals(row));
                    if (!anyBindingsWithRowAsSecondaryRow)
                        rowsToRemove.Add(row);
                }


            }
        }

        public event Action ChangesSaved;

        public event Action SavingChanges;

        public DataRow GetDataRow(string tableName, byte[] recordId)
        {
            DataRow result;
            if (!DataSet.Tables.Contains(tableName))
            {
                result = DataAccess.GetDataRow(tableName, Id.Create(recordId), GetAllColumnNames(tableName));
                DataAccess.GetDataTable();
                DataSet.Tables.Add(result.Table);
            }
            else
            {
                result
            }


            return result;
        }

        public DataRow GetDataRowAsNoTracking(string tableName, byte[] recordId)
        {
            if (!DataSet.Tables.Contains(tableName))
                DataSet.Tables.Add(InitializeTable(tableName));

            var row = DataAccess.GetDataRow(tableName, Id.Create(recordId), GetAllColumnNames(tableName));

            

            return row;
        }

        public void DeleteDataRow(string tableName, byte[] recordId)
        {
            if (!DeletionsDataSet.Tables.Contains(tableName))
                DeletionsDataSet.Tables.Add(InitializeTable(tableName, true));

            var row = DeletionsDataSet.Tables[tableName].NewRow();

            row[Tables.Single(t => t.TableName == tableName).IdField.Name] = recordId;
                
            DeletionsDataSet.Tables[tableName].Rows.Add(row);
        }

        public DataRow GetNewDataRow(string tableName)
        {
            var row = DataAccess.GetNewDataRow(tableName, GetAllColumnNames(tableName));
            DataSet.Tables[tableName].Rows.Add(row);

            return row;
        }

        public void CreateBinding(DataRow primaryRow, string bindingFieldName, DataRow secondaryRow)
        {
            Bindings.Add(new Binding(primaryRow, bindingFieldName
                , secondaryRow, Tables.Single(t => t.TableName == secondaryRow.Table.TableName).IdField.Name));
        }

        private DataTable InitializeTable(string tableName, bool forDeleteDataSet = false)
        {
            var table = Tables.Single(t => t.TableName == tableName);

            var result = new DataTable(table.TableName);
            result.Columns.Add(table.IdField.Name, TypeMapper.GetType(table.IdField.SqlDbType));

            if(!forDeleteDataSet)
                foreach(var field in table.Fields)
                {
                    result.Columns.Add(field.Name, TypeMapper.GetType(field.SqlDbType));
                }

            return result;
        }

        private string[] GetAllColumnNames(string tableName)
        {
            var columnNames = new List<string>();
            foreach(DataColumn column in DataSet.Tables[tableName].Columns)
            {
                columnNames.Add(column.ColumnName);
            }

            return columnNames.ToArray();
        }
    }
}
