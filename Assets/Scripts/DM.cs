using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DM:MonoBehaviour
{
    public static DM instance;

    private int Lvl;
    private int Mode;
    private int p1chara;
    private int p2chara;
    private string p1Name;
    private string p2Name;

    public List<string> wordsE;
    public List<string> wordsN;
    public List<string> wordsH;
    #region Get, Set field value
    public int GetLvl() { return Lvl; }
    public int GetMode() { return Mode;}
    public int GetP1Chara() { return p1chara; }
    public int GetP2Chara() { return p2chara; }
    public string GetP1Name() { return p1Name; }
    public string GetP2Name() { return p2Name; }
    public void SetLvl(int lvl) { Lvl = lvl; }
    public void SetMode(int mode) { Mode = mode; }
    public void SetP1Chara(int chara) { p1chara = chara; }
    public void SetP2Chara(int chara) { p2chara = chara; }
    public void SetP1Name(string name) { p1Name = name;}
    public void SetP2Name(string name) { p2Name = name;}
    #endregion
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            LoadWords();
            DontDestroyOnLoad(this);
        }
        else
        {
            Init();
        }
    }

    public void Init()
    {
       Lvl = 0;
       Mode = 0;
       p1chara = 0;
       p2chara = 0;
       p1Name = "";
       p2Name = "";
    }

    private void LoadWords()
    {
        wordsE = new List<String>();
        wordsN = new List<String>();
        wordsH = new List<String>();
        StreamReader sr = new StreamReader("./Assets/Scripts/words.txt");
        string line = sr.ReadLine(); // Initialize & remove dummy row
        while(line != null)
        {
            line = sr.ReadLine();
            if (line == null)
                continue;
            List<string> ele = line.Split(' ').ToList();
            wordsE.Add(ele[0]); // easy
            wordsN.Add(ele[1]); // normal
            wordsH.Add(ele[2]); // hard
        }
        sr.Close();
    }

    internal List<(string, float)> GetRankUpto3rd()
    {
        List<(string,float)> lisRank = new List<(string,float)>();
        List<(string,float)> lisTemp = new List<(string,float)>();
        StreamReader sr = new StreamReader("./Assets/Scripts/rank.txt");
        string line = sr.ReadLine(); // Initialzie & remove dummy line
        while(line != null)
        {
            line = sr.ReadLine();
            if (line == null)
                continue;
            string[] ele = line.Split(" ");
            lisTemp.Add((ele[0], float.Parse(ele[1])));
        }
        sr.Close();

        // Judge the minimum time on the lists
        string[] player = new string[3] {"None","None","None"};
        float[] min = new float[3] { 0f,0f,0f};
        foreach(var i in lisTemp)
        {
            (string, float) rank;
            int idx = -1;
            if (i.Item2 > min[2])
            {
                idx = 2;
                min[2] = i.Item2;
                player[2] = i.Item1;
            }
            else if (i.Item2 > min[1])
            {
                idx = 1;
                min[1] = i.Item2;
                player[1] = i.Item1;
            }
            else if (i.Item2 > min[0])
            {
                idx = 0;
                min[0] = i.Item2;
                player[0] = i.Item1;
            }
        }
        for(int a=0; a<3; a++)
            lisRank.Add((player[a], min[a]));
        return lisRank;
    }
    public void WriteRankToFile(string name, float score)
    {
        StreamReader sr = new StreamReader("./Assets/Scripts/rank.txt");
        string line = "test";
        List<string> prevRnks = new List<string>();
        while(line != null)
        {
            line = sr.ReadLine();
            prevRnks.Add(line);
        }
        sr.Close();
        StreamWriter sw = new StreamWriter("./Assets/Scripts/rank.txt");
        foreach(var i in  prevRnks)
            sw.WriteLine(i);
        line = String.Format("{0} {1}",name,score);
        sw.WriteLine(line);
        sw.Close();
    }
}