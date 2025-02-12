using System.Collections;
using BProject.Services;
using UnityEngine;

namespace BProject.Core
{
    public class Game : MonoBehaviour, IRoutineRunner
    {
        public GameStateMachine StateMachine { get; set; }
        
        public Game()
        {
            StateMachine = new GameStateMachine(new SceneLoader(this), AllServices.Instance);
            
            Debug.Log("Game Entered");
        }

        public void StartRoutine(IEnumerator routine)
            => StartCoroutine(routine);
    }
}