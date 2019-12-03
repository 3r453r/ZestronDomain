using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Persistence
{
    public interface IContaminationTestRepository
    {
        void Add(ContaminationTest contaminationTest);
        void Remove(ContaminationTest contaminationTest);
        ContaminationTest Get(byte[] contaminationTestId);
        IEnumerable<CleaningTrial> GetCleaningTrials(byte[] contaminationTestId);
    }
}
