using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameManagerSingle : MonoBehaviour
{
    [SerializeField] private GameObject meteor;
    [SerializeField] private GameObject rock;
    [SerializeField] private TMP_Text scoreTxt;
    [SerializeField] private GameObject Player1;
    [SerializeField] private GameObject Player2;
    [SerializeField] private GameObject singleEndPannel;
    [SerializeField] private GameObject multiEndPannel;
    [SerializeField] private TMP_Text winnerPannel;
    [SerializeField] private TMP_Text loserPannel;
    public static GameManagerSingle instance;

    private float time;

    private int count = 0;
    private int mCount = 1;

    public void Start()
    {
        if (instance == null)
            instance = this;
        Player1.gameObject.SetActive(false);
        Player2.gameObject.SetActive(false);
        if(DataManager.instance.GetMode() == 1)
        {
            Player1.gameObject.SetActive(true);
        }
        if(DataManager.instance.GetMode() == 2)
        {
            Player1.gameObject.SetActive(true);
            Player2.gameObject.SetActive(true);
        }
        InvokeRepeating("GenerateMeteor", 0f, 1f);
        InitalizeTime();

        switch (DataManager.instance.GetMode())
        {
            case 1:
                Player1.transform.position = new Vector3(0, 1);
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

    public void GameOver(GameObject loser)
    {
        Time.timeScale = 0f;
        if (DataManager.instance.GetMode() == 1)
        {
            // ranking pannel
            singleEndPannel.gameObject.SetActive(true);
            List<(string, float)> rank = DataManager.instance.GetRankUpto3rd();
            string rnks = string.Format("1위 {0} {1}\n2위 {2} {3}\n3위 {4} {5}",
                rank[0].Item1, rank[0].Item2,
                rank[1].Item1, rank[1].Item2,
                rank[2].Item1, rank[2].Item2);
            singleEndPannel.transform.GetChild(2).GetComponent<TMP_Text>().text = rnks;

            // players score
            string name = DataManager.instance.GetP1Name();
            string score = time.ToString("N1");
            singleEndPannel.transform.GetChild(3).GetComponent<TMP_Text>().text = string.Format("놀이결과: {0} {1}", name, score);
            DataManager.instance.WriteRankToFile(name, time);

        }
        else if (DataManager.instance.GetMode() == 2)
        {
            multiEndPannel.gameObject.SetActive(true);
            //이름 받아오기
            if(loser == Player1)
            {
                loserPannel.text = loser.GetComponentInChildren<TMP_Text>().text;
                winnerPannel.text = Player2.GetComponentInChildren<TMP_Text>().text;
            }
            else if(loser == Player2)
            {
                loserPannel.text = loser.GetComponentInChildren<TMP_Text>().text;
                winnerPannel.text = Player1.GetComponentInChildren<TMP_Text>().text;
            }
            //승 패여부에 따라 판넬에 넣기
        }
    }
}