using System;
using TMPro;
using UnityEngine;

public class GMS:MonoBehaviour
{
    [SerializeField] private GameObject meteor;
    [SerializeField] private GameObject rock;
    [SerializeField] private TMP_Text scoreTxt;
    public static GMS instance;

    private string pName = "Test";
    private float time;

    private int count = 0;
    private int mCount = 1;
    public void Start()
    {
        if (instance == null)
            instance = this;
        InvokeRepeating("GenerateMeteor", 0f, 1f);
        InitalizeTime();
    }


    public void Update()
    {
        time += Time.deltaTime;
        SetTimeTxt();
    }
    public void GenerateMeteor()
    {
        if(count <mCount)
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
        scoreTxt.text = pName + "\n" + time.ToString("N2");
    }

    public void SetName(string name) { pName = name; }
    public string GetName() { return  pName; }

    public void GameOver()
    {
        Time.timeScale = 0f;
    }
}