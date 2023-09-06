using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackBottonClick : MonoBehaviour
{
    [SerializeField]
    GameObject settingPanel;

    [SerializeField] bool isPanelOn;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && !isPanelOn)
        {
            settingPanel.SetActive(true);
            isPanelOn = true;
        }
    }

    public void BackBottonClicked()
    {
        if (isPanelOn)
        {
            settingPanel.SetActive(false);
            isPanelOn = false;
        }
    }
}
