using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ContaminationTest : IChangeTracking
    {
        private byte[] _id;
        public byte[] Id { get { return _id; } set { if (_id == null) _id = value; } }
        public Collection<CleaningTrial> CleaningTrials { get; }
        private Lazy<IEnumerable<CleaningTrial>> _cleaningTrials = new Lazy<IEnumerable<CleaningTrial>>(() => {
            return 
        })
        public string TestName { get; set; }

    }
}
