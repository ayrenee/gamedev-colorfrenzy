using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorSwitchText : MonoBehaviour
{
    TextMeshProUGUI textComponent;

    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        if (textComponent == null)
        {
            Debug.LogError("TextMeshProUGUI component not found");
            return;
        }
        StartCoroutine(ChangeColorRoutine());
    }

    IEnumerator ChangeColorRoutine()
    {
        while (true)
        {
            // Change color logic
            if (textComponent != null)
            {
                textComponent.color = new Color(Random.value, Random.value, Random.value);
            }
            else
            {
                Debug.LogError("TextMeshProUGUI component is null");
            }

            yield return new WaitForSeconds(1f); // Change color every second
        }
    }
}