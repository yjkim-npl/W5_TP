using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PB : MonoBehaviour
{
    [SerializeField]
    private GameObject PausePannel;

    public void PauseBtn()
    {
        PausePannel.SetActive(true);
        Time.timeScale = 0f;
    }
}
