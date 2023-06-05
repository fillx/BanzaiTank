namespace _Scripts.SimpleStateMachine
{
    public interface IStateAction
    {
        void EnterState();
        void ExitState();
        void Update();
        void FixedUpdate();
    }
}