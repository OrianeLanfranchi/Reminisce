using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechController : MonoBehaviour
{
    [SerializeField] Animator Tech_Animator;
    public virtual void onInteract()
    {
        Debug.Log("Light up");
        Tech_Animator.SetBool("isActivated", true);
    }
}
