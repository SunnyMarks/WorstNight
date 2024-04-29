using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlashLightUI : MonoBehaviour
{
    TextMeshProUGUI tmp;

    void Start()
    {
        tmp = gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        FlashlightController.batteryDrainedEvent += UpdateText;
    }

    private void OnDisable()
    {
        FlashlightController.batteryDrainedEvent -= UpdateText;
    }

    void UpdateText(float num)
    {
        //tmp.text = num.ToString();
        tmp.text = string.Format("{0:0}", num) + "%";
    }


}
