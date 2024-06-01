using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Data.Balls
{
    [CreateAssetMenu(menuName = "Data/Balls", fileName = "BallData")]
    public class BallData : ScriptableObject
    {
        public List<BallConfig> BallConfigs;
    }
}