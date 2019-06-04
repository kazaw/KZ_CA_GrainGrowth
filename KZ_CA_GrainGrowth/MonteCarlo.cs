using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KZ_CA_GrainGrowth
{
    class MonteCarlo
    {


        static readonly Random random = new Random();
        public MyProperties myProperties;
        public MonteCarlo(MyProperties sourceProperties)
        {
            myProperties = sourceProperties;
        }
        List<MyCell> getNeighborhood(MyCell[,] universe, int x, int y)
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
                            neighborsList.Add(universe[i,j]);
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

        int computeEnergy(MyCell cell, List<MyCell> neighborsList)
        {
            int energy = 0;
            foreach (var item in neighborsList)
            {
                if (item.get_id() == 0 || item.get_id() == cell.get_id())
                {
                    continue;
                }
                energy = energy + 1;
            }
            return energy;
        }

        public MyCell[,] computeEnergyEverything(MyCell[,] universe)
        {
            MyCell[,] tmpUniverse = universe;
            for (int i = 1; i < myProperties.meshSizeX + 1; i++)
            {
                for (int j = 1; j < myProperties.meshSizeY + 1; j++)
                {
                    tmpUniverse[i, j].set_energy(computeEnergy(tmpUniverse[i, j], getNeighborhood(tmpUniverse, i, j)));
                }
            }
            return tmpUniverse;
        }

        public MyCell[,] computeMonteCarlo(MyCell[,] universe)
        {
            MyCell[,] tmpUniverse = universe;
            List<Point> pointList = new List<Point>();
            List<MyCell> neighborsList;
            List<MyCell> neighborsListDistinct;
            Point coord;
            int newEnergy = 0;
            int oldEnergy = 0;
            int deltaEnergy = 0;
            int tmp = 0;
            double p = 0;
            int oldID = 0;
            for (int i = 1; i < myProperties.meshSizeX + 1; i++)
            {
                for (int j = 1; j < myProperties.meshSizeY + 1; j++)
                {
                    pointList.Add(new Point(i, j));
                }
            }
            int cellAmount = pointList.Count();
            for (int i = 0; i < cellAmount; i++)
            {
                tmp = random.Next(0, cellAmount - i);
                coord = pointList[tmp];
                pointList.RemoveAt(tmp);// Krok 2 - losowy wybór komórki
                neighborsList = getNeighborhood(tmpUniverse, coord.X, coord.Y);//otrzymanie sąsiadów
                neighborsList.RemoveAll(g => g.get_id() == 0);//usuwanie granicy
                oldEnergy = computeEnergy(tmpUniverse[coord.X, coord.Y], neighborsList);//obliczenie energi komórki
                universe[coord.X, coord.Y].set_energy(oldEnergy);
                neighborsListDistinct = neighborsList.Distinct().ToList();//Pozostawienie unikalnych wartości w liscie sąsiadów
                neighborsListDistinct.RemoveAll(g => g.get_id() == tmpUniverse[coord.X, coord.Y].get_id());// usuniecie sąsiada o takim samych id
                if (neighborsListDistinct.Any() == false) continue;//jeśli nie ma sąsiadów - idzie dalej

                oldID = tmpUniverse[coord.X, coord.Y].get_id();
                tmp = random.Next(0, neighborsListDistinct.Count());//sprawdzić jakie liczby zwraca
                tmpUniverse[coord.X, coord.Y].set_id(neighborsListDistinct[tmp].get_id());//hipotetyczna zmiana na id jednego z sąsiadów
                newEnergy = computeEnergy(tmpUniverse[coord.X, coord.Y], neighborsList);
                tmpUniverse[coord.X, coord.Y].set_energy(newEnergy);
                deltaEnergy = newEnergy - oldEnergy;
                if (deltaEnergy <= 0)
                {
                    continue;//akceptujemy zmianę
                } 
                else
                {
                    p = Math.Exp((-1) * deltaEnergy / myProperties.kT);
                    if(random.NextDouble() > p)
                    {
                        tmpUniverse[coord.X, coord.Y].set_id(oldID);//brak zmiany
                        tmpUniverse[coord.X, coord.Y].set_energy(oldEnergy);
                    }
                }

            }
            return tmpUniverse;
        }
    }
}
