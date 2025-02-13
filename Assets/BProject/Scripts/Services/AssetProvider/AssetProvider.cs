using System.IO;
using UnityEngine;

namespace BProject.Services
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject Instantiate(string path) 
            => Object.Instantiate(Resources.Load(path)) as GameObject;


        public GameObject Instantiate(string path, Transform parent)
        {
            var founded = Resources.Load(path);

            if (founded == null) throw new FileNotFoundException($"{path} not found");
            
            return Object.Instantiate(founded, parent) as GameObject;
        }
    }
}