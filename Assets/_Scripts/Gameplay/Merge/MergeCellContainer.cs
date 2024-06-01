using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Gameplay.Merge
{
    public class MergeCellContainer : MonoBehaviour
    {
        public List<MergeCell> MergeCombination;

        public event Action<float> OnCombinationSolved;
        
        public void Initialize()
        {
            foreach (var cell in MergeCombination) 
                cell.OnBallSetted += CheckCombination;
        }

        private void CheckCombination()
        {
            foreach (var cell in MergeCombination)
            {
                if (cell.IsEmpty)
                    return;
            }
            
            if (IsHaveSimillarColors() == false)
                return;

            float points = MergeCombination[0].CurrentBall.Points;
            
            ClearCells();
            OnCombinationSolved?.Invoke(points);
        }

        private bool IsHaveSimillarColors()
        {
            Color firstColor = MergeCombination[0].CurrentBall.CurrentColor;

            foreach (var cell in MergeCombination)
            {
                Color currentColor = cell.CurrentBall.CurrentColor;

                if (firstColor != currentColor)
                    return false;
            }

            return true;
        }

        public void ClearCells()
        {
            foreach (var cell in MergeCombination) 
                cell.Clear(true);
        }
    }
}