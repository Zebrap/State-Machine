using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation2State : State
{
    private float timer = 10;
    private string textOnButtonA = "Next";
    private bool isStop = false;
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
        // Activate the state change button when the animation is finished
        if(timer <= 0 && !isStop)
        {
            isStop = true;
            owner.Display.SetButtonA(true, textOnButtonA);
        }
    }

    public override void OnClickButtonA()
    {
        if (isStop)
        {
            base.OnClickButtonA();
            // Change state to MenuState
            owner.ChangeState(new MenuState());
        }
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
        // Disable unnecessary objects that have been activated
        owner.Display.SetAniamtionTimer(false);
        owner.Display.SetButtonA(false);
    }
}
