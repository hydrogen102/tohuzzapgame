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
    [SerializeField]
    Sprite clickedSprite;
    [SerializeField]
    Sprite notClickedSprite;

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
            muteBottonImage.sprite = clickedSprite;
            isClicked = true;
        }
        else if (isClicked)
        {
            audioListener.enabled = true;
            muteBottonImage.sprite = notClickedSprite;
            isClicked = false;
        }
    }
}
