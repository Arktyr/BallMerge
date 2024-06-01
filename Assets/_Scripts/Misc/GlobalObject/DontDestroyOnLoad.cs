using System;
using UnityEngine;

namespace _Scripts.Misc.GlobalObject
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        private void Awake() => 
            DontDestroyOnLoad(gameObject);
    }
}