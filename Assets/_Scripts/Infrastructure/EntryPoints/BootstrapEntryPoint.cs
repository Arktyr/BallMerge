using Infrastructure.Installers;
using UnityEngine;

namespace Infrastructure.EntryPoints
{
    public class BootstrapEntryPoint : MonoBehaviour
    {
        [SerializeField] private Installer installer;

        private void Awake()
        {
            installer.InstallBinding();

        }

        private void Start()
        {
            
        }
    }
}