using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.ShaderGraph;
using UnityEngine.UI;

public class TextColor : MonoBehaviour
{
    private TextMeshProUGUI tmp;
    float colorR;
    float colorG;
    float colorB;

    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        StartCoroutine(TextColorChange());
    }

    void Update()
    {
        colorR = Random.Range(0f, 1f);
        colorG = Random.Range(0f, 1f);
        colorB = Random.Range(0f, 1f);
    }

    IEnumerator TextColorChange()
    {
        while (true)
        {
            tmp.color = new Color(colorR, colorG, colorB, 1f);

            yield return new WaitForSeconds(0.01f);
        }        
    }
}
