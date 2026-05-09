using System;
using UnityEngine;

public class ReadyManager : MonoBehaviour
{
    [SerializeField] private ReadyStates p1State;
    [SerializeField] private ReadyStates p2State;
    //private event EventHandler timerStarted;
    private float timer=0f;
    private float readyCooldown = 3f;
    private enum ReadyStates
    {
        NOT_READY,
        READY,
    }
    private void Start()
    {
        p1State = ReadyStates.NOT_READY;
        p2State = ReadyStates.NOT_READY;
        GameInput.Instance.OnInteract1Action += GameInput_OnInteract1Action;
    }
    private void Update()
    {
        
        CheckReady();

    }
    private void GameInput_OnInteract1Action(object sender, int pID)
    {
        if (pID == 0)
        {
            if (p1State == ReadyStates.READY)
            {
                p1State = ReadyStates.NOT_READY;
            }
            else if (p1State == ReadyStates.NOT_READY) { 
                p1State  = ReadyStates.READY; 
            }
        }
        else if (pID == 1)
        {
            if (p2State == ReadyStates.READY)
            {
                p2State = ReadyStates.NOT_READY;
            }
            else if (p2State == ReadyStates.NOT_READY)
            {
                p2State = ReadyStates.READY;
            }
        }
    }
    private void CheckReady()
    {
        if(p1State == ReadyStates.READY && p2State == ReadyStates.READY)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                GameManager.Instance.StartGame();
                timer = 3;
            }
           
        }
        else
        {
            timer = readyCooldown;
        }
    }
}
