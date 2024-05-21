using System;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GMS : MonoBehaviour
{
    [SerializeField] private GameObject meteor;
    [SerializeField] private GameObject rock;
    [SerializeField] private TMP_Text scoreTxt;
    [SerializeField] private GameObject Player1;
    [SerializeField] private GameObject Player2;
    public static GMS instance;

    private float time;

    private int count = 0;
    private int mCount = 1;

    public void Start()
    {
        if (instance == null)
            instance = this;
        Player1.gameObject.SetActive(false);
        Player2.gameObject.SetActive(false);
        if(DM.instance.GetMode() == 1)
        {
            Player1.gameObject.SetActive(true);
        }
        if(DM.instance.GetMode() == 2)
        {
            Player1.gameObject.SetActive(true);
            Player2.gameObject.SetActive(true);
        }
        InvokeRepeating("GenerateMeteor", 0f, 1f);
        InitalizeTime();

        switch (DM.instance.GetMode())
        {
            case 1:
                Player1.transform.position = new Vector3(0, 0);
                break;
            case 2:
                Player2.SetActive(true);
                Player1.transform.position = new Vector3(-8, 0);
                Player2.transform.position = new Vector3(8, 0);
                break;
        }
    }

    public void Update()
    {
        time += Time.deltaTime;
        SetTimeTxt();
    }

    public void GenerateMeteor()
    {
        if (count < mCount)
        {
            Instantiate(meteor);
            count++;
        }
        else
        {
            Instantiate(rock);
            count = 0;
        }
    }

    private void InitalizeTime()
    {
        time = 0f;
    }

    private void SetTimeTxt()
    {
        scoreTxt.text = "진행 시간" + "\n" + time.ToString("N2");
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
    }
}