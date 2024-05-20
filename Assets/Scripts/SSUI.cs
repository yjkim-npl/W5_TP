using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SSUI : MonoBehaviour
{
    int p1chara, p2chara =0;
    string p1Name, p2Name="";

    [SerializeField] private GameObject p1NameField;
    [SerializeField] private GameObject p2NameField;

    public void SelectLvl(int lvl) { SSG.instance.SetLvl(lvl); }
    public void SelectMode(int mode) {  SSG.instance.SetMode(mode);}
    

    public void SelectP1Chara(int chara) { p1chara = chara; }
    public void SelectP2Chara(int chara) { if(SSG.instance.GetMode() == 2) p2chara = chara; }
    public void ResetBtn()
    {
        SSG.instance.SetP1Chara(0);
        SSG.instance.SetP2Chara(0);
    }
    public void ConfirmChara() 
    {
        SSG.instance.SetP1Chara(p1chara); 
        SSG.instance.SetP2Chara(p2chara); 
        if(SSG.instance.GetMode() == 1)
        {
            p2NameField.SetActive(false);
            p1NameField.GetComponent<RectTransform>().localPosition = new Vector3(-100, 0, 0);
        }else if (SSG.instance.GetMode()==2)
        {
            p1NameField.GetComponent<RectTransform>().localPosition = new Vector3(-100, 60, 0);
            p2NameField.GetComponent<RectTransform>().localPosition = new Vector3(-100, -120, 0);
        }
    }
    public void ConfirmName()
    {
        SSG.instance.SetP1Name(p1Name);
        SSG.instance.SetP2Name(p2Name);
    }
}
