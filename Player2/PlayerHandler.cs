using System;
using System.Linq;
using Vlc.DotNet.Core;

namespace Player2
{
    internal class PlayerHandler
    {
        private Vlc.DotNet.Forms.VlcControl _player;
        private const double RateStep = 0.1;
        private double[] _speedSet;
        private int _speed;
        private TrackDescription _selectedSubs;

        public PlayerHandler(Vlc.DotNet.Forms.VlcControl player)
        {
            _player= player;

            _speedSet = new[] { 0.25, 0.5, 0.75, 1 };
            _speed = _speedSet.Length - 1;
            _selectedSubs = _selectedSubs = _player.SubTitles.Current;
        }

        public void Play(string fileName)
        {
            _player.Play(new Uri(fileName));
        }

        public double SpeedDown()
        {
            if (_speed > 0)
                _speed--;

            _player.Rate = (float)_speedSet[_speed];
            return _speedSet[_speed];
        }

        public double SpeedUp()
        {
            if (_speed < _speedSet.Length - 1)
                _speed++;

            _player.Rate = (float)_speedSet[_speed];
            return _speedSet[_speed];
        }

        public void SetPosition(double percent)
        {
            _player.Position = (float)percent;
        }

        public void ToggleSubs()
        {
            if (_selectedSubs == null)
                _selectedSubs = _player.SubTitles.Current;

            if (_player.SubTitles.Current.ID == -1)
                _player.SubTitles.Current = _selectedSubs;
            else
                _player.SubTitles.Current = _player.SubTitles.All.Single(s => s.ID == -1);
        }

        ///private TrackDescription Empty = new TrackDescription()
    }
}
