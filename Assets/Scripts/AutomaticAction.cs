using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AutomaticAction : MonoBehaviour
{
    public bool isInRange;
    public UnityEvent interactAction;
    public UnityEvent leavetAction;
    bool wasInRange = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange)
        {
            wasInRange = true;
            Debug.Log("Was in range true");
            interactAction.Invoke();
        }

        if (!isInRange && wasInRange)
        {
            wasInRange = false;
            Debug.Log("Was in range false");
            leavetAction.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player is in range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Player is not in range");
        }
    }
}
