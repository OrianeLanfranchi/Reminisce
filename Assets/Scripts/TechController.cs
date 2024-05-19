using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechController : MonoBehaviour
{
    [SerializeField] Animator Tech_Animator;
    public virtual void onInteract(GameObject obj)
    {
        if (!Tech_Animator.GetBool("isActivated"))
        {
            PlayerController player = obj.GetComponent<PlayerController>();
            if (player != null)
            {
                player.IncreaseTechMemory();
            }
            Tech_Animator.SetBool("isActivated", true);
        }
    }
}
