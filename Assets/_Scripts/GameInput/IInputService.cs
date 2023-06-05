namespace _Scripts.GameInput
{
    public interface IInputService
    {
        float VerticalAxis { get; }
        float HorizontalAxis { get; }
        bool isActionButtonUp { get; }
        bool isNextWeaponButtonUp { get; }
        bool isPreviousWeaponButtonUp { get; }
    }
}