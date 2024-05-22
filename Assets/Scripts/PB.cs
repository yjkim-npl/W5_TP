using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PB : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject SoundMenu;

    public void PauseBtn()
    {
        MainMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void SoundBtn()
    {
        SoundMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void Continue()
    {
        MainMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void GoToTitle()
    {
        SceneManager.LoadScene("TitleScene");
        Time.timeScale = 1.0f;
    }

    public void Retry()
    {
        SceneManager.LoadScene("SelectScene");
        Time.timeScale = 1.0f;
    }    

    public void GoBack()
    {
        MainMenu.SetActive(true);
        SoundMenu.SetActive(false);
    }
}
