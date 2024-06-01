using System;
using System.Collections.Generic;
using _Scripts.Gameplay.Balls;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Gameplay.Merge
{
    public class MergeCellColumn : MonoBehaviour
    {
        [SerializeField] private BallTrigger _ballTrigger;
            
        public List<MergeCell> MergeCells;

        public void Initialize()
        {
            _ballTrigger.OnBallLanded += SetInEmptyCell;
        }

        private async void SetInEmptyCell(Ball ball)
        {
            foreach (var cell in MergeCells)
            {
                if (cell.IsEmpty == false)
                    continue;
                
                cell.SetBall(ball);
                return;
            }
            
            ball.Destroy();
        }

        public void SortCells()
        {
            List<Ball> cachedBalls = new List<Ball>();

            foreach (var cell in MergeCells)
            {
                if (cell.IsEmpty)
                    continue;
                
                cachedBalls.Add(cell.CurrentBall);
                
                cell.Clear(false);
            }

            foreach (var ball in cachedBalls) 
                SetInEmptyCell(ball);

        }
        
        public void Clear()
        {
            foreach (var cell in MergeCells) 
                cell.Clear(true);
        }

        private void OnDestroy()
        {
            _ballTrigger.OnBallLanded -= SetInEmptyCell;
        }
    }
}