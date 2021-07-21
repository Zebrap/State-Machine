using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitState : State
{
    private string textOnButtonA = "Ok";
    private string textOnButtonB = "Exit";
    public override void OnStateEnter(StateMachine owner)
    {
        base.OnStateEnter(owner);
        // Activate the necessary objects
        owner.Display.SetButtonA(true, textOnButtonA);
        owner.Display.SetButtonB(true, textOnButtonB);
    }

    public override void OnClickButtonA()
    {
        base.OnClickButtonA();
        // Change state to MenuState
        owner.ChangeState(new MenuState());
    }

    public override void OnClickButtonB()
    {
        base.OnClickButtonB();
        // Quit application
        Application.Quit();
    }
    public override void OnStateExit()
    {
        base.OnStateExit();
        // Disable unnecessary objects that have been activated
        owner.Display.SetButtonA(false);
        owner.Display.SetButtonB(false);
    }
}
