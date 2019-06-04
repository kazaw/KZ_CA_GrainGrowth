using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZ_CA_GrainGrowth
{
    [DebuggerDisplay("Id = {id}, Energy = {energy}, isRec ={isRecrystallized}")]
    class MyCell : IEqualityComparer<MyCell>
    {
        int id;
        double gravityX;
        double gravityY;
        static readonly Random random = new Random();
        int energy;
        bool isRecrystallized;
        double disclocationDensity;
        public MyCell(int id)
        {
            this.id = id;
            this.gravityX = random.NextDouble() - 0.5;
            this.gravityY = random.NextDouble() - 0.5;
            this.disclocationDensity = 0;
            this.isRecrystallized = false;
            this.energy = 0;
        }
        public void set_id(int id)
        {
            this.id = id;
        }
        public int get_id()
        {
            return this.id;
        }
        public double get_gravityX()
        {
            return gravityX;
        }
        public void set_gravityX(double gravityX)
        {
            this.gravityX = gravityX;
        }
        public double get_gravityY()
        {
            return gravityY;
        }
        public void set_gravityY(double gravityY)
        {
            this.gravityY = gravityY;
        }
        public void set_energy(int energy)
        {
            this.energy = energy;
        }
        public int get_energy()
        {
            return energy;
        }
        public double get_disclocationDensity()
        {
            return disclocationDensity;
        }
        public void set_disclocationDensity(double disclocationDensity)
        {
            this.disclocationDensity = disclocationDensity;
        }
        public void set_isRecrystallized(bool isRecrystallized)
        {
            this.isRecrystallized = isRecrystallized;
        }
        public bool get_isRecrystallized()
        {
            return isRecrystallized;
        }


        public MyCell myclone()
        {
            MyCell myCell = new MyCell(id);
            myCell.set_energy(this.energy);
            myCell.set_gravityX(this.gravityX);
            myCell.set_gravityY(this.gravityY);
            myCell.set_disclocationDensity(this.disclocationDensity);
            myCell.set_isRecrystallized(this.isRecrystallized);

            return myCell;
        }

        public bool Equals(MyCell x, MyCell y)
        {
            return x.id.Equals(y.id);
        }

        public int GetHashCode(MyCell obj)
        {
            return obj.id.GetHashCode();
        }
    }
}
