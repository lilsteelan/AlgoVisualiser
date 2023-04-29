using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace AlgoVisualiser
{
    public partial class Form1 : Form
    {
        public static int iteration;
        public Form1()
        {
            InitializeComponent();
            List<int> numbers = generateList(32);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = "Insertion Sort";
            InsertionSort();
            visualiserPanel.Refresh();
            renderList();
        }

        private void visualiserPanel_Paint(object sender, PaintEventArgs e)
        {
            renderList();
            Console.WriteLine("panel was called");
        }

        public void renderList()
        {
            int listLength = m_numbers.Count();
            int objHeight;
            int objWidth = 10;
            int posX = 10;
            int posY = 215;
            int offsetX = 20;
            SolidBrush sbBlack = new SolidBrush(Color.Black);
            SolidBrush sbGray = new SolidBrush(Color.Gray);
            Graphics g = visualiserPanel.CreateGraphics();

            for (int i = 0; i < listLength; i++)
            {
                objHeight = m_numbers[i];
                //tmp += 1;
                if (i % 2 == 0)//Check if even
                {
                    g.FillRectangle(sbBlack, posX, (posY + ((450 - posY) - objHeight)), objWidth, objHeight); //brush, x,y,sizex,sizey
                    posX += offsetX;
                }
                else //Else change Color
                {
                    g.FillRectangle(sbGray, posX, (posY + ((450 - posY) - objHeight)), objWidth, objHeight);
                    posX += offsetX;
                }
            }
        }

        public List<int> m_numbers;
        public bool m_descending = false;
        public bool m_isSorting = false;

        List<int> generateList(int listLength)
        {
            //Create a list of numbers
            Random rnd = new Random();
            m_numbers = new List<int>();
            for (int i = 0; i < listLength; i++)
            {
                m_numbers.Add(rnd.Next(60, 450));
            }
            return m_numbers;
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            List<int> numbers = generateList(32);
            visualiserPanel.Refresh();
            renderList();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (m_isSorting)
            {
                //
            }
            else
            {
                m_descending = true;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = "Bubble Sort";
            BubbleSort();
            visualiserPanel.Refresh();
            renderList();
        }

        void BubbleSort()
        {
            //foreach (var number in m_numbers)
            //{
            //    Console.WriteLine(number);
            //}
            Console.WriteLine("------------");
            
            bool swapRequired;
            var n = m_numbers.Count();
            SolidBrush sb = new SolidBrush(Color.Red);
            Graphics g = visualiserPanel.CreateGraphics();
            if (m_isSorting)
            {

            }
            else
            {
                m_isSorting = true;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - (1 + i); j++)
                    {
                        swapRequired = false;
                        Refresh();
                        g.FillEllipse(sb, 10 + (20 * j), 10, 20, 20);
                        wait(15);
                        if (!m_descending)
                        {
                            if (m_numbers[j] > m_numbers[j + 1])
                            {
                                var tempVar = m_numbers[j + 1];
                                m_numbers[j + 1] = m_numbers[j];
                                m_numbers[j] = tempVar;
                                swapRequired = true;
                            }
                        }
                        if (m_descending)
                        {
                            if (m_numbers[j] < m_numbers[j + 1])
                            {
                                var tempVar = m_numbers[j + 1];
                                m_numbers[j + 1] = m_numbers[j];
                                m_numbers[j] = tempVar;
                                swapRequired = true;
                            }
                        }
                        if (swapRequired == false)
                        {
                            //break;
                        }

                    }
                }
                m_isSorting = false;
            }
            
        }

        void InsertionSort()
        {
            
            SolidBrush sb = new SolidBrush(Color.Red);
            Graphics g = visualiserPanel.CreateGraphics();
            if (m_isSorting)
            {

            }
            else
            {
                m_isSorting = true;
                for (int i = 0; i < m_numbers.Count(); i++)
                {
                    int current = m_numbers[i];

                    int j = i - 1;
                    if (m_descending)
                    {
                        while (j >= 0 && current > m_numbers[j])
                        {
                            m_numbers[j + 1] = m_numbers[j];
                            j -= 1;
                            Refresh();

                            g.FillEllipse(sb, 10 + (10 * j), 10, 20, 20);
                            wait(15);
                        }
                        m_numbers[j + 1] = current;
                    }
                    if (!m_descending)
                    {
                        while (j >= 0 && current < m_numbers[j])
                        {
                            m_numbers[j + 1] = m_numbers[j];
                            j -= 1;
                            Refresh();
                            g.FillEllipse(sb, 10 + (10 * j), 10, 20, 20);
                            wait(15);
                        }
                        m_numbers[j + 1] = current;
                    }
                }
                m_isSorting = false;
            }
        }

        void Quicksort(int left, int right)
        {
            
            SolidBrush sb = new SolidBrush(Color.Red);
            Graphics g = visualiserPanel.CreateGraphics();
            int i = left;
            int j = right;

            var pivot = m_numbers[(left + right) / 2];
            if (!m_descending)
            {
                m_isSorting = true;
                while (i <= j)
                {
                    Refresh();
                    g.FillEllipse(sb, 10 + (10 * j), 10, 20, 20);
                    wait(15);
                    while (m_numbers[i] < pivot)
                        i++;

                    while (m_numbers[j] > pivot)
                        j--;

                    if (i <= j)
                    {
                        var tmp = m_numbers[i];
                        m_numbers[i] = m_numbers[j];
                        m_numbers[j] = tmp;

                        i++;
                        j--;
                    }
                }

                if (left < j)
                    Quicksort(left, j);

                if (i < right)
                    Quicksort(i, right);
            }
            if (m_descending)
            {
                m_isSorting = true;
                while (i <= j)
                {
                    Refresh();
                    g.FillEllipse(sb, 10 + (10 * j), 10, 20, 20);
                    wait(15);
                    while (m_numbers[i] > pivot)
                        i++;

                    while (m_numbers[j] < pivot)
                        j--;

                    if (i <= j)
                    {
                        var tmp = m_numbers[i];
                        m_numbers[i] = m_numbers[j];
                        m_numbers[j] = tmp;

                        i++;
                        j--;
                    }
                }

                if (left < j)
                    Quicksort(left, j);

                if (i < right)
                    Quicksort(i, right);
            }
            m_isSorting = false;
        }

        void Sleep(int waitTime) //Given in ms
        {
            DateTime time = DateTime.Now;
            int initialTime = time.Millisecond;
            while (true)
            {
                DateTime timetmp = DateTime.Now;
                int currentTime = timetmp.Millisecond;
                if(currentTime - initialTime >= waitTime)
                {
                    return;
                }
                else
                {
                    continue;
                }
            }
        }

        public void Refresh()
        {
            visualiserPanel.Refresh();
        }

        public void wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            // Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                // Console.WriteLine("stop wait timer");
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(m_isSorting == true)
            {

            }
            else
            {
                m_descending = false;
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label3.Text = "Quick Sort";
            Quicksort(0, m_numbers.Count()-1);
            visualiserPanel.Refresh();
            renderList();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
