using System;
using System.Collections.Generic;
using Game.SM.Gameloop;
using Game.SM.Gameloop.Data;
using UnityEngine;

namespace Game.SM
{
    [Serializable]
    public class SMGameloop
    {
        public SMState CurrentState = null;

        public readonly Dictionary<GameloopState, SMState> states = new Dictionary<GameloopState, SMState>()
        {
            { GameloopState.init, new SMGameloopInitState() },
            { GameloopState.mainMenu, new SMGameloopMenuState() },
            { GameloopState.gameplay, new SMGameloopGameplayState() }
        };

        public enum GameloopState
        {
            init = 0,
            mainMenu = 1,
            gameplay = 2
        }

        public void Init()
        {
            states[GameloopState.init].Init(
                new GameLoopInitStateData(this)
            );
            states[GameloopState.mainMenu].Init(
                new GameLoopMenuStateData(this)
            );
            states[GameloopState.gameplay].Init(
                new GameLoopGameplayStateData(this)
            );

            ChangeState(GameloopState.init);
        }

        public void UpdateSM()
        {
            CurrentState.Loop();
        }

        public void ChangeState(GameloopState state)
        {
            if(CurrentState != null) CurrentState.Exit();

            CurrentState = states[state];
            CurrentState.Enter();
        }
    }
}