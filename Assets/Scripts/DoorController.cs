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
        cam.m_Lens.OrthographicSize = Mathf.Lerp(cam.m_Lens.OrthographicSize, 25.0f, Time.deltaTime);
    }

    public virtual void zoomInCamera()
    {
        Debug.Log("Zoom in");
        //cam.m_Lens.OrthographicSize = Mathf.Lerp(cam.m_Lens.OrthographicSize, 12.22f, Time.deltaTime);
        cam.m_Lens.OrthographicSize = Mathf.Lerp(cam.m_Lens.OrthographicSize, 12.22f, Time.deltaTime);
    }


}
