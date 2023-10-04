using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject ExitDisplay;
    [SerializeField] GameObject SettingScene;
    [SerializeField] Scrollbar volumeController;
    [SerializeField] AudioSource bgm;
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SettingSceneOn();
        }
        else
        {
            
        }
        bgm.volume = volumeController.value;
    }


    public void SettingSceneOn()
    {
        SettingScene.SetActive(true);
        ExitDisplay.SetActive(false);
        SettingScene.transform.DOLocalMoveX(364f, 0.5f);
    }

    public void SettingSceneOff()
    {
        //SettingScene.SetActive(false);
        SettingScene.transform.DOLocalMoveX(864f, 0.5f);
    }

    public void StartButton()
    {
        int a = Random.Range(0, 5);
        SceneManager.LoadScene(a);
    }
}
