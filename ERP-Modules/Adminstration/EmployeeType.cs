using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adminstration
{
    internal class EmployeeType
    {
        private int _officer = 70;
        private int _staff = 40;
        private int _worker = 20;
        public string Type { get; set; }
        internal int Officer
        { 
            get
            {
                return _officer;
            }
        }
        internal int Staff 
        { 
            get
            {
                return _staff;
            }
        }
        internal int Worker 
        {
            get
            {
                return _worker;
            }
        }
    }
}
