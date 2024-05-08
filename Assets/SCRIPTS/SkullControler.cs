using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullControler : MonoBehaviour
{
    [SerializeField] Animator Skull_Animator;
    public virtual void onInteract()
    {
        Debug.Log("Sk - Light up - chat cpt");
        Skull_Animator.SetBool("isActivated", true);
    }
}
