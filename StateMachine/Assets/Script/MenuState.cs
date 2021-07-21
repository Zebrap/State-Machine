using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : State
{
    private string textOnButtonA = "Open Animation state";
    private string textOnButtonB = "Open Exit state";
    public override void OnStateEnter(StateMachine owner)
    {
        base.OnStateEnter(owner);
        // Activate the necessary objects
        owner.Display.SetButtonA(true, textOnButtonA);
        owner.Display.SetButtonB(true, textOnButtonB);
        owner.Display.ActiveMainMenuTimer();
        owner.Display.UpdateMainMenuTimer(owner.MainTimer);
    }
    public override void UpdateState()
    {
        base.UpdateState();
        // Update timer
        owner.MainTimer -= Time.deltaTime;
        owner.Display.UpdateMainMenuTimer(owner.MainTimer);
        // Quit application if time limit pass
        if (owner.MainTimer < 0)
        {
            Application.Quit();
        }
    }

    public override void OnClickButtonA()
    {
        base.OnClickButtonA();
        // Change state to AnimationState
        owner.ChangeState(new AnimationState());
    }

    public override void OnClickButtonB()
    {
        base.OnClickButtonB();
        // Change state to ExitState
        owner.ChangeState(new ExitState());
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
        // Disable unnecessary objects that have been activated
        owner.Display.SetButtonA(false);
        owner.Display.SetButtonB(false);
    }
}
