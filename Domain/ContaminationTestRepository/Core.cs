using CdcSoftware.Pivotal.Applications.Core.Server;
using CdcSoftware.Pivotal.Engine.Server;
using Domain.Persistence;
using DomainRepository.DBTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainRepository
{
    public class Core : IDomainRepository
    {
        private Core()
        { }

        static Core()
        {
        }

        public static Core Instance { get; } = new Core();
        private Table[] Tables = new Table[] {
            new ContaminationTest()
        };
        public IUnitOfWork GetUnitOfWork(object dataAccess, object systemServer) => new UnitOfWork(dataAccess as DataAccess
            , systemServer as SystemServer, Tables);
    }
}
