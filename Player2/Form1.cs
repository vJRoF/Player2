using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

            var fileInfo = new FileInfo(@"C:\Users\vladi\torrent\Wednesday.S01.WEBDL.1080p.Rus.Eng\Wednesday.S01E04.WEBDL.1080p.RGzsRutracker.mkv");
            vlcControl.Play(new Uri(@"C:\Users\vladi\Downloads\Arcane\Arcane.s01e03.avi"));
            _playerHandler = new PlayerHandler(vlcControl);

            //_playerHandler = new PlayerHandler(axWindowsMediaPlayer1);

            //axWindowsMediaPlayer1.URL = @"C:\Users\vladi\torrent\Wednesday.S01.WEBDL.1080p.Rus.Eng\Wednesday.S01E04.WEBDL.1080p.RGzsRutracker.mkv";
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
            //axWindowsMediaPlayer1.Ctlcontrols.currentPosition -= 5;
        }

        private void vlcControl_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var libvlcDir = Path.Combine(currentDirectory, @"libvlc\win-x64");
            var directoryInfo = new DirectoryInfo(libvlcDir);
            e.VlcLibDirectory = directoryInfo;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            var mouseEventArgs = e as MouseEventArgs;
            var percent = Convert.ToDouble(mouseEventArgs.X) / progressBar1.Width;
            _playerHandler.SetPosition(percent);
        }

        private void vlcControl_PositionChanged(object sender, Vlc.DotNet.Core.VlcMediaPlayerPositionChangedEventArgs e)
        {
           var newProgressBarValue = Convert.ToInt32(progressBar1.Maximum * e.NewPosition);
            progressBar1.Invoke(
                (MethodInvoker)delegate 
                {
                    progressBar1.Value = newProgressBarValue;
                }
            );
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _playerHandler.ToggleSubs();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}