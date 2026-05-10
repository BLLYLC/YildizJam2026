using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaberAnimator : MonoBehaviour
{
    private const string IS_ATTACK = "IsAttack";
    private const string IS_ATTACK_TRIG = "attackTrigger";

   // [SerializeField] private Player player;


    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        //string key sensetive olduðundan mümkün mertebe kaçýn. hata almadan kod çalýþmaz yoksa.
    }

    private void Update()
    {
        if (animator != null)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Attack();
            }
        }
        else
        {
            Debug.Log("null anim");
        }
    }
    private void Attack()
    {
        //animator.SetBool(IS_ATTACK, player.IsAttack());
        Debug.Log("attack triggered");
        animator.SetTrigger(IS_ATTACK_TRIG);
    }

}
