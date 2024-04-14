using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkullGroupController : MonoBehaviour
{
    [SerializeField] List<GameObject> gameObjects;
    public UnityEvent interactAction;

    public virtual void onInteract()
    {

        foreach (GameObject skull in gameObjects)
        {
            interactAction.Invoke();
        }
    }
}
