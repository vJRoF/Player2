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

namespace Player2
{
    public partial class Form1 : Form
    {
        private PlayerHandler _playerHandler;
        public Form1()
        {
            InitializeComponent();

            _playerHandler = new PlayerHandler(axWindowsMediaPlayer1);

            axWindowsMediaPlayer1.URL = @"C:\Users\vladi\torrent\Wednesday.S01.WEBDL.1080p.Rus.Eng\Wednesday.S01E04.WEBDL.1080p.RGzsRutracker.mkv";
        }

        private void button1_Click(object sender, EventArgs e) => SpeedDown();

        private void button2_Click(object sender, EventArgs e) => SpeedUp();

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    SpeedDown();
                    break;
                case Keys.Up:
                    SpeedUp();
                    break;
                case Keys.Left:
                    StepBack();
                    break;
            }
        }

        private void axWindowsMediaPlayer1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                case Keys.Left:
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
            }
        }

        private void SpeedDown()
        {
            var newSpeed = _playerHandler.SpeedDown();
            lSay.Text = $"Скорость {Convert.ToInt32(100 * newSpeed)} %";
        }

        private void SpeedUp()
        {
            var newSpeed = _playerHandler.SpeedUp();
            lSay.Text = $"Скорость {Convert.ToInt32(100 * newSpeed)} %";
        }

        private void StepBack()
        {
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition -= 5;
        }
    }
}