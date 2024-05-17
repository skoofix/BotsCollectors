using System;
using UnityEngine;

namespace BaseScripts
{
    public class StationScoreCounter : MonoBehaviour
    {
        private int _maxScore = 100;

        public int Score { get; private set; }

        
        public void AddScore(int points)
        {
            if (points < 0)
                throw new Exception("Начислиил поинты, которые меньше 0");

            Score += points;

            if (Score >= _maxScore)
                Score = _maxScore;
        }
    }
}