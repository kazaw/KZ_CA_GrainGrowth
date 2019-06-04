using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KZ_CA_GrainGrowth
{
    public partial class Form1 : Form
    {
        
        Bitmap image1;
        Bitmap image2;
        int meshSizeX;
        int meshSizeY;
        bool flagGrainGrowth = false;
        bool flagMonteCarlo = false;
        bool flagEnergyMap = false;
        bool flagCannon = false;
        bool flagRecrystallization = false;

        MyCell[,] currentUniverse;
        MyCell[,] oldUniverse;
        Color[] colorArray;
        List<Color> colorDensityList;
        int currentTime;
        //Stworzyć klasę  komórki
        int switchNeighborhood;
        int switchBoundaryCondition;
        int switchGrainGrowthType;
        MonteCarlo monteCarlo;
        Recrystallization recrystallization;

        int amountX;
        int amountY;
        int amountSeed;
        double rayLenght;
        MyProperties myProperties;

        private volatile bool stopThread = false;
        private Thread workThread;
        private Thread monteCarloThread;
        private Thread recrystallizationThread;


        void initComboBox()
        {
            comboBoxNeighborhood.Items.Add("Von Neumanna");
            comboBoxNeighborhood.Items.Add("Moore");
            comboBoxNeighborhood.Items.Add("Heks Lewe");
            comboBoxNeighborhood.Items.Add("Heks Prawe");
            comboBoxNeighborhood.Items.Add("Heks Losowe");
            comboBoxNeighborhood.Items.Add("Pent Losowe");
            comboBoxNeighborhood.Items.Add("Z promieniem");
            comboBoxNeighborhood.SelectedIndex = 0;

            comboBoxBoundaryCondition.Items.Add("Periodyczne");
            comboBoxBoundaryCondition.Items.Add("Absorbujące");
            comboBoxBoundaryCondition.SelectedIndex = 1;//ZMIENIONY INDEX

            comboBoxGrainGrowthType.Items.Add("Jednorodne");
            comboBoxGrainGrowthType.Items.Add("Losowe");
            comboBoxGrainGrowthType.Items.Add("Z promieniem");
            comboBoxGrainGrowthType.Items.Add("Wybór Użytkownika");
            comboBoxGrainGrowthType.SelectedIndex = 1;
        }

        void initForm()
        {
            //pictureBox1.Size = new Size(1000, 500);
            numericUpDownX.Minimum = 20;
            numericUpDownX.Maximum = 500;
            numericUpDownY.Minimum = 20;
            numericUpDownY.Maximum = 500;

            numericUpDownAmountX.Minimum = 1;
            numericUpDownAmountX.Maximum = 10000;
            numericUpDownAmountY.Minimum = 1;
            numericUpDownAmountY.Maximum = 10000;


            numericUpDownX.Value = 300;
            numericUpDownY.Value = 300;
            numericUpDownAmountX.Value = 300;
            numericUpDownAmountY.Value = 10;

            initComboBox();
        }

        public Form1()
        {
            InitializeComponent();
            initForm();
            initGrowth();
        }

        private void setBoundaryCondition()
        {
            MyCell myCell = new MyCell(0);
            switch (switchBoundaryCondition)
            {
                case 0://Periodyczne
                       //corners
                    currentUniverse[0, 0] = currentUniverse[meshSizeX, meshSizeY];//left up
                    currentUniverse[0, meshSizeY + 1] = currentUniverse[meshSizeX, 1];//right up
                    currentUniverse[meshSizeX + 1, 0] = currentUniverse[1, meshSizeY];//left down
                    currentUniverse[meshSizeX + 1, meshSizeY + 1] = currentUniverse[1, 1];//right down                                                                                 //walls
                    for (int i = 1; i < meshSizeX + 1; i++)
                    {
                        currentUniverse[i, 0] = currentUniverse[i, meshSizeY]; //left wall
                        currentUniverse[i, meshSizeY + 1] = currentUniverse[i, 1]; //right wall //Było 0 zamiast 1
                    }
                    for (int i = 1; i < meshSizeY + 1; i++)
                    {
                        currentUniverse[0, i] = currentUniverse[meshSizeX, i];//up wall
                        currentUniverse[meshSizeX + 1, i] = currentUniverse[1, i];//down wall
                    }
                    break;
                case 1://Absorbujące
                    for (int i = 0; i < meshSizeX + 2; i++)//TODO: sprawdzic to
                    {
                        currentUniverse[i, 0] = myCell.myclone();//lewa
                        currentUniverse[i, meshSizeY + 1] = myCell.myclone();//prawa
                    }
                    for (int i = 0; i < meshSizeY + 2; i++)//TO też
                    {
                        currentUniverse[0, i] = myCell.myclone();//gorna
                        currentUniverse[meshSizeX + 1, i] = myCell.myclone();//dolna
                    }
                    break;
                default:
                    break;
            }
        }

        private void initGrowth()
        {
            currentUniverse = null;//Sprawdzić czy to prawidłowo czyści pamięc

            meshSizeX = (int)numericUpDownX.Value;
            meshSizeY = (int)numericUpDownY.Value;

            switchNeighborhood = comboBoxNeighborhood.SelectedIndex;
            switchBoundaryCondition = comboBoxBoundaryCondition.SelectedIndex;
            switchGrainGrowthType = comboBoxGrainGrowthType.SelectedIndex;
            rayLenght = Double.Parse(textBoxRay.Text);


            amountX = (int)numericUpDownAmountX.Value;
            amountY = (int)numericUpDownAmountY.Value;
            
            amountSeed = 0;//TODO: Policzyc to//najlepiej przypisać to pozniej bo klikanie bd to zwiększać


            currentUniverse = new MyCell[meshSizeX + 2, meshSizeY + 2]; ;
            currentTime = 0;

            double tmpkt = Double.Parse(textBoxkT.Text);
            int tmpMCiteration = int.Parse(textBoxMCIteration.Text);
            myProperties = new MyProperties(meshSizeX, meshSizeY, amountX, amountY, amountSeed, rayLenght,tmpMCiteration, tmpkt, switchNeighborhood, switchBoundaryCondition, switchGrainGrowthType);

            seed();
            setBoundaryCondition();
            //drawUniverse();
        }

        private bool checkRayNeighborhood(int x, int y)//sprawdzać gdy mniejsze od 0
        {
            int tmpX;
            int tmpY;
            double ray = 0;

            for (int i = -amountY; i < amountY; i++)
            {
                for (int j = -amountY; j < amountY; j++)
                {
                    //zrobić sprawdzenie czy wyszło poza tablicę
                    tmpX = x + i;
                    tmpY = y + j;
                    if (tmpX < 0) tmpX = 0;//sprawdzić bo tak to będzie sprawdzać na swojej pozycji
                    if (tmpX >= meshSizeX) tmpX = meshSizeX;
                    if (tmpY < 0) tmpY = 0;
                    if (tmpY >= meshSizeY) tmpY = meshSizeY;//sprawdzić czy jak if zmienią jedno wartość to czy jest poprawnie dla drugiej
                    ray = Math.Pow(x - tmpX, 2) + Math.Pow(y - tmpY, 2);
                    ray = Math.Sqrt(ray);//sprawdza czy jest w kole wpisanym w kwadrat
                    if (ray > amountY) continue;
                    if (currentUniverse[tmpX, tmpY] != null) return false;//sprawdzić czy działa

                }
            }
            return true;
        }

        private void seed()
        {
            Random random = new Random();
            int count = 1;
            int tmpX = 0;
            int tmpY = 0;
            MyCell newCell;
            int missCount = 0;

            switch (switchGrainGrowthType)
            {
                case 0://Jednorodne ok
                    int jumpX = meshSizeX / amountX;
                    int jumpY = meshSizeY / amountY;

                    for (int i = 0; i < amountX; i++)
                    {
                        for (int j = 0; j < amountY; j++)
                        {
                            newCell = new MyCell(count);//obczaić bo ostatnie tworzy na krawędzi
                            currentUniverse[jumpX/2 + i*jumpX, jumpY / 2 + j *jumpY] = newCell;//1 na warunki brzegowe
                            count++;
                        }
                    }
                    amountSeed = amountX * amountY;
                    break;
                case 1://Losowe ok
                    for (int i = 0; i < amountX; i++)//sprawdzić czy miejsce jest zajęte
                    {
                        tmpX = random.Next(1, meshSizeX + 1);//TODO: spr w jakim zakresie czy od 1 czy od 2 dd ilu
                        tmpY = random.Next(1, meshSizeY + 1);
                        if(currentUniverse[tmpX, tmpY] == null) //nie dziala
                        {
                            newCell = new MyCell(count);
                            currentUniverse[tmpX, tmpY] = newCell;
                            count++;
                        }
                        else
                        {
                            i--;
                            continue;
                        }
                        amountSeed = amountX;
                    }
                    break;
                case 2://Z promieniem  //ok
                    for (int i = 0; i < amountX; i++)//zrobić okrąg wpisany w kwadra
                    {
                        tmpX = random.Next(1, meshSizeX + 1);
                        tmpY = random.Next(1, meshSizeY + 1);
                        if(checkRayNeighborhood(tmpX,tmpY) == true)
                        {
                            newCell = new MyCell(count);
                            currentUniverse[tmpX, tmpY] = newCell;
                            count++;
                        }
                        else
                        {
                            missCount++;
                            i--;
                            continue;
                        }
                        amountSeed = count - 1;//sprawdzić
                        if (missCount >= 100) break;

                    }
                    
                    break;
                case 3://Wybór Uzytkownika nie działa
                    drawUniverse();
                    break;
                default:
                    break;
            }
            myProperties.amountSeed = amountSeed;
            colorArray = new Color[amountSeed];
            createColorArray();
        }

        private double calcuteDistance(int x1, int y1, int x2, int y2, MyCell cell1, MyCell cell2)
        {
            double distance;
            //Przekonwertować x1, y1 na współrzędne kartezjańskie i wtedy liczyć
            double tmpX1 = x1 + cell1.get_gravityX();
            double tmpX2 = x2 + cell2.get_gravityX();

            double tmpY1 = y1 + cell1.get_gravityY();
            double tmpY2 = y2 + cell2.get_gravityY();

            distance = Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2);
            distance = Math.Sqrt(distance);
            return distance;
        }

        private int getNeighborhood(MyCell[,] last, int x, int y)
        {
            Random random = new Random();
            List<int> countList = new List<int>();
            List<int> idList = new List<int>();
            int id;
            int tmp = 0;
            int tmpIterations;
            double distance;
            int tmpI;
            int tmpJ;
            bool boundaryCrossed = false;
            switch (switchNeighborhood)
            {
                case 0://Von Neumanna
                    if (last[x-1,y] != null)//lewy
                    {
                        id = last[x - 1, y].get_id();
                        if(id != 0)
                        {
                            if (idList.Contains(id) == true)
                            {
                                countList[idList.IndexOf(id)]++;
                            }
                            else
                            {
                                idList.Add(id);
                                countList.Add(0);
                            }
                        }
                    }
                    if (last[x + 1, y] != null)//prawy
                    {
                        id = last[x + 1, y].get_id();
                        if (id != 0)
                        {
                            if (idList.Contains(id) == true)
                            {
                                countList[idList.IndexOf(id)]++;
                            }
                            else
                            {
                                idList.Add(id);
                                countList.Add(0);
                            }
                        }
                    }
                    if (last[x, y - 1] != null)//dolny
                    {
                        id = last[x, y - 1].get_id();
                        if (id != 0)
                        {
                            if (idList.Contains(id) == true)
                            {
                                countList[idList.IndexOf(id)]++;
                            }
                            else
                            {
                                idList.Add(id);
                                countList.Add(0);
                            }
                        }

                    }
                    if (last[x, y + 1] != null)//górny
                    {
                        id = last[x, y + 1].get_id();
                        if (id != 0)
                        {
                            if (idList.Contains(id) == true)
                            {
                                countList[idList.IndexOf(id)]++;
                            }
                            else
                            {
                                idList.Add(id);
                                countList.Add(0);
                            }
                        }

                    }
                    break;
                case 1://Moore
                    for (int i = x - 1; i < x + 2; i++)
                    {
                        for (int j = y - 1; j < y + 2; j++)
                        {
                            if (i == x && j == y) continue;
                            if (last[i,j] != null)
                            {
                                id = last[i, j].get_id();
                                if (id != 0)
                                {
                                    if (idList.Contains(id) == true)
                                    {
                                        countList[idList.IndexOf(id)]++;
                                    }
                                    else
                                    {
                                        idList.Add(id);
                                        countList.Add(0);
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 2://Heks Lewe
                    for (int i = x - 1; i < x + 2; i++)
                    {
                        for (int j = y - 1; j < y + 2; j++)
                        {
                            if (i == x && j == y) continue;
                            if (i == x - 1 && j == y + 1) continue;
                            if (i == x + 1 && j == y - 1) continue;
                            if (last[i, j] != null)
                            {
                                id = last[i, j].get_id();
                                if (id != 0)
                                {
                                    if (idList.Contains(id) == true)
                                    {
                                        countList[idList.IndexOf(id)]++;
                                    }
                                    else
                                    {
                                        idList.Add(id);
                                        countList.Add(0);
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 3://Hek Prawe
                    for (int i = x - 1; i < x + 2; i++)
                    {
                        for (int j = y - 1; j < y + 2; j++)
                        {
                            if (i == x && j == y) continue;
                            if (i == x - 1 && j == y - 1) continue;
                            if (i == x + 1 && j == y + 1) continue;
                            if (last[i, j] != null)
                            {
                                id = last[i, j].get_id();
                                if (id != 0)
                                {
                                    if (idList.Contains(id) == true)
                                    {
                                        countList[idList.IndexOf(id)]++;
                                    }
                                    else
                                    {
                                        idList.Add(id);
                                        countList.Add(0);
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 4://Heks Losowe
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
                            if (last[i, j] != null)
                            {
                                id = last[i, j].get_id();
                                if (id != 0)
                                {
                                    if (idList.Contains(id) == true)
                                    {
                                        countList[idList.IndexOf(id)]++;
                                    }
                                    else
                                    {
                                        idList.Add(id);
                                        countList.Add(0);
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 5://Pent Losowe
                    for (int i = x - 1; i < x + 2; i++)
                    {
                        for (int j = y - 1; j < y + 2; j++)
                        {
                            if (i == x && j == y) continue;
                            if (last[i, j] != null)
                            {
                                id = last[i, j].get_id();
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
                                    if (i == x && j == - + 1) continue;
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
                                if (id != 0)
                                {
                                    if (idList.Contains(id) == true)
                                    {
                                        countList[idList.IndexOf(id)]++;
                                    }
                                    else
                                    {
                                        idList.Add(id);
                                        countList.Add(0);
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 6://Nie działą
                    tmp = (int)Math.Floor(rayLenght);
                    for (int i = x - tmp; i <= x + tmp; i++)//<=
                    {
                        for (int j = y - tmp; j <= y + tmp; j++)//<=
                        {
                            boundaryCrossed = false;
                            tmpI = i;
                            tmpJ = j;

                            if (tmpI == x && tmpJ == y) continue;
                            if (tmpI < 0)
                            {
                                tmpI = meshSizeX + tmpI;
                                boundaryCrossed = true;
                            }
                            if (tmpJ < 0)
                            {
                                tmpJ = meshSizeY + tmpJ;
                                boundaryCrossed = true;
                            }
                            if (last[tmpI, tmpJ] != null)
                            {
                                //sprawdzać gdy wychodzi poza tablice
                                id = last[tmpI, tmpJ].get_id();
                                //nie będzieć działać dlatego że komórka nie jest jeszcze utworzona
                                //trzeba by zmienić że np tutaj losuje środki cieżkości a w funkcji grow
                                //po utworzeniu komórki je przypisuje
                                distance = calcuteDistance(x, y, tmpI, tmpJ, last[x, y], last[tmpI, tmpJ]);
                                if(boundaryCrossed == true)
                                {
                                    if (distance > rayLenght/2)
                                    {
                                        continue;
                                    }
                                }
                                if(distance > rayLenght)
                                {
                                    continue;
                                }
                                if (id != 0)
                                {
                                    if (idList.Contains(id) == true)
                                    {
                                        countList[idList.IndexOf(id)]++;
                                    }
                                    else
                                    {
                                        idList.Add(id);
                                        countList.Add(0);
                                    }
                                }
                            }
                        }
                    }
                    
                    break;
                default:
                    break;
            }
            if (!idList.Any())
            {
                return 0;
            }
            else return idList[countList.IndexOf(countList.Max())];

        }

        private bool grow()//zlicza ile jest poszczególnych id i wybiera tego którego jest najwięcej
        {
            //to pusta komórka sprawdza sąsiądów
            bool stopGrow = true;
            int id = 0;
            MyCell newCell;
            MyCell[,] lastUniverse = (MyCell[,])currentUniverse.Clone();
            for (int i = 1; i < meshSizeX + 1; i++)
            {
                for (int j = 1; j < meshSizeY + 1; j++)
                {
                    if(lastUniverse[i,j] == null)
                    {
                        stopGrow = false;
                        id = getNeighborhood(lastUniverse, i, j);
                        if (id == 0) continue;
                        currentUniverse[i, j] = new MyCell(id);
                    }
                }
            }
            currentTime++;
            if (stopGrow == true) return true;
            else return false;
        }

        private void startGrowth()
        {
            bool stopGrow = false;
            while (stopGrow != true)
            {
                stopGrow = grow();
                setBoundaryCondition();
                drawUniverse();
                if (stopThread)
                {
                    // clean up your work
                    break;
                }
            }
            flagGrainGrowth = false;
            buttonStart.BeginInvoke((MethodInvoker)delegate
            {
                buttonStart.Text = "Start";
                buttonStart.Enabled = false;
            });
            return;
        }

        private void startMonteCarlo()
        {
            for (int i = 0; i < myProperties.MCIteration; i++)
            {
                currentUniverse = monteCarlo.computeMonteCarlo(currentUniverse);
                setBoundaryCondition();//Warunki brzegowe w czasie montecarlo zrobić
                drawUniverse();
                if (stopThread)
                {
                    // clean up your work
                    break;
                }
            }
            buttonMonteCarloStart.BeginInvoke((MethodInvoker)delegate
            {
                buttonMonteCarloStart.Text = "Koniec";
            });
            return;
        }

        private void startFiringDisclocationCannon()
        {
            for (double i = 0; i < myProperties.time; i = i + myProperties.deltaTime)
            {
                currentUniverse = recrystallization.fireDisclocationCannont(currentUniverse, i);

                labelTime.BeginInvoke((MethodInvoker)delegate
                {
                    labelTime.Text = i.ToString("0.#####");
                });
                if (stopThread)
                {
                    // clean up your work
                    break;
                }
            }
            buttonCannon.BeginInvoke((MethodInvoker)delegate
            {
                buttonCannon.Text = "Koniec";
                buttonNucleation.Enabled = true;
            });
            drawDisclocationDensity();
            return;
        }

        private void startRecrystalization()
        {
            //jak długo trwa rekrystalizacja?
            int i = 1;

            while (recrystallization.isFinished == false)//zrobić żeby zatrzymało się gdy nie ma zmiany// użycie tablicy recrystallizedLastTime
            {
                currentUniverse = recrystallization.recrystallize(currentUniverse);
                setBoundaryCondition();
                labelTime.BeginInvoke((MethodInvoker)delegate
                {
                    labelTime.Text = i.ToString();
                });
                drawUniverse();
                drawDisclocationDensity();
                //Thread.Sleep(1500);
                if (stopThread)
                {
                    // clean up your work
                    break;
                }
                i++;
            }
            buttonStartRecrystal.BeginInvoke((MethodInvoker)delegate
            {
                buttonStartRecrystal.Text = "Koniec";
            });
            return;
        }

        private void StartThreadGrainGrowth()
        {
            if (workThread == null)
            {
                stopThread = false;
                workThread = new Thread(new ThreadStart(startGrowth));
                workThread.Start();
            }
        }

        private void StartThreadMonteCarlo()
        {
            if (monteCarloThread == null)
            {
                stopThread = false;
                monteCarloThread = new Thread(new ThreadStart(startMonteCarlo));
                monteCarloThread.Start();
            }
        }

        private void StartThreadRecrystallization(int k)
        {
            if (recrystallizationThread == null)
            {
                stopThread = false;
                if(k == 0) recrystallizationThread = new Thread(new ThreadStart(startFiringDisclocationCannon));
                else if (k == 1) recrystallizationThread = new Thread(new ThreadStart(startRecrystalization));
                recrystallizationThread.Start();
            }
        }

        private void StopThread()
        {
            if (workThread != null)
            {
                stopThread = true;
                workThread.Join(); // This makes the code here pause until the Thread exits.
                workThread = null;
            }
        }

        private void StopThreadMonteCarlo()
        {
            if (monteCarloThread != null)
            {
                stopThread = true;
                monteCarloThread.Join(); // This makes the code here pause until the Thread exits.
                monteCarloThread = null;
            }
        }

        private void StopThreadRecrystallization()
        {
            if (recrystallizationThread != null)
            {
                stopThread = true;
                recrystallizationThread.Join(); // This makes the code here pause until the Thread exits.
                recrystallizationThread = null;
            }
        }

        private void createColorArray()
        {
            Random random = new Random();
            for (int i = 0; i < amountSeed; i++)
            {
                colorArray[i] = Color.FromArgb(random.Next(100), random.Next(256), random.Next(256));
            }
        }

        private void drawUniverse()
        {
            int tmp;
            image1 = new Bitmap(meshSizeX, meshSizeY);


            for (int i = 1; i < meshSizeX + 1; i++)//zrobić żeby każdy kolor
            {
                for (int j = 1; j < meshSizeY + 1; j++)
                {
                    if (currentUniverse[i, j] == null) image1.SetPixel(i - 1, j - 1, Color.White);
                    else if (currentUniverse[i, j].get_id() == 0) image1.SetPixel(i - 1, j - 1, Color.White);
                    else if (currentUniverse[i, j].get_id() > 0)
                    {
                        tmp = currentUniverse[i, j].get_id() - 1;
                        image1.SetPixel(i - 1, j - 1, colorArray[tmp]);
                    }


                }
            }
            pictureBox1.BeginInvoke((MethodInvoker)delegate
            {
                pictureBox1.Image = image1;
            });

        }

        private void drawEnergy()
        {
            image1 = new Bitmap(meshSizeX, meshSizeY);
            //List<Color> colorListGradient = GetGradients(Color.Red, Color.Violet, 8).ToList();
            List<Color> colorListGradient = new List<Color>();
            colorListGradient.Add(Color.Red);
            colorListGradient.Add(Color.Violet);
            colorListGradient.Add(Color.Pink);
            colorListGradient.Add(Color.Blue);
            colorListGradient.Add(Color.DeepPink);
            colorListGradient.Add(Color.DeepSkyBlue);
            colorListGradient.Add(Color.DimGray);
            colorListGradient.Add(Color.BlanchedAlmond);
            for (int i = 1; i < meshSizeX + 1; i++)//zrobić żeby każdy kolor
            {
                for (int j = 1; j < meshSizeY + 1; j++)
                {
                    if (currentUniverse[i, j].get_energy() == 0) image1.SetPixel(i - 1, j - 1, Color.LawnGreen);
                    else if (currentUniverse[i, j].get_energy() > 0)
                    {
                        image1.SetPixel(i - 1, j - 1, colorListGradient[currentUniverse[i, j].get_energy()-1]);
                    }


                }
            }
            pictureBox1.BeginInvoke((MethodInvoker)delegate
            {
                pictureBox1.Image = MyResizeImage(image1);
                //pictureBox1.Image = image1;
            });

        }

        private void drawMicrostructure()
        {
            image1 = new Bitmap(meshSizeX, meshSizeY);
            double min = Double.MaxValue;
            double density;
            int tmp = 0;

            for (int i = 1; i < myProperties.meshSizeX + 1; i++)
            {
                for (int j = 1; j < myProperties.meshSizeY + 1; j++)
                {
                    density = currentUniverse[i, j].get_disclocationDensity();
                    tmp = currentUniverse[i, j].get_id() - 1;
                    image1.SetPixel(i - 1, j - 1, colorArray[tmp]);
                    if (currentUniverse[i, j].get_isRecrystallized() == false)
                    {
                        image1.SetPixel(i - 1, j - 1,Color.Red);
                    }
                    double step = min;

                }
            }
            pictureBox1.BeginInvoke((MethodInvoker)delegate
            {
                //pictureBox1.Image = image1;
                pictureBox1.Image = MyResizeImage(image1);
            });
        }
        
        private void drawDisclocationDensity()
        {
            int colorAmount = 5;
            image2 = new Bitmap(meshSizeX, meshSizeY);
            double min = Double.MaxValue;
            double max = 0.0;
            double delta;
            double density;
            colorDensityList = GetGradients(Color.FromArgb(152,102,0), Color.DarkGreen, colorAmount).ToList();
            
            for (int i = 1; i < myProperties.meshSizeX + 1; i++)
            {
                for (int j = 1; j < myProperties.meshSizeY + 1; j++)
                {
                    density = currentUniverse[i, j].get_disclocationDensity();
                    if (density == 0) continue;
                    if (density < min) min = density;
                    if (density > max) max = density;
                }
            }
            delta = (max - min) / colorAmount;
            for (int i = 1; i < myProperties.meshSizeX + 1; i++)
            {
                for (int j = 1; j < myProperties.meshSizeY + 1; j++)
                {
                    density = currentUniverse[i, j].get_disclocationDensity();
                    if(density == 0)
                    {
                        image2.SetPixel(i - 1, j - 1, Color.DarkBlue);
                        continue;
                    }
                    double step = min;
                    for (int k = 0; k < colorAmount; k++)
                    {
                        
                        if (density < (step + step) && density >= step )
                        {
                            image2.SetPixel(i - 1, j - 1, colorDensityList[k]);
                        }
                        step += step;
                    }
                }
            }
            pictureBox2.BeginInvoke((MethodInvoker)delegate
            {
                //pictureBox1.Image = image1;
                pictureBox2.Image = MyResizeImage(image2);
            });


        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            flagGrainGrowth = !flagGrainGrowth;
            if (flagGrainGrowth == true)
            {
                //initGrowth();
                buttonStart.Text = "Stop";
                StartThreadGrainGrowth();
            }
            else
            {
                StopThread();

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            if(comboBoxGrainGrowthType.SelectedIndex == 3)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                Point coordinates = me.Location;
                amountSeed++;
                currentUniverse[coordinates.X, coordinates.Y] = new MyCell(amountSeed);
                colorArray = null;
                colorArray = new Color[amountSeed];
                createColorArray();
                drawUniverse();

            }

        }

        private void comboBoxGrainGrowthType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switchGrainGrowthType = comboBoxGrainGrowthType.SelectedIndex;
            buttonStart.Enabled = false;
            switch (switchGrainGrowthType)
            {
                case 0://Jednorodne
                    numericUpDownAmountX.Enabled = true;
                    numericUpDownAmountY.Enabled = true;
                    break;
                case 1://Losowe
                    numericUpDownAmountX.Enabled = true;
                    numericUpDownAmountY.Enabled = false;
                    break;
                case 2://Z promieniem
                    numericUpDownAmountX.Enabled = true;
                    numericUpDownAmountY.Enabled = true;
                    break;
                case 3://Wybór Uzytkownika
                    pictureBox1.Enabled = true;
                    numericUpDownAmountX.Enabled = false;
                    numericUpDownAmountY.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private void buttonSeed_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = true;
            StopThread();
            flagGrainGrowth = false;
            initGrowth();
            drawUniverse();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonEnergy_Click(object sender, EventArgs e)
        {
            monteCarlo = new MonteCarlo(myProperties);
            currentUniverse = monteCarlo.computeEnergyEverything(currentUniverse);
            drawEnergy();
        }

        private void buttonMonteCarloStart_Click(object sender, EventArgs e)
        {
            oldUniverse = currentUniverse;
            flagMonteCarlo = !flagMonteCarlo;
            if (flagMonteCarlo == true)
            {
                StopThreadMonteCarlo();
                double tmpkt = Double.Parse(textBoxkT.Text);
                int tmpMCiteration = int.Parse(textBoxMCIteration.Text);
                myProperties.UpdateMyProperties(meshSizeX, meshSizeY, amountX, amountY, amountSeed, rayLenght, tmpMCiteration, tmpkt, switchNeighborhood, switchBoundaryCondition, switchGrainGrowthType);

                monteCarlo = new MonteCarlo(myProperties);
                buttonMonteCarloStart.Text = "Stop";
                StartThreadMonteCarlo();
            }
            else
            {
                StopThreadMonteCarlo();
                buttonMonteCarloStart.Text = "Start";
            }
        }
        public static IEnumerable<Color> GetGradients(Color start, Color end, int steps)
        {
            int stepA = ((end.A - start.A) / (steps - 1));
            int stepR = ((end.R - start.R) / (steps - 1));
            int stepG = ((end.G - start.G) / (steps - 1));
            int stepB = ((end.B - start.B) / (steps - 1));

            for (int i = 0; i < steps; i++)
            {
                yield return Color.FromArgb(start.A + (stepA * i),
                                            start.R + (stepR * i),
                                            start.G + (stepG * i),
                                            start.B + (stepB * i));
            }
        }
        private Bitmap MyResizeImage(Bitmap sImage)
        {
            int scale = 3;

            Bitmap picOriginal = sImage;
            int wid = (int)(picOriginal.Width * scale);
            int hgt = (int)(picOriginal.Height * scale);
            Bitmap bm = new Bitmap(wid, hgt);

            using (Graphics gr = Graphics.FromImage(bm))
            {
                // No smoothing.
                gr.InterpolationMode = InterpolationMode.NearestNeighbor;

                Point[] dest =
                {
            new Point(0, 0),
            new Point(wid, 0),
            new Point(0, hgt),
        };
                Rectangle source = new Rectangle(
                    0, 0,
                    picOriginal.Width,
                    picOriginal.Height);
                gr.DrawImage(picOriginal,
                    dest, source, GraphicsUnit.Pixel);
            }
            return bm;
        }

        private void buttonCannon_Click(object sender, EventArgs e)
        {
            flagCannon = !flagCannon;
            if (flagCannon == true)
            {
                double A = double.Parse(textBoxA.Text);
                double B = double.Parse(textBoxB.Text);
                double critical = double.Parse(textBoxCritical.Text);
                double time = double.Parse(textBoxRecTime.Text);
                double deltaTime = double.Parse(textBoxRecDeltaTime.Text);
                double bigPackageSize = double.Parse(textBoxBigPackage.Text);
                double smallPackageSize = double.Parse(textBoxSmallPackage.Text);
                myProperties.UpdateRecrystallization(A, B, critical, time, deltaTime, bigPackageSize, smallPackageSize);
                recrystallization = new Recrystallization(myProperties);
                buttonCannon.Text = "Leci!";
                StartThreadRecrystallization(0);

            }
            else
            {
                StopThreadRecrystallization();
                buttonCannon.Text = "Ognia";
            }
        }

        private void buttonDisDensityDraw_Click(object sender, EventArgs e)
        {
            drawMicrostructure();
        }

        private void buttonMicro_Click(object sender, EventArgs e)
        {
            //tableLayoutPanel1.Width = 100;
            drawUniverse();
            
        }

        private void buttonStartRecrystal_Click(object sender, EventArgs e)
        {
            flagRecrystallization = !flagRecrystallization;
            if (flagRecrystallization == true)
            {
                StopThreadRecrystallization();
                buttonStartRecrystal.Text = "Rekrystalizacja";
                StartThreadRecrystallization(1);

            }
            else
            {
                StopThreadRecrystallization();
                buttonStartRecrystal.Text = "Start";
            }
        }

        private void buttonNucleation_Click(object sender, EventArgs e)
        {
            oldUniverse = currentUniverse;
            currentUniverse = recrystallization.nucleation(currentUniverse);
            drawDisclocationDensity();
            buttonNucleation.BeginInvoke((MethodInvoker)delegate
            {
                buttonNucleation.Text = "Koniec";
                
            });
            buttonStartRecrystal.BeginInvoke((MethodInvoker)delegate
            {
                buttonStartRecrystal.Enabled = true;

            });

        }

        private void buttonOldUni_Click(object sender, EventArgs e)
        {
        }
    }
}
