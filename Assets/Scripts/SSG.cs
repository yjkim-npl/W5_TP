using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSG : MonoBehaviour
{
    [SerializeField] private GameObject SSUI;
    public static SSG instance;
    private int selLvl;
    private int selMode;
    private int p1chara;
    private int p2chara;
    private string p1Name;
    private string p2Name;

    #region Get, Set field value
    public int GetLvl() { return selLvl; }
    public int GetMode() { return selMode;}
    public int GetP1Chara() { return p1chara; }
    public int GetP2Chara() { return p2chara; }
    public string GetP1Name() { return p1Name; }
    public string GetP2Name() { return p2Name; }
    public void SetLvl(int lvl) { selLvl = lvl; }
    public void SetMode(int mode) { selMode = mode; }
    public void SetP1Chara(int chara) { p1chara = chara; }
    public void SetP2Chara(int chara) { p2chara = chara; }
    public void SetP1Name(string name) { p1Name = name;}
    public void SetP2Name(string name) { p2Name = name;}
    #endregion

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        SSUI.SetActive(true);
    }
}
