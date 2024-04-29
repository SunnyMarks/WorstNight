using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BatteryUI : MonoBehaviour
{
    TextMeshProUGUI tmp;
    [SerializeField] Player_SO player;

    void Start()
    {
        tmp = gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        Battery.batteryCollectedEvent += UpdateText;
        FlashlightController.batteryUsedEvent += UpdateText;
    }

    private void OnDisable()
    {
        Battery.batteryCollectedEvent -= UpdateText;
        FlashlightController.batteryUsedEvent += UpdateText;
    }

    void UpdateText()
    {
        tmp.text = player.batteries.ToString();
    }
}
