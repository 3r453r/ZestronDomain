
using Domain;
using Domain.Entities;
using Domain.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainRepository.Repositories
{
    public class ContaminationTestRepository : IContaminationTestRepository
    {
        private UnitOfWork UnitOfWork { get; }
        private List<Tuple<ContaminationTest, DataRow>> ContaminationsToSave { get; } 
        public ContaminationTestRepository(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            ContaminationsToSave = new List<Tuple<ContaminationTest, DataRow>>();
            UnitOfWork.ChangesSaved += UnitOfWork_ChangesSaved;
            UnitOfWork.SavingChanges += UnitOfWork_SavingChanges;
        }

        private void UnitOfWork_SavingChanges()
        {
            foreach(var tuple in ContaminationsToSave)
            {

            }
        }

        private void UnitOfWork_ChangesSaved()
        {
            foreach(var tuple in ContaminationsToSave)
            {
                tuple.Item1.Id = (byte[])tuple.Item2[DBTables.ContaminationTest.IdFieldName];
            }
        }

        public void Add(ContaminationTest contaminationTest)
        {
            contaminationTest.GetType().GetProperty("").
            var row = UnitOfWork.GetNewDataRow(DBTables.ContaminationTest.Name);
            contaminationTest.CleaningTrial.V
            FillDataRow(row, contaminationTest);
            ContaminationsToSave.Add(new Tuple<ContaminationTest, DataRow>(contaminationTest, row));
        }

        public ContaminationTest Get(byte[] contaminationTestId)
        {
            var row = UnitOfWork.GetDataRow(DBTables.ContaminationTest.Name, contaminationTestId);
            var result = CreateObject(row);
            ContaminationsToSave.Add(new Tuple<ContaminationTest, DataRow>(result, row));
            return result;
        }

        public ContaminationTest GetAsNoTracking(byte[] contaminationTestId)
        {
            var row = UnitOfWork.GetDataRowAsNoTracking(DBTables.ContaminationTest.Name, contaminationTestId);
            return CreateObject(row);
        }

        public void Remove(ContaminationTest contaminationTest)
        {
            throw new NotImplementedException();
        }

        internal CleaningTrial GetCleaningTrial(byte[] cleaningTrialId)
        {

        }

        private void FillDataRow(DataRow row, ContaminationTest contaminationTest)
        {
            
        }

        private ContaminationTest CreateObject(DataRow dataRow)
        {
            return new ContaminationTest();
        }
    }
}
