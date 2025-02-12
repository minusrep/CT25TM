using BProject.Core.States;
using UnityEngine;

namespace BProject.Core
{
    public static class Bootstrapper
    {
        private const string GameName = "BProject";
        public static bool IsBootstrapped { get; private set; }
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Bootstrap()
        {
            if (IsBootstrapped) return;
            
            var game = SetupGame();

            game.StateMachine.Enter<BootstrapState>();
            
            IsBootstrapped = true;
        }

        private static Game SetupGame()
        {
            var game = new GameObject(GameName).AddComponent<Game>();
            
            GameObject.DontDestroyOnLoad(game);

            return game;
        }
    }
}