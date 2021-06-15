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

        public int _SnackX = 0;
        public int _SnackY = 0;
        public Random _r;
        public int _dir = (int)Direction.RIGHT;
        public int _ScoreCount = 1;
        Thread SnackM;
        public Form1()
        {
            InitializeComponent();
            _SnackX = (int)Math.Ceiling((decimal)(panelMap.Width / 2) / 10) * 10;
            _SnackY = (int)Math.Ceiling((decimal)(panelMap.Height / 2) / 10) * 10;

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
            var a = (int)Math.Ceiling((decimal)panelMap.Width / 2);
            labSnack.Location = new Point((int)Math.Ceiling((decimal)(panelMap.Width / 2) / 10) * 10, (int)Math.Ceiling((decimal)(panelMap.Height / 2) / 10) * 10);
            labSnack.Text = "0";
            _r = new Random();
            labFood.Text = "0";
            labFood.Location = new Point((int)Math.Ceiling((decimal)_r.Next(panelMap.Location.X, panelMap.Width) / 10) * 10, (int)Math.Ceiling((decimal)_r.Next(panelMap.Location.Y, panelMap.Height) / 10) * 10);
            KeyPreview = true;
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
                        _SnackY -= 10;
                        if (_SnackY <= panelMap.Location.Y)
                            _SnackY += panelMap.Height;
                        break;
                    case (int)Direction.DOWM:
                        _SnackY += 10;
                        if (_SnackY >= (panelMap.Height + panelMap.Location.Y))
                            _SnackY -= panelMap.Height;
                        break;
                    case (int)Direction.RIGHT:
                        _SnackX += 10;
                        if (_SnackX >= (panelMap.Width + panelMap.Location.X))
                            _SnackX -= panelMap.Width;
                        break;
                    case (int)Direction.LEFT:
                        _SnackX -= 10;
                        if (_SnackX <= panelMap.Location.X)
                            _SnackX += panelMap.Width;
                        break;
                }
                if (labFood.Location.X <= _SnackX && _SnackX <= labFood.Location.X + labFood.Width && labFood.Location.Y <= _SnackY && _SnackY <= labFood.Location.Y + labFood.Height)
                {
                    FoodChange();
                    
                    
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
                if (this.labSnack.InvokeRequired)
                {
                    this.Invoke(
                      new InvokeUpdateState(this.show));
                }
                else
                {  // 原先寫好動作的部分
                    labSnack.Location = new Point(_SnackX, _SnackY);
                }
            }
            catch { }
        }
        private void FoodChange()
        {
            try
            {
                if (this.labSnack.InvokeRequired)
                {
                    this.Invoke(
                      new InvokeFoodChange(this.FoodChange));
                }
                else
                {  // 原先寫好動作的部分
                    labFood.Location = new Point((int)Math.Ceiling((decimal)_r.Next(panelMap.Location.X, panelMap.Width)), (int)Math.Ceiling((decimal)_r.Next(panelMap.Location.Y, panelMap.Height)));
                    labPoint.Text = Convert.ToString(_ScoreCount++);
                }
            }
            catch { }
        }
#endregion
    }
}
