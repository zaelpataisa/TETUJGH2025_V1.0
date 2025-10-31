using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStartMenu : MonoBehaviour
{
    [Header("UI Pages")]
    public GameObject initialTitle;
    public GameObject infoTitle;

    [Header("UI Buttos")]
    public Button Btn_01;
    public Button Btn_02;
    public Button Btn_03;
    public Button Btn_04;

    public List<Button> returnButtons;

    void Start()
    {
        EnableInitialTitle();
        
        if (Btn_01 != null) Btn_01.onClick.AddListener(ToArmsScene);
        if (Btn_02 != null) Btn_02.onClick.AddListener(ToCarsScene);
        if (Btn_03 != null) Btn_03.onClick.AddListener(EnableInfoTitle);
        if (Btn_04 != null) Btn_04.onClick.AddListener(QuitGame);

        foreach (var item in returnButtons)
        {
            if (item != null) 
            {
                item.onClick.AddListener(EnableInitialTitle);
            }
        }
    }

    public void EnableInitialTitle()
    {
        if (initialTitle != null) initialTitle.SetActive(true);
        if (infoTitle != null) infoTitle.SetActive(false);
    }
    public void ToArmsScene()
    {
        StartCoroutine(ChangeSceneWithDelay("01_Scene_Arms", 1f));
    }
    public void ToCarsScene()
    {
        StartCoroutine(ChangeSceneWithDelay("01_Classroom", 1f));
    }
    public void EnableInfoTitle()
    {
        initialTitle.SetActive(false);
        infoTitle.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }


    IEnumerator ChangeSceneWithDelay(string sceneName, float delayTime)
    {
        initialTitle.SetActive(false);
        infoTitle.SetActive(false);

        yield return new WaitForSeconds(delayTime);

        SceneManager.LoadScene(sceneName);
    }
}
