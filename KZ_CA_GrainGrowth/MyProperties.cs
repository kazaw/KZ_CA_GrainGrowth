using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZ_CA_GrainGrowth
{
    class MyProperties
    {
        public int meshSizeX;
        public int meshSizeY;
        public int amountX;
        public int amountY;
        public int amountSeed;
        public double rayLenght;
        public int MCIteration;
        public double kT;
        public int switchNeighborhood;
        public int switchBoundaryCondition;
        public int switchGrainGrowthType;

        public double A;
        public double B;
        public double critical;
        public double time;
        public double deltaTime;
        public double bigPackageSize;
        public double smallPackageSize;

        public MyProperties(int smX, int smY, int saX, int saY, int saS, double srL, int sMCi, double skt, int sNei, int sBC, int sGGT)
        {
            meshSizeX = smX;
            meshSizeY = smY;
            amountX = saX;
            amountY = saY;
            amountSeed = saS;
            rayLenght = srL;
            MCIteration = sMCi;
            kT = skt;
            switchNeighborhood = sNei;
            switchBoundaryCondition = sBC;
            switchGrainGrowthType = sGGT;
            A = 0;
            B = 0;
            critical = 0;
        }

        public void UpdateMyProperties(int smX, int smY, int saX, int saY, int saS, double srL, int sMCi, double skt, int sNei, int sBC, int sGGT)
        {
            this.meshSizeX = smX;
            this.meshSizeY = smY;
            this.amountX = saX;
            this.amountY = saY;
            this.amountSeed = saS;
            this.rayLenght = srL;
            this.MCIteration = sMCi;
            this.kT = skt;
            this.switchNeighborhood = sNei;
            this.switchBoundaryCondition = sBC;
            this.switchGrainGrowthType = sGGT;
        }
        public void UpdateRecrystallization(double A, double B, double critical, double time, double deltaTime, double bigPackageSize, double smallPackageSize)
        {
            this.A = A;
            this.B = B;
            this.critical = critical;
            this.time = time;
            this.deltaTime = deltaTime;
            this.bigPackageSize = bigPackageSize;
            this.smallPackageSize = smallPackageSize;
        }
    }
}
