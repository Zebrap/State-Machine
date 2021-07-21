using UnityEngine.Events;

public interface IDisplay
{
    // Evvents on click buttons
    event UnityAction action_OnClickButtonA;
    event UnityAction action_OnClickButtonB;

    // Methods enable/disable buttons and set text on them
    void SetButtonA(bool isActive, string textOnButton);
    void SetButtonA(bool isActive);
    void SetButtonB(bool isActive, string textOnButton);
    void SetButtonB(bool isActive);

    // Methods enable/disable timers text
    void ActiveMainMenuTimer();
    void SetAniamtionTimer(bool isActive);

    // Methods update counter in timer text
    void UpdateAnimationTimer(float timer);
    void UpdateMainMenuTimer(float timer);
    
    // Method set name of current state on text
    void UpdateStateNameText(string name);
}
