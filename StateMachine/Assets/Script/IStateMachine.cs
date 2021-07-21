public interface IStateMachine
{
    // Properties
    float MainTimer { get; set; }
    IDisplay Display { get; set; }

    // Method to change state
    void ChangeState(State newState);
}
