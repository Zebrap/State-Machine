using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incjetor : MonoBehaviour
{
    [SerializeField] Display display;
    [SerializeField] StateMachine stateMachine;
    
    private void Awake() {
        stateMachine.Display = display;
    }

}
