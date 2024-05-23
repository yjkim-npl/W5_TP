using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DataManager:MonoBehaviour
{
    public static DataManager instance;

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
        Dictionary<string,float> dicTemp = new Dictionary<string,float>();

        StreamReader sr = new StreamReader("./Assets/Scripts/rank.txt");
        string line = sr.ReadLine(); // Initialzie & remove dummy line
        while(line != null)
        {
            line = sr.ReadLine();
            if (line == null)
                continue;
            string[] ele = line.Split(" ");
            if (ele.Length < 2)
                continue;
            dicTemp.Add(ele[0], float.Parse(ele[1]));
        }
        sr.Close();

        var queryAsc = dicTemp.OrderByDescending(x => x.Value);


        // Judge the minimum time on the lists
        string[] player = new string[3] {"None","None","None"};
        float[] min = new float[3] { 0f,0f,0f};
        foreach (var i in queryAsc)
            lisRank.Add((i.Key, i.Value));
        for(int a=lisRank.Count; a<3; a++)
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
            if (line == null) continue;
            prevRnks.Add(line);
        }
        sr.Close();

        StreamWriter sw = new StreamWriter("./Assets/Scripts/rank.txt");
        bool isExist = false;
        foreach(var i in  prevRnks)
        {
            string[] comp = i.Split(' ');
            if (comp[0] == name)
            {
                isExist = true;
                if (float.Parse(comp[1]) < score)
                    sw.WriteLine("{0} {1}", name, score.ToString("N2"));
                continue;
            }
            sw.WriteLine(i);
        }
        if(!isExist)
            sw.WriteLine("{0} {1}", name, score.ToString("N2"));

        sw.Close();
    }
}