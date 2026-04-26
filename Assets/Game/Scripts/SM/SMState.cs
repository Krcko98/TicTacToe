using UnityEngine;

namespace Game.SM
{
    public abstract class SMState
    {
        public abstract void Init<T>(T data);
        public abstract void Loop();
        public abstract void Enter();
        public abstract void Exit();
    }
}