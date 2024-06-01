using _Scripts.Infrastructure.Installers;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.Infrastructure.EntryPoints
{
    public class BootstrapEntryPoint : MonoBehaviour
    {
        private const string SCENENAME = "Game";
        
        [SerializeField] private Installer installer;

        
        private void Awake()
        {
            installer.InstallBinding();
        }

        private async void Start()
        {
            await SceneManager.LoadSceneAsync(SCENENAME, LoadSceneMode.Single);
        }
    }
}