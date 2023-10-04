using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSetting : MonoBehaviour
{

    // Update is called once per frame
    public void FullScreen()
    {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
    }

    public void WindowedMode()
    {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, false);
    }
}
