using System;
using System.Collections.Generic;
using _Scripts.Gameplay.Merge;
using _Scripts.Gameplay.Services.Score;
using _Scripts.Infrastructure.Installers;
using _Scripts.Infrastructure.Services.Game;
using _Scripts.Infrastructure.Singleton;
using UnityEngine;

namespace _Scripts.Gameplay.Services.Merge
{
    public class MergeService : Injectable, IMergeService
    {
        [SerializeField] private List<MergeCellContainer> _mergeCellContainers;
        [SerializeField] private List<MergeCellColumn> _mergeCellColumns;

        private IScoreService _scoreService;
        private IGameService _gameService;

        public override void Inject()
        {
            _scoreService = AllServices.Container.GetSingle<IScoreService>();
            _gameService = AllServices.Container.GetSingle<IGameService>();
        }

        public void Initialize()
        {
            foreach (var cellContainer in _mergeCellContainers)
            {
                cellContainer.OnCombinationSolved += AddPoints;
                cellContainer.Initialize();
            }

            foreach (var cellColumn in _mergeCellColumns)
            {
                cellColumn.OnEndEmptyCells += CheckEmptyCells;
                cellColumn.Initialize();
            }
        }

        private void AddPoints(float value)
        {
            _scoreService.AddScore(value);
            
            SortCells();
        }

        private void SortCells()
        {
            foreach (var column in _mergeCellColumns) 
                column.SortCells();
        }

        private void CheckEmptyCells()
        {
            foreach (var cellColumn in _mergeCellColumns)
            {
                if (cellColumn.IsHaveEmptyCells())
                    return;
            }
            
            _gameService.EndGame();
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
            
            foreach (var cellColumn in _mergeCellColumns) 
                cellColumn.OnEndEmptyCells -= CheckEmptyCells;

        }
    }
}