using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlashLightUI : MonoBehaviour
{
    TextMeshProUGUI tmp;
    [SerializeField] Player_SO player;

    void Start()
    {
        tmp = gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        FlashlightController.batteryDrainedEvent += UpdateText;
        FlashlightController.batteryUsedEvent += UpdateText;
    }

    private void OnDisable()
    {
        FlashlightController.batteryDrainedEvent -= UpdateText;
        FlashlightController.batteryUsedEvent -= UpdateText;
    }

    void UpdateText()
    {
        tmp.text = string.Format("{0:0}", player.charge) + "%";
        
        if (player.charge <= 25)
        {
            
            tmp.color = Color.red;
            return;
        }
        else if (player.charge > 25 && player.charge < 50)
        {
            tmp.color = Color.yellow;
        }
        else
        {
            tmp.color = Color.white;
        }

    }


}
