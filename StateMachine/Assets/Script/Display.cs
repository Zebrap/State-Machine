using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Display : MonoBehaviour, IDisplay
{
    [SerializeField] private Button buttonA;
    [SerializeField] private Text text_buttonA;
    [SerializeField] private Button buttonB;
    [SerializeField] private Text text_ButtonB;
    [SerializeField] private Text text_StateName;
    [SerializeField] private Text text_MainMenuTimer;
    [SerializeField] private Text text_AnimationTimer;
    public event UnityAction action_OnClickButtonA;
    public event UnityAction action_OnClickButtonB;

    private void Start()
    {
        // Add events to buttons listeners
        buttonA.onClick.AddListener(OnClickButtonA);
        buttonB.onClick.AddListener(OnClickButtonB);
    }
    public void UpdateStateNameText(string name)
    {
        text_StateName.text = name;
    }
    
    #region Buttons
    private void OnClickButtonA()
    {
        action_OnClickButtonA?.Invoke();
    }
    private void OnClickButtonB()
    {
        action_OnClickButtonB?.Invoke();
    }

    public void SetButtonA(bool isActive, string textOnButton)
    {
        buttonA.gameObject.SetActive(isActive);
        text_buttonA.text = textOnButton;
    }
    public void SetButtonB(bool isActive, string textOnButton)
    {
        buttonB.gameObject.SetActive(isActive);
        text_ButtonB.text = textOnButton;
    }
    public void SetButtonA(bool isActive)
    {
        buttonA.gameObject.SetActive(isActive);
    }
    public void SetButtonB(bool isActive)
    {
        buttonB.gameObject.SetActive(isActive);
    }
    #endregion

    #region Timers
    public void ActiveMainMenuTimer()
    {
        text_MainMenuTimer.gameObject.SetActive(true);
    }
    public void UpdateMainMenuTimer(float timer)
    {
        text_MainMenuTimer.text = timer.ToString("F0");
    }
    public void SetAniamtionTimer(bool isActive)
    {
        text_AnimationTimer.gameObject.SetActive(isActive);
    }
    public void UpdateAnimationTimer(float timer)
    {
        text_AnimationTimer.text = timer.ToString("F0");
    }
    #endregion
}
