using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteleController : MonoBehaviour
{
    [SerializeField] Animator Stele_Animator;
    public virtual void onInteract()
    {
        Stele_Animator.SetBool("isActivated", true);

    }
}
