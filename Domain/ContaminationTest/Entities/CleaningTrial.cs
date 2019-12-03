using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CleaningTrial
    {
        private byte[] _id;
        public byte[] Id { get { return _id; } set { if (_id == null) _id = value; } }

    }
}
