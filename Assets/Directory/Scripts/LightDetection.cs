using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDetection : MonoBehaviour
{
    float maxIntensity = 1;
    Light l;
    [SerializeField] float multiplier;
    bool isLigthing;

    [SerializeField] Player_SO player;
    private void Start()
    {
        l = gameObject.GetComponent<Light>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Light")
        {
            if(player.isFlashLightOn)
            {
                isLigthing = true;
                StartCoroutine(FadeLightIn());
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Light"))
        {
            if (player.isFlashLightOn)
            {
                isLigthing = true;
                StartCoroutine(FadeLightIn());
            }
            else
            {
                isLigthing = false;
                StartCoroutine(FadeLightOut());
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Light")
        {
            isLigthing = false;
            StartCoroutine(FadeLightOut());
        }
    }

    

    IEnumerator FadeLightIn()
    {
        while(l.intensity < 1 && isLigthing)
        {
            l.intensity += multiplier * Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator FadeLightOut()
    {
        yield return new WaitForSeconds(.6f);

        while (l.intensity > 0 && !isLigthing)
        {
            l.intensity += -multiplier * Time.deltaTime;
            yield return null;
        }
    }




}
