using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingFade : MonoBehaviour
{
    [SerializeField] Image image;
    public string scene;

    private void OnEnable()
    {
        FinalDoor.FinalDoorOpenedEvent += StartFade;
    }

    private void OnDisable()
    {
        FinalDoor.FinalDoorOpenedEvent -= StartFade;
    }

    private void Start()
    {
        image.enabled = false;
    }

    void StartFade()
    {
        image.enabled = true;
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        while(image.color != Color.black)
        {
            image.color = Color.Lerp(image.color, Color.black, Time.deltaTime * 2);
            yield return null;
        }
      

        SceneManager.LoadScene(scene);

    }
}
