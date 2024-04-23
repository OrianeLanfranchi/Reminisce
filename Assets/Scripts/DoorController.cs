using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    [SerializeField] public CinemachineVirtualCamera cam;

    public virtual void zoomOutCamera()
    {
        Debug.Log("Zoom out");
        while(cam.m_Lens.OrthographicSize != 20.0f)
            cam.m_Lens.OrthographicSize = Mathf.Lerp(cam.m_Lens.OrthographicSize, 20.0f, Time.deltaTime);
        Debug.Log("chat cpluspt");
    }

    public virtual void zoomInCamera()
    {
        Debug.Log("Zoom in");
        while(cam.m_Lens.OrthographicSize != 12.22f)
            cam.m_Lens.OrthographicSize = Mathf.Lerp(cam.m_Lens.OrthographicSize, 12.22f, Time.deltaTime);
    }


}
