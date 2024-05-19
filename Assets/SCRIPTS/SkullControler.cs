using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullControler : MonoBehaviour
{
    [SerializeField] Animator Skull_Animator;
    public virtual void onInteract(GameObject obj)
    {
        if (!Skull_Animator.GetBool("isActivated"))
        {
            PlayerController player = obj.GetComponent<PlayerController>();
            if (player != null)
            {
                player.IncreaseSkullMemory();
            }
            Skull_Animator.SetBool("isActivated", true);
        }
    }
}
