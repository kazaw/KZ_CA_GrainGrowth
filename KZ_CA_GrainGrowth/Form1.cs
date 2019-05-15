using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KZ_CA_GrainGrowth
{
    public partial class Form1 : Form
    {
        [DebuggerDisplay("ID = {id}")]
        public class MyCell
        {
            int id;
            public MyCell(int id)
            {
                this.id = id;
            }
            public void set_id(int id)
            {
                this.id = id;
            }
            public int get_id()
            {
                return this.id;
            }

            public MyCell myclone()
            {
                
                return new MyCell(id);
            }
        }  

        Bitmap image1;
        int meshSizeX;
        int meshSizeY;
        bool flag = false;
        MyCell[,] currentUniverse;
        Color[] colorArray;
        int currentTime;
        //Stworzyć klasę  komórki
        int switchNeighborhood;
        int switchBoundaryCondition;
        int switchGrainGrowthType;

        int amountX;
        int amountY;
        int amountSeed;

        private volatile bool stopThread = false;
        private Thread workThread;

        void initComboBox()
        {
            comboBoxNeighborhood.Items.Add("Von Neumanna");
            comboBoxNeighborhood.Items.Add("Moore");
            comboBoxNeighborhood.Items.Add("Heks Lewe");
            comboBoxNeighborhood.Items.Add("Heks Prawe");
            comboBoxNeighborhood.Items.Add("Heks Losowe");
            comboBoxNeighborhood.Items.Add("Pent Losowe");
            comboBoxNeighborhood.SelectedIndex = 0;

            comboBoxBoundaryCondition.Items.Add("Periodyczne");
            comboBoxBoundaryCondition.Items.Add("Absorbujące");
            comboBoxBoundaryCondition.SelectedIndex = 1;//ZMIENIONY INDEX

            comboBoxGrainGrowthType.Items.Add("Jednorodne");
            comboBoxGrainGrowthType.Items.Add("Losowe");
            comboBoxGrainGrowthType.Items.Add("Z promieniem");
            comboBoxGrainGrowthType.Items.Add("Wybór Użytkownika");
            comboBoxGrainGrowthType.SelectedIndex = 0;
        }

        void initForm()
        {
            pictureBox1.Size = new Size(1000, 500);
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
            numericUpDownAmountX.Value = 10;
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

            amountX = (int)numericUpDownAmountX.Value;
            amountY = (int)numericUpDownAmountY.Value;
            
            amountSeed = 0;//TODO: Policzyc to//najlepiej przypisać to pozniej bo klikanie bd to zwiększać


            currentUniverse = new MyCell[meshSizeX + 2, meshSizeY + 2]; ;
            currentTime = 0;

            seed();
            setBoundaryCondition();
            drawUniverse();
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
                        if (missCount >= 1000) break;

                    }
                    
                    break;
                case 3://Wybór Uzytkownika nie działa
                    drawUniverse();
                    break;
                default:
                    break;
            }
            colorArray = new Color[amountSeed];
            createColorArray();
        }

        private int getNeighborhood(MyCell[,] last, int x, int y)
        {
            Random random = new Random();
            List<int> countList = new List<int>();
            List<int> idList = new List<int>();
            int id;
            int tmp = 0;
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
            flag = false;
            buttonStart.BeginInvoke((MethodInvoker)delegate
            {
                buttonStart.Text = "Start";
                buttonStart.Enabled = false;
            });
            return;
        }

        private void StartThread()
        {
            if (workThread == null)
            {
                stopThread = false;
                workThread = new Thread(new ThreadStart(startGrowth));
                workThread.Start();
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
        private void createColorArray()
        {
            Random random = new Random();    
            for (int i = 0; i < amountSeed; i++)
            {
                colorArray[i] = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
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
            pictureBox1.Image = image1;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            flag = !flag;
            if (flag == true)
            {
                //initGrowth();
                buttonStart.Text = "Stop";
                StartThread();
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
            flag = false;
            initGrowth();
        }

     
    }
}
