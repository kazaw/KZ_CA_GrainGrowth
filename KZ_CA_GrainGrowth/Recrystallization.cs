using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZ_CA_GrainGrowth
{
    class Recrystallization
    {
        String csvPath = @"dyslokacje.csv";
        const double CHANCE = 0.8;
        static readonly Random random = new Random();
        double bigPackageSize;
        double smallPackageSize;
        double packagePool;
        double deltaPackagePool;
        double sumDisclocations;
        public bool isFinished;
        MyProperties myProperties;
        Dictionary<double, double> sumDisclocationsDictioniary;
        bool[,] recrystallizedLastTime;


        public Recrystallization(MyProperties myProperties)
        {
            this.myProperties = myProperties;
            packagePool = 0;
            sumDisclocations = 0;
            sumDisclocationsDictioniary = new Dictionary<double, double>();
            recrystallizedLastTime = new bool[myProperties.meshSizeX + 2, myProperties.meshSizeY + 2];
            isFinished = false;
        }


        List<Neighbor> GetNeighborsWithCord(MyCell[,] universe, int x, int y)
        {
            int tmp = 0;
            List<Neighbor> neighborsList = new List<Neighbor>();
            switch (myProperties.switchNeighborhood)
            {
                case 0://von Neumanna
                    neighborsList.Add(new Neighbor(universe[x - 1, y], x-1, y));
                    neighborsList.Add(new Neighbor(universe[x + 1, y], x + 1, y));
                    neighborsList.Add(new Neighbor(universe[x, y - 1], x, y - 1));
                    neighborsList.Add(new Neighbor(universe[x, y + 1], x, y + 1));

                    break;
                case 1://Moore
                    for (int i = x - 1; i < x + 2; i++)
                    {
                        for (int j = y - 1; j < y + 2; j++)
                        {
                            if (i == x && j == y) continue;
                            neighborsList.Add(new Neighbor(universe[i, j],i,j));
                        }
                    }
                    break;
                case 2://Heks lewe
                    for (int i = x - 1; i < x + 2; i++)
                    {
                        for (int j = y - 1; j < y + 2; j++)
                        {
                            if (i == x && j == y) continue;
                            if (i == x - 1 && j == y + 1) continue;
                            if (i == x + 1 && j == y - 1) continue;
                            neighborsList.Add(new Neighbor(universe[i, j], i, j));
                        }
                    }
                    break;
                case 3://Heks prawe
                    for (int i = x - 1; i < x + 2; i++)
                    {
                        for (int j = y - 1; j < y + 2; j++)
                        {
                            if (i == x && j == y) continue;
                            if (i == x - 1 && j == y - 1) continue;
                            if (i == x + 1 && j == y + 1) continue;
                            neighborsList.Add(new Neighbor(universe[i, j], i, j));
                        }
                    }
                    break;
                case 4://heks losowe
                    for (int i = x - 1; i < x + 2; i++)
                    {
                        for (int j = y - 1; j < y + 2; j++)
                        {
                            if (i == x && j == y) continue;
                            tmp = random.Next(0, 2);
                            if (tmp == 0)
                            {
                                if (i == x - 1 && j == y + 1) continue;
                                if (i == x + 1 && j == y - 1) continue;
                            }
                            else
                            {
                                if (i == x - 1 && j == y - 1) continue;
                                if (i == x + 1 && j == y + 1) continue;
                            }
                            neighborsList.Add(new Neighbor(universe[i, j], i, j));
                        }
                    }
                    break;
                case 5://pent losowe
                    for (int i = x - 1; i < x + 2; i++)
                    {
                        for (int j = y - 1; j < y + 2; j++)
                        {
                            if (i == x && j == y) continue;
                            tmp = random.Next(0, 4);
                            if (tmp == 0)
                            {
                                if (i == x - 1 && j == y + 1) continue;
                                if (i == x && j == y + 1) continue;
                                if (i == x + 1 && j == y + 1) continue;
                            }
                            else if (tmp == 1)
                            {
                                if (i == x - 1 && j == y - 1) continue;
                                if (i == x && j == -+1) continue;
                                if (i == x + 1 && j == y - 1) continue;
                            }
                            else if (tmp == 2)
                            {
                                if (i == x - 1 && j == y - 1) continue;
                                if (i == x - 1 && j == y) continue;
                                if (i == x - 1 && j == y + 1) continue;
                            }
                            else if (tmp == 3)
                            {
                                if (i == x + 1 && j == y - 1) continue;
                                if (i == x + 1 && j == y) continue;
                                if (i == x + 1 && j == y + 1) continue;
                            }
                            neighborsList.Add(new Neighbor(universe[i, j], i, j));
                        }
                    }
                    break;
                case 6:// sąsiedztwo z promieniem
                    break;
                default:
                    break;
            }
            return neighborsList;
        }

        public List<MyCell> getNeighborhood(MyCell[,] universe, int x, int y)
        {
            int tmp = 0;
            List<MyCell> neighborsList = new List<MyCell>();
            switch (myProperties.switchNeighborhood)
            {
                case 0://von Neumanna
                    neighborsList.Add(universe[x - 1, y]);
                    neighborsList.Add(universe[x + 1, y]);
                    neighborsList.Add(universe[x, y - 1]);
                    neighborsList.Add(universe[x, y + 1]);
                    break;
                case 1://Moore
                    for (int i = x - 1; i < x + 2; i++)
                    {
                        for (int j = y - 1; j < y + 2; j++)
                        {
                            if (i == x && j == y) continue;
                            neighborsList.Add(universe[i, j]);
                        }
                    }
                    break;
                case 2://Heks lewe
                    for (int i = x - 1; i < x + 2; i++)
                    {
                        for (int j = y - 1; j < y + 2; j++)
                        {
                            if (i == x && j == y) continue;
                            if (i == x - 1 && j == y + 1) continue;
                            if (i == x + 1 && j == y - 1) continue;
                            neighborsList.Add(universe[i, j]);
                        }
                    }
                    break;
                case 3://Heks prawe
                    for (int i = x - 1; i < x + 2; i++)
                    {
                        for (int j = y - 1; j < y + 2; j++)
                        {
                            if (i == x && j == y) continue;
                            if (i == x - 1 && j == y - 1) continue;
                            if (i == x + 1 && j == y + 1) continue;
                            neighborsList.Add(universe[i, j]);
                        }
                    }
                    break;
                case 4://heks losowe
                    for (int i = x - 1; i < x + 2; i++)
                    {
                        for (int j = y - 1; j < y + 2; j++)
                        {
                            if (i == x && j == y) continue;
                            tmp = random.Next(0, 2);
                            if (tmp == 0)
                            {
                                if (i == x - 1 && j == y + 1) continue;
                                if (i == x + 1 && j == y - 1) continue;
                            }
                            else
                            {
                                if (i == x - 1 && j == y - 1) continue;
                                if (i == x + 1 && j == y + 1) continue;
                            }
                            neighborsList.Add(universe[i, j]);
                        }
                    }
                    break;
                case 5://pent losowe
                    for (int i = x - 1; i < x + 2; i++)
                    {
                        for (int j = y - 1; j < y + 2; j++)
                        {
                            if (i == x && j == y) continue;
                            tmp = random.Next(0, 4);
                            if (tmp == 0)
                            {
                                if (i == x - 1 && j == y + 1) continue;
                                if (i == x && j == y + 1) continue;
                                if (i == x + 1 && j == y + 1) continue;
                            }
                            else if (tmp == 1)
                            {
                                if (i == x - 1 && j == y - 1) continue;
                                if (i == x && j == -+1) continue;
                                if (i == x + 1 && j == y - 1) continue;
                            }
                            else if (tmp == 2)
                            {
                                if (i == x - 1 && j == y - 1) continue;
                                if (i == x - 1 && j == y) continue;
                                if (i == x - 1 && j == y + 1) continue;
                            }
                            else if (tmp == 3)
                            {
                                if (i == x + 1 && j == y - 1) continue;
                                if (i == x + 1 && j == y) continue;
                                if (i == x + 1 && j == y + 1) continue;
                            }
                            neighborsList.Add(universe[i, j]);
                        }
                    }
                    break;
                case 6:// sąsiedztwo z promieniem
                    break;
                default:
                    break;
            }
            return neighborsList;
        }

        public bool isOnTheBorder(List<MyCell> myCells, int id)
        {
            myCells.RemoveAll(g => g.get_id() == 0);//usuwanie granicy
            if (myCells.Any(g => g.get_id() != id))
            {
                return true;//zwraca prawdę jeśli lista sąsiadów zawiera sasiądów
            }
            return false;
        }


        public MyCell[,] recrystallize(MyCell[,] universe)
        {
            //tutaj tworzę tablicę która zawiera, które zostały zrfndsjdshowane w poprzednim krokim czasowym
            //po zakończeniu zeruje poprzednie wartości nadpisuje ją nową tablicą
            MyCell[,] tmpUniverse = universe;
            List<Neighbor> neighborsList;
            bool flag;
            bool recrystal;
            int x;
            int y;
            bool[,] recrystallizedThisTime = new bool[myProperties.meshSizeX + 2, myProperties.meshSizeY + 2];

            isFinished = true;

            for (int i = 1; i < myProperties.meshSizeX + 1; i++)
            {
                for (int j = 1; j < myProperties.meshSizeY + 1; j++)
                {
                    if (tmpUniverse[i, j].get_isRecrystallized() == true)
                    {
                        continue;
                    }
                    flag = false;
                    recrystal = false;
                    neighborsList = GetNeighborsWithCord(tmpUniverse, i, j);
                    neighborsList = ShuffleClass.Shuffle(neighborsList, random).ToList();

                    neighborsList.RemoveAll(g => g.myCell.get_id() == 0);//usuwanie granicy
                    //pierwszy warunek // potrzebuje jeszcze id tego sąsiada
                    foreach (var item in neighborsList)
                    {
                        if (item.myCell.get_isRecrystallized() == true);//sprawdza czy jest zreksrystalizowany
                        {
                            //porównanie z poprzednim czasem
                            if (recrystallizedLastTime[item.x, item.y] == true)
                            {
                                // drugi warunek
                                foreach (var neighbor in neighborsList)
                                {
                                    //if (neighbor.myCell.get_id() == tmpUniverse[i, j].get_id())
                                    //{
                                    //    //flag = true;//zastanowaić sie
                                    //    continue;
                                    //}
                                    if (neighbor.myCell.get_disclocationDensity() > tmpUniverse[i,j].get_disclocationDensity())
                                    {
                                        flag = true;//gestośc dyslokacji jest większa, tej przerwanie pętli
                                        break;
                                    }

                                }
                                if (recrystal == true || flag == true)
                                {
                                    break;
                                }
                                //Rekrystalizacja
                                tmpUniverse[i, j].set_isRecrystallized(true);
                                tmpUniverse[i, j].set_id(item.myCell.get_id());
                                tmpUniverse[i, j].set_disclocationDensity(0);
                                recrystallizedThisTime[i, j] = true;
                                recrystal = true;
                                isFinished = false;
 
                            }
                        }
                        if (recrystal == true || flag == true)
                        {
                            break;
                        }
                    }
                                   
                }
            }
            recrystallizedLastTime = recrystallizedThisTime;
            return tmpUniverse;
        }

        public MyCell[,] nucleation(MyCell[,] universe)
        {
            //stworzyć tablicę, czy któryś uległ rekrystalizacji
            MyCell[,] tmpUniverse = universe;
            List<MyCell> neighborsList;
            double critical = myProperties.critical / (myProperties.meshSizeX * myProperties.meshSizeY);

            for (int i = 1; i < myProperties.meshSizeX + 1; i++)
            {
                for (int j = 1; j < myProperties.meshSizeY + 1; j++)
                {
                    neighborsList = getNeighborhood(tmpUniverse, i, j);
                    double density = tmpUniverse[i, j].get_disclocationDensity();
                    if (density > critical && isOnTheBorder(neighborsList, tmpUniverse[i, j].get_id()) == true)
                    {
                        tmpUniverse[i, j].set_isRecrystallized(true);
                        tmpUniverse[i, j].set_disclocationDensity(0);
                        recrystallizedLastTime[i, j] = true;
                    }
                }
            }


            return tmpUniverse;
        }

        public MyCell[,] fireDisclocationCannont(MyCell[,] universe, double time)
        {
            MyCell[,] tmpUniverse = universe;
            List<MyCell> neighborsList;
            double oldDisclocationDensity;
            int x;
            int y;
            double p;

            computePackageSize(time);
            //1krok
            for (int i = 1; i < myProperties.meshSizeX + 1; i++)
            {
                for (int j = 1; j < myProperties.meshSizeY + 1; j++)
                {
                    oldDisclocationDensity = tmpUniverse[i, j].get_disclocationDensity();
                    tmpUniverse[i, j].set_disclocationDensity(oldDisclocationDensity + bigPackageSize);
                    sumDisclocations += bigPackageSize;
                }
            }
            //2krok
            while (sumDisclocations < packagePool)
            {

                if(packagePool - sumDisclocations - smallPackageSize < 0)
                {
                    smallPackageSize = Math.Abs(packagePool - sumDisclocations);
                }
                x = random.Next(1, myProperties.meshSizeX + 1);//sprawdzić sąsiadów
                y = random.Next(1, myProperties.meshSizeY + 1);
                oldDisclocationDensity = tmpUniverse[x, y].get_disclocationDensity();
                neighborsList = getNeighborhood(tmpUniverse, x, y);
                p = random.NextDouble();
                if (isOnTheBorder(neighborsList, tmpUniverse[x,y].get_id()) == true)
                {
                    if (p < CHANCE)
                    {
                        tmpUniverse[x, y].set_disclocationDensity(oldDisclocationDensity + smallPackageSize);
                        sumDisclocations += smallPackageSize;
                    }
                }
                else
                {
                    if(p > CHANCE)
                    {
                        tmpUniverse[x, y].set_disclocationDensity(oldDisclocationDensity + smallPackageSize);
                        sumDisclocations += smallPackageSize;
                    }
                }
                
            }
            sumDisclocationsDictioniary.Add(time, computeSumDiscloaction(tmpUniverse));
            saveSumDisclocationsDictioniaryToFile();
            
            return tmpUniverse;
        }

        private void computePackageSize(double t)
        {
            double old = packagePool;
            packagePool = (myProperties.A / myProperties.B) + (1 - (myProperties.A / myProperties.B)) * Math.Exp((-1) * myProperties.B * t);
            deltaPackagePool = packagePool - old;
            bigPackageSize = deltaPackagePool / (myProperties.meshSizeX * myProperties.meshSizeY);
            bigPackageSize = bigPackageSize * (myProperties.bigPackageSize);// czy trzeba dzielić przez 100?
            double remainingPool = deltaPackagePool - (bigPackageSize * (myProperties.meshSizeX * myProperties.meshSizeY));
            smallPackageSize = (myProperties.smallPackageSize) * remainingPool;
            return;
        }

        private double computeSumDiscloaction(MyCell[,] universe)
        {
            double sum = 0;
            for (int i = 1; i < myProperties.meshSizeX + 1; i++)
            {
                for (int j = 1; j < myProperties.meshSizeY + 1; j++)
                {
                    sum += universe[i, j].get_disclocationDensity();
                }
            }
            return sum;
        }

        private void saveSumDisclocationsDictioniaryToFile()
        {
            String csv = String.Join(
                Environment.NewLine,
                sumDisclocationsDictioniary.Select(d => d.Key.ToString("F5") + ";" + d.Value.ToString("F2") + ";")
                );
            //System.Console.Write("D1");
            System.IO.File.WriteAllText(csvPath, csv);
        }


    }
}
