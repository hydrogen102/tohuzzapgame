using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject ExitDisplay;
    [SerializeField] GameObject SettingScene;
    public void NAGAGI()
    {
        ExitDisplay.SetActive(true);
        SettingScene.SetActive(false);
    }
    public void ANNAGA()
    {
        ExitDisplay.SetActive(false);
    }
    public void ExitButton()
    {
        Application.Quit();
    }




    public void SettingSceneOn()
    {
        SettingScene.SetActive(true);
        ExitDisplay.SetActive(false);
    }

    public void SettingSceneOff()
    {
        SettingScene.SetActive(false);
    }
}
