using System;
using System.Collections.Generic;
using Game.SM.Gameplay;
using Game.SM.Gameplay.Data;

namespace Game.SM
{
    [Serializable]
    public class SMGameplay
    {
        public SMState CurrentState = null;

        public readonly Dictionary<GameplayState, SMState> states = new Dictionary<GameplayState, SMState>()
        {
            { GameplayState.warmup, new GameplayWarmupState() },
            { GameplayState.playGame, new GameplayPlayState() },
            { GameplayState.finishGame, new GameplayFinishState() }
        };

        public enum GameplayState
        {
            warmup = 0,
            playGame = 1,
            finishGame = 2
        }

        public void Init()
        {
            states[GameplayState.warmup].Init(
                new GameplayWarmupStateData(
                    this
                )
            );
            states[GameplayState.playGame].Init(
                new GameplayPlayStateData(
                    this
                )
            );
            states[GameplayState.finishGame].Init(
                new GameplayFinishStateData(
                    this
                )
            );

            ChangeState(GameplayState.warmup);
        }

        public void UpdateSM()
        {
            CurrentState.Loop();
        }

        public void ChangeState(GameplayState state)
        {
            if(CurrentState != null) CurrentState.Exit();

            CurrentState = states[state];
            CurrentState.Enter();
        }
    }
}