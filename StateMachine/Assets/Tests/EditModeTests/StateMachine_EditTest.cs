using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using NSubstitute;

public class StateMachine_EditTest
{
    private StateMachine stateMachine;
    private IDisplay display;

    private static State[] _states = 
    {
        new CalibrationState(),
        new MenuState(),
        new ExitState(),
        new AnimationState(),
        new Animation2State()
    };

    [OneTimeSetUp]
    public void Setup()
    {
        var GO_StateMachine = new GameObject();
        stateMachine = GO_StateMachine.AddComponent<StateMachine>();

        // Mock testing display
        display = Substitute.For<IDisplay>();
        stateMachine.Display = display;
    }

    // Testing loading of all states
    [TestCaseSource(nameof(_states))]
    public void StateMachine_ChangeStateTest(State state)
    {
        stateMachine.ChangeState(state);
        Assert.AreEqual(state.GetType().Name, stateMachine.CurrentState.GetType().Name);
    }
}
