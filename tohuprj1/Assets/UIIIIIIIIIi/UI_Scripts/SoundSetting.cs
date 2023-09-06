using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    Slider soundSlider;
    Camera cam;
    AudioListener audioListener;

    private void Start()
    {
        soundSlider = GetComponent<Slider>();
        cam = Camera.main;
        audioListener = cam.GetComponent<AudioListener>();
    }

    private void Update()
    {
        
    }

    private void SoundSet()
    {
        
    }
}
