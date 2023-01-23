namespace Player2
{
    internal class PlayerHandler
    {
        private Vlc.DotNet.Forms.VlcControl _player;
        private const double RateStep = 0.1;
        private double[] _speedSet;
        private int _speed;

        public PlayerHandler(Vlc.DotNet.Forms.VlcControl player)
        {
            _player= player;

            _speedSet = new[] { 0.25, 0.5, 0.75, 1 };
            _speed = _speedSet.Length - 1;
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
    }
}
