using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    public struct Cell
    {
        public bool IsAlive { get; private set; }

        public void Dies()
        {
            IsAlive = false;
        }

        public void Live()
        {
            IsAlive = true;
        }
    }
}
