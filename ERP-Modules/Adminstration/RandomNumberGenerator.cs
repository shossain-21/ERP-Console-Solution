using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adminstration
{
    public static class RandomNumberGenerator
    {
        private static int _seed;
        private static Random _rand;
        static RandomNumberGenerator()
        {
            _seed = DateTime.Now.Microsecond;
            _rand = new Random(_seed);
        }

        public static int Generator()
        {
            return _rand.Next();
        }
    }
}
