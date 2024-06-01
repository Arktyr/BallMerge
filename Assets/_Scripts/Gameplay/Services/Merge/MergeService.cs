using System;
using System.Collections.Generic;
using _Scripts.Gameplay.Merge;
using UnityEngine;

namespace _Scripts.Gameplay.Services.Merge
{
    public class MergeService : MonoBehaviour, IMergeService
    {
        [SerializeField] private List<MergeCellContainer> _mergeCellContainers;
        [SerializeField] private List<MergeCellColumn> _mergeCellColumns;

        public void Initialize()
        {
            foreach (var cellContainer in _mergeCellContainers)
            {
                cellContainer.OnCombinationSolved += AddPoints;
                cellContainer.Initialize();
            }

            foreach (var cellColumn in _mergeCellColumns) 
                cellColumn.Initialize();
        }

        private void AddPoints(float value)
        {
            Debug.Log(value);
            SortCells();
        }

        private void SortCells()
        {
            foreach (var column in _mergeCellColumns) 
                column.SortCells();
        }
        
        public void ClearCells()
        {
            foreach (var cellColumn in _mergeCellColumns) 
                cellColumn.Clear();
        }

        private void OnDestroy()
        {
            foreach (var cellContainer in _mergeCellContainers) 
                cellContainer.OnCombinationSolved -= AddPoints;

        }
    }
}