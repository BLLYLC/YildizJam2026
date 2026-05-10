using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReadyManager : MonoBehaviour
{
    [SerializeField] private ReadyStates p1State;
    [SerializeField] private ReadyStates p2State;
    [SerializeField] private GameObject p1ReadyBackground;
    [SerializeField] private GameObject p2ReadyBackground;
    [SerializeField] private TextMeshProUGUI countdownTMP;
    //private event EventHandler timerStarted;
    private float timer=4f;
    private float readyCooldown = 4f;
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
                p1ReadyBackground.SetActive(false);
            }
            else if (p1State == ReadyStates.NOT_READY) { 
                p1State  = ReadyStates.READY;
                p1ReadyBackground.SetActive(true);
            }
        }
        else if (pID == 1)
        {
            if (p2State == ReadyStates.READY)
            {
                p2State = ReadyStates.NOT_READY;
                p2ReadyBackground.SetActive(false);
            }
            else if (p2State == ReadyStates.NOT_READY)
            {
                p2State = ReadyStates.READY;
                p2ReadyBackground.SetActive(true);
            }
        }
    }
    private void CheckReady()
    {
        if(p1State == ReadyStates.READY && p2State == ReadyStates.READY)
        {
            countdownTMP.text = ((int)timer).ToString();
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                GameManager.Instance.StartGame();
                timer = 4;
            }
           
        }
        else
        {
            countdownTMP.text = "";
            timer = readyCooldown;
        }
    }
}
