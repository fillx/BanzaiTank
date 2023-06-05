using Zenject;

namespace _Scripts.SimpleStateMachine
{
    public abstract class SimpleStateMachine : ITickable, IFixedTickable, IInitializable
    {
        protected abstract IStateAction CurrentState { get; set; }
        public abstract void Initialize();

        public void ChangeState(IStateAction state)
        {
            if (CurrentState == state)
            {
                return;
            }

            if (CurrentState != null)
            {
                CurrentState.ExitState();
                CurrentState = null;
            }

            CurrentState = state;
            CurrentState.EnterState();
        }

        public virtual void Tick()
        {
            CurrentState.Update();
        }

        public virtual void FixedTick()
        {
            CurrentState.FixedUpdate();
        }
    }
}