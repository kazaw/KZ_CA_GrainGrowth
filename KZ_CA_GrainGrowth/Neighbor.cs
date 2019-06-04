using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZ_CA_GrainGrowth
{
    class Neighbor : IEqualityComparer<Neighbor>
    {
        public MyCell myCell;
        public int x;
        public int y;
        public Neighbor(MyCell myCell, int x, int y)
        {
            this.myCell = myCell;
            this.x = x;
            this.y = y;
        }

        public bool Equals(Neighbor x, Neighbor y)
        {
            return x.myCell.Equals(y.myCell);
        }

        public int GetHashCode(Neighbor obj)
        {
            return obj.myCell.GetHashCode();
        }
    }
}
