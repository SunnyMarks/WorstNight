using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartScenePause : MonoBehaviour
{
    public GameObject Popup;
    public GameObject SceneStart;

    private void Start()
    {
        Time.timeScale = 0;
        SceneStart.SetActive(true);
    }
    public void OnSceneStart()
    {
        if (Input.GetButton("StartButton"))
        {
            Time.timeScale = 1;
            SceneStart.SetActive(false);
        }
    }

    public void DestroyThisObject()
    {
        Destroy(Popup);
    }

}
