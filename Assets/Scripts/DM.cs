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
}