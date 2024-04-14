using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullControler : MonoBehaviour
{
    [SerializeField] Animator Skull_Animator;
    public virtual void onInteract()
    {
        Debug.Log("Light up");
        Skull_Animator.SetBool("isActivated", true);
    }
}
