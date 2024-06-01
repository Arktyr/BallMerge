using _Scripts.Infrastructure.Installers;
using _Scripts.Infrastructure.Installers.Base;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace _Scripts.Infrastructure.EntryPoints
{
    public class BootstrapEntryPoint : MonoBehaviour
    {
        private const string SCENENAME = "Game";
        
        [SerializeField] private Installer _installer;
        [SerializeField] private int _applicationFps;
        
        private void Awake()
        {
            _installer.InstallBinding();
        }

        private async void Start()
        {
            Application.targetFrameRate = _applicationFps;
            
            await SceneManager.LoadSceneAsync(SCENENAME, LoadSceneMode.Single);
        }
    }
}