using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationState : State
{
    private float timer = 10;
    public override void OnStateEnter(StateMachine owner)
    {
        base.OnStateEnter(owner);
        // Activate the necessary objects
        owner.Display.SetAniamtionTimer(true);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        // Update counter timer
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            owner.Display.UpdateAnimationTimer(timer);
        }
        // Change the state if the animation is finished
        if(timer <= 0)
        {
            owner.ChangeState(new Animation2State());
        }
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
        // Disable unnecessary objects that have been activated
        owner.Display.SetAniamtionTimer(false);
    }
}
