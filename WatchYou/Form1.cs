using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace WatchYou
{
    public partial class Form1 : Form
    {
        Thread watch ;
        int a = 0;
        public Form1()
        {
            InitializeComponent();
            watch = new Thread(wat);
            watch.Start();
        }

        public void wat() 
        {
            while (true)
            {
                using (Process pro = Process.GetProcessesByName("SnackIt")[0])
                {
                    if (pro.Responding)
                    {
                        PerformanceCounter ramUsage = new PerformanceCounter("Process", "Working Set - Private", "SnackIt");
                        PerformanceCounter performance = new PerformanceCounter("Memory", "Available MBytes");
                    }
                    else 
                    {
                        a = 1;
                    }
                        


                }
            }
        }
    }
}
