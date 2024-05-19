using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    bool stopZoomOut = false;
    bool stopZoomIn = false;
    [SerializeField] public CinemachineVirtualCamera cam;

    public virtual void zoomOutCamera()
    {
        Debug.Log("Zoom out");
        stopZoomIn = true;
        stopZoomOut = false;
        if (cam.m_Lens.OrthographicSize != 20.0f)
            StartCoroutine(ZoomOutCameraAction());
    }

    IEnumerator ZoomOutCameraAction()
    {
        Debug.Log("ZoomOutCameraAction");
        if (!stopZoomOut && cam.m_Lens.OrthographicSize != 25.0f)
        {
            cam.m_Lens.OrthographicSize = Mathf.Lerp(cam.m_Lens.OrthographicSize, 25.0f, Time.deltaTime);
            yield return null;
            StartCoroutine(ZoomOutCameraAction());
        }
    }

    public virtual void zoomInCamera()
    {
        Debug.Log("Zoom in");
        stopZoomOut = true;
        stopZoomIn = false;
        if (cam.m_Lens.OrthographicSize != 12.22f)
            StartCoroutine(ZoomInCameraAction());
    }

    IEnumerator ZoomInCameraAction()
    {
        Debug.Log("ZoomInCameraAction");
        if (!stopZoomIn && cam.m_Lens.OrthographicSize != 12.22f)
        {
            cam.m_Lens.OrthographicSize = Mathf.Lerp(cam.m_Lens.OrthographicSize, 12.22f, Time.deltaTime);
            yield return null;
            StartCoroutine(ZoomInCameraAction());
        }
    }

    public virtual void onInteract(GameObject obj)
    {
        PlayerController player = obj.GetComponent<PlayerController>();
        if (player != null)
        {
            if (player.memoryStele >= 4 && player.memorySkull > 0 && player.memoryTech > 0)
                player.endGame = true;
        }
    }


}
