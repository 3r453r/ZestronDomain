using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaminationTest.Persistence
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        IContaminationTestRepository ContaminationTestRepository { get; set; }

    }
}
