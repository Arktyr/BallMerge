using UnityEngine;

namespace _Scripts.Data.Balls
{
    [CreateAssetMenu(menuName = "Data/Configs/Ball", fileName = "BallConfig")]
    public class BallConfig : ScriptableObject
    {
        public Color Color;
        public int Points;
    }
}