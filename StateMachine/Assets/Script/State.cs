
public abstract class State
{
    // Reference to state machine.
    protected StateMachine owner;

    // Called to configuration state
    public virtual void OnStateEnter(StateMachine owner) { this.owner = owner; }
    // Called to update state on Update()
    public virtual void UpdateState() { }
    //  Called to destory state
    public virtual void OnStateExit() { }
    //  Called on click button A
    public virtual void OnClickButtonA() { }
    //  Called on click button B
    public virtual void OnClickButtonB() { }
}
