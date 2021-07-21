using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrationState : State
{
    private string textOnButtonA = "Menu";

    public override void OnStateEnter(StateMachine owner)
    {
        base.OnStateEnter(owner);
        // Activate the necessary objects
        owner.Display.SetButtonA(true, textOnButtonA);
    }
    public override void OnClickButtonA() 
    {
        base.OnClickButtonA();
        // Change state to MenuState
        owner.ChangeState(new MenuState());
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
        // Disable unnecessary objects that have been activated
        owner.Display.SetButtonA(false);
    }
}
