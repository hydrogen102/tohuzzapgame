using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class BackBottonClick : MonoBehaviour
{
    [SerializeField]
    GameObject settingPanel;

    [SerializeField] bool isPanelOn;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPanelOn)
        {
            settingPanel.transform.DORotate(new Vector3(0f, 0f, 360f), 0.35f);
            settingPanel.transform.DOScale(new Vector3(0.8f, 0.8f, 1f), 0.35f);
            isPanelOn = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPanelOn)
        {
            settingPanel.transform.DORotate(new Vector3(0f, 0f, 180f), 0.35f);
            settingPanel.transform.DOScale(new Vector3(0f, 0f, 0f), 0.35f);
            isPanelOn = false;
        }
    }

    public void BackBottonClicked()
    {
        if (isPanelOn)
        {
            settingPanel.transform.DORotate(new Vector3(0f, 0f, 180f), 0.35f);
            settingPanel.transform.DOScale(new Vector3(0f, 0f, 0f), 0.35f);
            isPanelOn = false;
        }
    }
}
