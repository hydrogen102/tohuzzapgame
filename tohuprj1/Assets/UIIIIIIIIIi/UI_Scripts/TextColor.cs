using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.ShaderGraph;
using UnityEngine.UI;

public class TextColor : MonoBehaviour
{
    private Image tmp;
    [SerializeField] TextMeshProUGUI tmpWonjo;
    float colorR;
    float colorG;
    float colorB;

    float colorRR;
    float colorGG;
    float colorBB;

    void Start()
    {
        tmp = GetComponent<Image>();
        
        StartCoroutine(TextColorChange());
    }

    void Update()
    {
        colorR = Random.Range(0f, 1f);
        colorG = Random.Range(0f, 1f);
        colorB = Random.Range(0f, 1f);

        colorRR = Random.Range(0f, 1f);
        colorGG = Random.Range(0f, 1f);
        colorBB = Random.Range(0f, 1f);
    }

    IEnumerator TextColorChange()
    {
        while (true)
        {
            tmp.color = new Color(colorR, colorG, colorB, 1f);
            tmpWonjo.color = new Color(colorRR, colorGG, colorBB, 1f);

            yield return new WaitForSeconds(0.2f);
        }        
    }
}
