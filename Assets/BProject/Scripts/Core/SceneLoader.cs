using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BProject.Core
{
    public class SceneLoader
    {
        private IRoutineRunner _routineRunner;

        public SceneLoader(IRoutineRunner routineRunner)
        {
            _routineRunner = routineRunner;
        }
        
        public void LoadScene(SceneId sceneId, Action callback = null)
            => _routineRunner.StartRoutine(LoadSceneAsync(sceneId, callback));         

        private IEnumerator LoadSceneAsync(SceneId sceneId, Action callback = null)
        {
            var waitNextScene = SceneManager.LoadSceneAsync((int)sceneId);

            while (!waitNextScene.isDone)
            {
                yield return null;
            }
            
            Debug.Log($"Scene Loaded: {sceneId}");
            
            callback?.Invoke();
        }
    }
}