using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaminationTest.Persistence
{
    public interface IContaminationTestRepository
    {
        void Add(ContaminationTest contaminationTest);
        void Remove(ContaminationTest contaminationTest);
        ContaminationTest Find()
    }
}
