using System;
using System.Collections.Generic;

namespace BProject.Core
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, ICanExitState> _states;
        
        private ICanExitState _currentState;

        public GameStateMachine(SceneLoader sceneLoader)
        {
            _states = new Dictionary<Type, ICanExitState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
                [typeof(LoadingState)] = new LoadingState(this, sceneLoader),
                [typeof(GameLoopState)] = new GameLoopState(this, sceneLoader),
            };
        }
        
        public void Enter<TState>() where TState : class, IState
        {
            var state = ChangeState<TState>();

            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            var state = ChangeState<TState>();
            
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, ICanExitState
        {
            _currentState?.Exit();
            
            var state = GetState<TState>();
            
            _currentState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, ICanExitState 
            => _states[typeof(TState)] as TState;
    }
}