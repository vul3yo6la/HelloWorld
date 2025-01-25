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

namespace SnackIt
{
    public partial class Form1 : Form
    {

        public enum Direction : int
        {
            UP = 1,
            DOWM,
            RIGHT,
            LEFT
        }


        private delegate void InvokeUpdateState();
        private delegate void InvokeFoodChange();

        public int _SnackX = 10;
        public int _SnackY = 10;
        public int _FoodX = 0;
        public int _FoodY = 0;
        public int _SnackLong = 2;
        List<int> bodyX = new List<int>();
        List<int> bodyY = new List<int>();
        public Random _r;
        public int _dir = (int)Direction.RIGHT;
        public int _ScoreCount = 1;
        public int test_branch = 8;
        Thread SnackM;

        Color[,] bgColors = new Color[20, 20];
        struct S1
        {
            int A;
            double B;
            char c;
        };
        struct S2
        {
            int A;
            double B;
            char c;
        };
        public Form1()
        {
            InitializeComponent();

            var a = sizeof(char);
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 20; j++)
                    bgColors[i, j] = SystemColors.Control;



        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            BtnStart.Visible = false;
            panelMap.Visible = true;

            SnackM = new Thread(SnackMove);
            GameInit();

        }

        private void EndGame()
        {
            BtnStart.Visible = true;
            panelMap.Visible = false;

        }
        private void GameInit()
        {
            labPoint.Text = "0";


            bgColors[10, 10] = Color.Blue;
            bodyX.Insert(0, 10);
            bodyY.Insert(0, 10);

            _r = new Random();
            bgColors[_r.Next(0, 19), _r.Next(0, 19)] = Color.Red;
            //labFood.Location = new Point((int)Math.Ceiling((decimal)_r.Next(panelMap.Location.X, panelMap.Width) / 10) * 10, (int)Math.Ceiling((decimal)_r.Next(panelMap.Location.Y, panelMap.Height) / 10) * 10);
            KeyPreview = true;
            tableMmap.Refresh();
            SnackM.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    _dir = (int)Direction.UP;
                    break;
                case Keys.Down:
                    _dir = (int)Direction.DOWM;
                    break;
                case Keys.Right:
                    _dir = (int)Direction.RIGHT;
                    break;
                case Keys.Left:
                    _dir = (int)Direction.LEFT;
                    break;
            }


        }
        public void SnackMove()
        {

            while (true)
            {

                switch (_dir)
                {
                    case (int)Direction.UP:
                        _SnackY--;
                        if (_SnackY <= -1)
                            _SnackY = 19;
                        break;
                    case (int)Direction.DOWM:
                        _SnackY++;
                        if (_SnackY >= 20)
                            _SnackY = 0;
                        break;
                    case (int)Direction.RIGHT:
                        _SnackX++;
                        if (_SnackX >= 20)
                            _SnackX = 0;
                        break;
                    case (int)Direction.LEFT:
                        _SnackX--;
                        if (_SnackX <= -1)
                            _SnackX = 19;
                        break;
                }
                if (bgColors[_SnackX, _SnackY] == Color.Red)
                {
                    FoodChange();
                    _SnackLong++;
                    bgColors[_r.Next(0, 19), _r.Next(0, 19)] = Color.Red;

                }
                bodyX.Insert(0, _SnackX);
                bodyY.Insert(0, _SnackY);
                for (int i = 0; i < _SnackLong; i++)
                {                  
                    
                    if(i == _SnackLong - 1) 
                    {
                        bgColors[bodyX[i], bodyY[i]] = SystemColors.Control;
                        bodyX[i] = 0;
                        bodyY[i] = 0;
                    }
                    else
                        bgColors[bodyX[i], bodyY[i]] = Color.Blue;
                }
                Thread.Sleep(100);
                show();
            }
        }

        #region -擴充方法-
        private void show()
        {
            try
            {
                if (this.tableMmap.InvokeRequired)
                {
                    this.Invoke(
                      new InvokeUpdateState(this.show));
                }
                else
                {  // 原先寫好動作的部分
                    tableMmap.Refresh();
                }
            }
            catch { }
        }
        private void FoodChange()
        {
            try
            {
                if (this.labPoint.InvokeRequired)
                {
                    this.Invoke(
                      new InvokeFoodChange(this.FoodChange));
                }
                else
                {  // 原先寫好動作的部分

                    labPoint.Text = Convert.ToString(_ScoreCount++);
                }
            }
            catch { }
        }
        #endregion

        private void tableMmap_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            using (var b = new SolidBrush(bgColors[e.Column, e.Row]))
            {
                e.Graphics.FillRectangle(b, e.CellBounds);
            }
        }
    }

}
