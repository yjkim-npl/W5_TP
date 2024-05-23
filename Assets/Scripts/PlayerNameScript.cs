using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerNameScript : MonoBehaviour
{
    [SerializeField] GameObject Player2;
    public TMP_Text playerName;
    void Start()
    {
        playerName = GetComponent<TMP_Text>();

        switch (gameObject.name)
        {
            case "P1N":
                playerName.text = DataManager.instance.GetP1Name();
                break;
            case "P2N":
                playerName.text = DataManager.instance.GetP2Name();
                break;

        }
    }
}
