using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class PanelColor : MonoBehaviour
{
    private Image panelImage;

    private void Start()
    {
        panelImage = GetComponent<Image>();
    }

    private void Update()
    {
        ColorChange();
    }

    private void ColorChange()
    {
        float color = Random.Range(0.0f, 1.0f);
        float color1 = Random.Range(0.0f, 1.0f);
        float color2 = Random.Range(0.0f, 1.0f);

        panelImage.color = new Color(color, color1, color2, 1f);
    }
}
