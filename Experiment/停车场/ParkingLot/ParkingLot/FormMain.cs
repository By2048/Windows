using ParkingLot.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingLot
{
    public partial class FormMain : Form
    {

        static int maxNum = 4;
        public static int maxTime = 8;
        public static int minTime = 3;
        static int CarCreateInternal = 8;   //产生车子的间隔
        int empty;//空余车位
        Car[] isIn = new Car[maxNum]; //停车位状态
        List<PictureBox> parkCarImage = null; //显示停车的pictureBox集合

        Semaphore sema = new Semaphore(maxNum, maxNum);
        Queue<Car> cars = new Queue<Car>();

        delegate void CarLeaveHandler(Car car);
        event CarLeaveHandler CarLeave; 

        Thread carCreate;
        Random ran = new Random(DateTime.Now.Millisecond);
        List<Thread> toParks = new List<Thread>();

        List<PictureBox> pictureBoxs = new List<PictureBox>();


        public FormMain()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Text = "停车时间 3-8 秒不等";

            pictureBoxs.Add(pictureBox1);
            pictureBoxs.Add(pictureBox2);
            pictureBoxs.Add(pictureBox3);
            pictureBoxs.Add(pictureBox4);

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            CenterToScreen();

            Start();
            carCreate = new Thread(new ThreadStart(CarIn));//造车线程
            CarLeave += new CarLeaveHandler(CarLeaved); //绑定委托事件
            carCreate.Start(); //开始造车


            labelWait.Text = "等待的数量 " + cars.Count.ToString();
            labelLast.Text = "剩余的停车位 " + empty.ToString();
        }
        private void Start()
        {//初始化数据

            empty = maxNum;
            isIn = new Car[maxNum];
            foreach (Thread t in toParks)
            {
                if (t.IsAlive)
                    t.Abort();
            }
            toParks.Clear();

            sema = new Semaphore(maxNum, maxNum);
            parkCarImage = new List<PictureBox>(maxNum);
            cars = new Queue<Car>();//等待的车子

            for (int i = 0; i < maxNum; i++)
            {
                pictureBoxs[i].BackColor = Color.Red;
            }
            listBox.Items.Add("停车场开始");
            listBox.TopIndex = listBox.Items.Count - 1;
        }

        private void CarIn()
        {
            while (cars.Count < 20)
            {
                Car car = new Car(this);
                listBox.Items.Add(DateTime.Now.ToString() + " " + "来了一辆车");
                listBox.TopIndex = listBox.Items.Count - 1;

                cars.Enqueue(car);
                labelWait.Text = "等待的数量 " + cars.Count.ToString();
                Thread aThread = new Thread(new ThreadStart(ToPark));
                toParks.Add(aThread);
                aThread.Start();
                Thread.Sleep(ran.Next(CarCreateInternal) + 1000);
            }
        }
        private bool HaveDepot()
        {
            for (int i = 0; i < isIn.Length; i++)
            {
                if (isIn[i] == null)
                {
                    return true;
                }
            }
            return false;
        }

        public void ToPark()
        {
            int i;
            Car car;
            sema.WaitOne();

            lock (this)
            {
                car = cars.Dequeue();
                for (i = 0; i < isIn.Length; i++)
                {
                    if (isIn[i] == null)
                    {
                        isIn[i] = car;
                        empty--;
                        car.ParkNum = i;
                        break;
                    }
                }
            }
            if (i == isIn.Length)
            {
                listBox.TopIndex = listBox.Items.Count - 1;
            }
            else
            {
                listBox.Items.Add(string.Format("{0}  Car {1} 停入 {2} 号车位", DateTime.Now, car.CarNum, car.ParkNum));
                listBox.TopIndex = listBox.Items.Count - 1;
                ShowInfo();
                car.Parking(i);
            }
        }
        internal void CarLeaveing(Car car)
        {
            if (CarLeave != null)
            {
                Thread.Sleep(2000);
                CarLeave(car);
            }
        }
        internal void CarLeaved(Car car)
        {
            lock (this)
            {
                isIn[car.ParkNum] = null;
                empty++;
                sema.Release();
                listBox.Items.Add(string.Format("{0}  Car {1} 离开 {2} 号车位，停留 {3} 秒钟",
                    DateTime.Now, car.CarNum, car.ParkNum, car.ElapseTime));
                listBox.TopIndex = listBox.Items.Count - 1;

            }
            labelLast.Text = "剩余的停车位 " + empty.ToString();
            ShowInfo();
        }

        private void ShowInfo()
        {
            labelWait.Text = "等待的数量 " + cars.Count.ToString();
            labelLast.Text = "剩余的停车位 " + empty.ToString();
            for (int i = 0; i < isIn.Length; i++)
            {
                if (isIn[i] != null)
                {
                    pictureBoxs[i].BackColor = Color.Black;
                }
                else
                {
                    pictureBoxs[i].BackColor = Color.White;
                }
            }
        }


        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            if (isIn == null) return;
            for (int i = 0; i < isIn.Length; i++)
            {
                if (isIn[i] != null)
                {
                    pictureBoxs[i].BackColor = Color.Black;
                }
                else
                {
                    pictureBoxs[i].BackColor = Color.White;
                }
            }
        }


    }
    public class Car
    {
        FormMain form;
        int place = -1;//停车位
        int elasps = 0;//停车时间
        static int carCount;//
        int carNum;//车号
        int imageid;//车图

        public int Imageid
        {
            get { return imageid; }
        }
        public int CarNum
        {
            get { return carNum; }
        }
        public int ParkNum
        {
            get { return place; }
            set { place = value; }
        }
        public int ElapseTime
        {
            get { return elasps / 1000; }
        }
        public Car(FormMain form)
        {
            this.form = form;           
            Random ran = new Random(DateTime.Now.Millisecond);
            elasps = ran.Next((FormMain.minTime * 1000), FormMain.maxTime * 1000);
            imageid = ran.Next(4) + 1;
            carNum = carCount++;
        }
        public void Parking(int num)
        {
            place = num;
            Thread.Sleep(elasps);
            form.CarLeaveing(this);           
        }
        ~Car()
        {
        }
    }
}
