using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteleController : MonoBehaviour
{
    [SerializeField] Animator Stele_Animator;
    public virtual void onInteract(GameObject obj)
    {
        if(!Stele_Animator.GetBool("isActivated"))
        {
            PlayerController player = obj.GetComponent<PlayerController>();
            if(player != null)
            {
                player.IncreaseSteleMemory();
            }
            Stele_Animator.SetBool("isActivated", true);
        }
    }
}
