using System;
using UnityEngine;

namespace _Scripts.Gameplay.Services.Score
{
    public class ScoreService : IScoreService
    {
        public float CurrentScore { get; private set; }

        public void AddScore(float points)
        {
            float currentPoints = Mathf.Clamp(points, 0, Single.MaxValue);

            CurrentScore += currentPoints;
        }

        public void ResetScore() => 
            CurrentScore = 0;
    }
}