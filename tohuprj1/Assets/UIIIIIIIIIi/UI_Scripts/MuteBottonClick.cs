using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteBottonClick : MonoBehaviour
{
    Camera mCam;
    AudioListener audioListener;
    [SerializeField]
    Image muteBottonImage;

    bool isClicked = false;

    private void Start()
    {
        mCam = Camera.main;
        audioListener = mCam.GetComponent<AudioListener>();
    }

    public void MuteBottonClicked()
    {
        if(!isClicked)
        {
            audioListener.enabled = false;
            muteBottonImage.color = Color.red;
            isClicked = true;
        }
        else if (isClicked)
        {
            audioListener.enabled = true;
            muteBottonImage.color = Color.white;
            isClicked = false;
        }
    }
}
