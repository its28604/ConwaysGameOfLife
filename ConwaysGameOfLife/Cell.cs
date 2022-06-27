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

        public void Lives()
        {
            IsAlive = true;
        }

        internal bool Underpopulation()
        {
            throw new NotImplementedException();
        }

        internal bool Overpopulation()
        {
            throw new NotImplementedException();
        }

        internal bool AbleToReproduction()
        {
            throw new NotImplementedException();
        }
    }
}
