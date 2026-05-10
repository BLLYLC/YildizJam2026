using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaberAnimator : MonoBehaviour
{
    private const string IS_ATTACK = "IsAttack";


    [SerializeField] private Player player;


    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        //string key sensetive olduðundan mümkün mertebe kaçýn. hata almadan kod çalýþmaz yoksa.
    }

    private void Update()
    {
        animator.SetBool(IS_ATTACK, player.IsAttack());
    }


}
