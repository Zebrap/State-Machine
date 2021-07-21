using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using System.Reflection;
using System;

public class StateMachine_PlayTest
{
    private StateMachine stateMachine;
    private IDisplay display;

    private Button buttonA;
    private Text text_buttonA;
    private Button buttonB;
    private Text text_ButtonB;
    private Text text_StateName;
    private Text text_MainMenuTimer;
    private Text text_AnimationTimer;

    [OneTimeSetUp]
    public void Setup()
    {
        stateMachine = CreatComponent(typeof(StateMachine)) as StateMachine;
        display = CreatComponent(typeof(Display)) as Display;

        // dependancy for display
        buttonA = CreatComponent(typeof(Button)) as Button;
        text_buttonA = CreatComponent(typeof(Text)) as Text;
        buttonB = CreatComponent(typeof(Button)) as Button;
        text_ButtonB = CreatComponent(typeof(Text)) as Text;
        text_StateName = CreatComponent(typeof(Text)) as Text;
        text_MainMenuTimer = CreatComponent(typeof(Text)) as Text;
        text_AnimationTimer = CreatComponent(typeof(Text)) as Text;

        // injecting prite fields display 
        var privateFieldAccessFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Default;
        Type type = display.GetType();
        type.GetField("buttonA", privateFieldAccessFlags)?.SetValue(display, buttonA);
        type.GetField("text_buttonA", privateFieldAccessFlags)?.SetValue(display, text_buttonA);
        type.GetField("buttonB", privateFieldAccessFlags)?.SetValue(display, buttonB);
        type.GetField("text_ButtonB", privateFieldAccessFlags)?.SetValue(display, text_ButtonB);
        type.GetField("text_StateName", privateFieldAccessFlags)?.SetValue(display, text_StateName);
        type.GetField("text_MainMenuTimer", privateFieldAccessFlags)?.SetValue(display, text_MainMenuTimer);
        type.GetField("text_AnimationTimer", privateFieldAccessFlags)?.SetValue(display, text_AnimationTimer);

        // inject statemachine
        stateMachine.Display = display;
    }

    // AddComponent to object
    private Component CreatComponent(Type componentType)
    {
        var GO = new GameObject();
        return GO.AddComponent(componentType);
    }

    // Set first state after each test
    [TearDown]
    public void TearDown()
    {
        State state = new CalibrationState();
        stateMachine.ChangeState(state);
    }

    // Test timer in MenuState
    [UnityTest]
    public IEnumerator StateMachine_MenuTimer([Random(0.05f, 0.25f, 10)] float timeWait)
    {
        State state = new MenuState();
        stateMachine.ChangeState(state);
        
        // Reset Menu timer if it is too low
        if (stateMachine.MainTimer < timeWait)
        {
            stateMachine.MainTimer = 60;
        }
        float timer = stateMachine.MainTimer;
        yield return new WaitForSeconds(timeWait);
        timer -= timeWait;
        Assert.AreEqual(timer, stateMachine.MainTimer, 0.005f);
    }

    // Test Menu Timer stop in other states
    [UnityTest]
    public IEnumerator StateMachine_MenuTimerStop([Random(0.1f, 0.25f, 5)] float timeWait)
    {
        State state = new MenuState();
        stateMachine.ChangeState(state);
        // Change to other state
        buttonB.onClick.Invoke();

        float timer = stateMachine.MainTimer;
        yield return new WaitForSeconds(timeWait);
        // Back to Menu state after time
        buttonA.onClick.Invoke();
        Assert.AreEqual(timer, stateMachine.MainTimer, 0.005f);
    }

    // Test AnimationState auto change state after time
    [UnityTest]
    public IEnumerator StateMachine_AnimationStateFlow()
    {
        State state = new AnimationState();
        stateMachine.ChangeState(state);
        Assert.AreEqual(state.GetType().Name, stateMachine.CurrentState.GetType().Name);

        float animationTime = 10f;
        yield return new WaitForSeconds(animationTime);

        state = new Animation2State();
        Assert.AreEqual(state.GetType().Name, stateMachine.CurrentState.GetType().Name);
    }

    // Test Animation2State can change state after time
    [UnityTest]
    public IEnumerator StateMachine_Animation2StateFlow()
    {
        State state = new Animation2State();
        stateMachine.ChangeState(state);
        Assert.AreEqual(state.GetType().Name, stateMachine.CurrentState.GetType().Name);

        // Button should not work before finished animation
        buttonA.onClick.Invoke();
        Assert.AreEqual(state.GetType().Name, stateMachine.CurrentState.GetType().Name);

        float animationTime = 10f;
        yield return new WaitForSeconds(animationTime);

        buttonA.onClick.Invoke();
        state = new MenuState();
        Assert.AreEqual(state.GetType().Name, stateMachine.CurrentState.GetType().Name);
    }
}
