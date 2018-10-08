using System;
namespace GuessItGame
{
    public class Game
    {
        // Game configuration
        private int _attemptLimit;

        // Round configuration
        private int _answer;
        private int _playerAttempts;

        private Random _random;

        public Game(int minNumber, int maxNumber, int attemptLimit)
        {
            _random = new Random();
            _attemptLimit = attemptLimit;
            _answer = _random.Next(minNumber, maxNumber + 1);
            _playerAttempts = 0;
        
        }

        public void NewRound(int minNumber, int maxNumber) {
            _answer = _random.Next(minNumber, maxNumber + 1);
            _playerAttempts = 0;
        }

        public bool CheckGuess(int guess) {
            if (ReachedAttemptLimit()) {
                return false;
            }

            _playerAttempts++;
            return guess == _answer;
        }

        public int GetRemaingNumberOfAttempts() {
            return _attemptLimit - _playerAttempts;
        }

        public bool ReachedAttemptLimit() {
            return _playerAttempts == _attemptLimit;
        }

    }
}
