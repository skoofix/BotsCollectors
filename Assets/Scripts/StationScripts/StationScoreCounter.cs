using System;
using UnityEngine;

namespace StationScripts
{
    public class StationScoreCounter : MonoBehaviour
    {
        [SerializeField] private int _maxScore;
        
        public int Score { get; private set; }
        
        public void AddScore(int points)
        {
            if (points < 0)
                throw new Exception("Поинты меньше 0");

            Score += points;

            if (Score >= _maxScore)
                Score = _maxScore;
        }

        public void RemoveScore(int points)
        {
            if (points < 0)
                throw new Exception("Поинты меньше 0");

            Score -= points;

            if (Score < 0)
                Score = 0;
        }
    }
}