using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SSUI : MonoBehaviour
{
    int p1chara, p2chara =0;
    string p1Name, p2Name="";
    [SerializeField] private TMP_InputField IFp1;
    [SerializeField] private TMP_InputField IFp2;

    [SerializeField] private GameObject p1NameField;
    [SerializeField] private GameObject p2NameField;

    public void SelectLvl(int lvl) { DM.instance.SetLvl(lvl); }
    public void SelectMode(int mode) {  DM.instance.SetMode(mode);}
    
    public void SelectP1Chara(int chara) 
    {
        if (DM.instance.GetP1Chara() != 0)
            return;
        // turn off SSUI > SetChara(2) > SelCharaBG(0) > chara0BG(1) ~ chara3BG(4)
        for(int a=1; a<5; a++)
        {
            if (a == DM.instance.GetP1Chara())
                continue;
            transform.GetChild(2).GetChild(0).GetChild(a).gameObject.SetActive(false);
        }
        transform.GetChild(2).GetChild(0).GetChild(5).gameObject.SetActive(true);
        transform.GetChild(2).GetChild(0).GetChild(chara).gameObject.SetActive(true);

        // move `P1` cursor position to the selected character
        // SSUI > SelChara(2) > SelCharaBG(0) > P1CharaTxt
        float x = -750 + 400*(chara-1);
        float y = 230;
        transform.GetChild(2).GetChild(0).GetChild(5).gameObject.transform.localPosition = new Vector3(x, y, 0);
        if(DM.instance.GetP2Chara() == 0)
        {
            p1chara = chara; 
        }
    }
    public void SelectP2Chara(int chara) 
    {
        // turn off SSUI > SetChara(2) > SelCharaBG(0) > chara0BG(1) ~ chara3BG(4)
        if (DM.instance.GetMode() != 2)
            return;
        if(DM.instance.GetMode() == 2 && DM.instance.GetP1Chara() != 0)
            transform.GetChild(2).GetChild(0).GetChild(6).gameObject.SetActive(true);
        for(int a=1; a<5; a++)
        {
            if (a == DM.instance.GetP1Chara())
                continue;
            transform.GetChild(2).GetChild(0).GetChild(a).gameObject.SetActive(false);
        }
        transform.GetChild(2).GetChild(0).GetChild(chara).gameObject.SetActive(true);

        // move `P1` cursor position to the selected character
        // SSUI > SelChara(2) > SelCharaBG(0) > P2CharaTxt
        float x = -450 + 400*(chara-1);
        float y = 230;
        transform.GetChild(2).GetChild(0).GetChild(6).gameObject.transform.localPosition = new Vector3(x, y, 0);
        if (DM.instance.GetP1Chara() == 0)
            return;
        if(DM.instance.GetMode() == 2) 
            p2chara = chara; 
    }

    public void ModeBtn(int opt)
    {
        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
        switch (opt)
        {
            case 1: // single play
                transform.GetChild(2).GetChild(5).GetComponent<RectTransform>().localPosition = new Vector3(0,-400,0);
                transform.GetChild(2).GetChild(6).gameObject.SetActive(false);
                break;
            case 2: // multi play
                transform.GetChild(2).GetChild(6).gameObject.SetActive(true);
                transform.GetChild(2).GetChild(5).GetComponent<RectTransform>().localPosition = new Vector3(-250, -400, 0);
                transform.GetChild(2).GetChild(6).GetComponent<RectTransform>().localPosition = new Vector3(250 , -400, 0);
                break;
            default:
                break;
        }
        SelectMode(opt);
    }
    public void ResetBtn()
    {
        DM.instance.SetP1Chara(0);
        DM.instance.SetP2Chara(0);
    }
    public void ConfirmChara(int opt) 
    {
        switch(opt)
        {
            case 1: // p1 chara
                DM.instance.SetP1Chara(p1chara); 
                break;
            case 2: // p2 chara
                DM.instance.SetP2Chara(p2chara); 
                break;
        }
        if(DM.instance.GetP1Chara()!= 0 && (DM.instance.GetMode()==2?DM.instance.GetP2Chara() !=0:true))
        {
            transform.GetChild(3).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(false);
            switch (DM.instance.GetMode())
            {
                case 1: // single play
                    transform.GetChild(3).GetChild(2).gameObject.SetActive(false);
                    transform.GetChild(3).GetChild(1).GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                    break;
                case 2: // mult play
                    transform.GetChild(3).GetChild(2).gameObject.SetActive(true);
                    transform.GetChild(3).GetChild(1).GetComponent<RectTransform>().localPosition = new Vector3(-300, 0, 0);
                    transform.GetChild(3).GetChild(2).GetComponent<RectTransform>().localPosition = new Vector3( 300, 0, 0);
                    break;

            }
        }
    }

    public void ConfirmName()
    {
        p1Name = IFp1.text;
        p2Name = IFp2.text;
        DM.instance.SetP1Name(p1Name);
        DM.instance.SetP2Name(p2Name);
        SceneManager.LoadScene("MainScene");
    }

    public void GoToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void RealGoToTitle()
    {
        Invoke("GoToTitle", 1f);
    }

    // child: 0=Lvl, 1=Mode, 2=Chara, 3=Name
    public void GoToPrevSel(int curSel)
    {
        transform.GetChild(curSel).gameObject.SetActive(false);
        transform.GetChild(curSel-1).gameObject.SetActive(true);
    }
}
