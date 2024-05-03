using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera vC;

    float startFov = 40;
    [SerializeField] float zoomFov;
    [SerializeField] float speed;

    private void OnEnable()
    {
        DamagePlayer.PlayerDamagedEvent += HurtZoomStart;
    }

    private void OnDisable()
    {
        DamagePlayer.PlayerDamagedEvent -= HurtZoomStart;
    }

    void HurtZoomStart()
    {
        StartCoroutine(HurtZoom());
    }

    private IEnumerator HurtZoom()
    {
        while(vC.m_Lens.FieldOfView > zoomFov)
        {
            vC.m_Lens.FieldOfView = Mathf.MoveTowards(vC.m_Lens.FieldOfView, zoomFov, speed * Time.deltaTime);
            yield return null;
        }
        while(vC.m_Lens.FieldOfView < startFov)
        {
            vC.m_Lens.FieldOfView = Mathf.MoveTowards(vC.m_Lens.FieldOfView, startFov, speed * Time.deltaTime);
            yield return null;
        }
    }

}
