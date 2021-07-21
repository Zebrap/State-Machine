using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour, IStateMachine
{
    private State currentState;
    private float mainTimer = 60;
    private IDisplay display;

    #region Properties
    public float MainTimer
    {
        get { return mainTimer; }
        set { mainTimer = value; }
    }
    public IDisplay Display
    {
        get { return display; }
        set
        {
            // Unsubscribe buttons events in change reference
            if (display != null)
            {
                display.action_OnClickButtonA -= OnClickButtonA;
                display.action_OnClickButtonB -= OnClickButtonB;
            }

            display = value;
            // Subscribe buttons events in new referance
            display.action_OnClickButtonA += OnClickButtonA;
            display.action_OnClickButtonB += OnClickButtonB;
        }
    }

#if UNITY_INCLUDE_TESTS
    // Accessors for testing purpose
    public State CurrentState => currentState;
#endif
    #endregion

    private void Start()
    {
        // Load first state
        ChangeState(new CalibrationState());
    }

    private void Update()
    {
        // Update current state
        if (currentState != null)
            currentState.UpdateState();
    }

    private void OnClickButtonA()
    {
        // Call current state method on button A
        if (currentState != null)
            currentState.OnClickButtonA();
    }

    private void OnClickButtonB()
    {
        // Call current state method on button B
        if (currentState != null)
            currentState.OnClickButtonB();
    }

    public void ChangeState(State newState)
    {
        // Destory current state
        if (currentState != null)
        {
            currentState.OnStateExit();
        }
        // Change referance to new state
        currentState = newState;

        // Initialize state
        if (currentState != null)
        {
            display.UpdateStateNameText(currentState.GetType().Name);
            currentState.OnStateEnter(this);
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe buttons events
        display.action_OnClickButtonA -= OnClickButtonA;
        display.action_OnClickButtonB -= OnClickButtonB;
    }
}
