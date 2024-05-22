using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GS : MonoBehaviour
{
    public void GameStartBtn()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
            StartCoroutine(loadSelectScene());
        
        else if (SceneManager.GetActiveScene().buildIndex == 1)
            StartCoroutine(loadMainScene());
    }

    IEnumerator loadSelectScene()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("SelectScene");
        StopCoroutine(loadSelectScene());
    }

    IEnumerator loadMainScene()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("MainScene");
        StopCoroutine(loadMainScene());
    }
}