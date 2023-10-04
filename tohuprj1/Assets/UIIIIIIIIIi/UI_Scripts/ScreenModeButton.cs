using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenModeButton : MonoBehaviour
{
    [SerializeField] GameObject ScreenSettingPanel;
    bool isOnOff = false;

    private void Start()
    {
        ScreenSettingPanel.SetActive(false);        
    }
    public void OnOff()
    {
        if (isOnOff)
        {
            ScreenSettingPanel.SetActive(false);
            isOnOff = false;
        }
        else if(!isOnOff)
        {
            ScreenSettingPanel.SetActive(true);
            isOnOff = true;
        }
    }
}
