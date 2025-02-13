using UnityEngine;

namespace BProject.Services
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject Instantiate(string path) 
            => Object.Instantiate(Resources.Load(path)) as GameObject;

        public GameObject Instantiate(string path, Transform parent) 
            => Object.Instantiate(Resources.Load(path), parent) as GameObject;
    }
}