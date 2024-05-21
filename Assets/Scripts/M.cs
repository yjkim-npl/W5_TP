using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class M : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject BG;
    private BoxCollider2D coll2d;
    private Rigidbody2D rb2d;
    [SerializeField] private int opt;

    int count = 0;

    void Start()
    {
        coll2d = GetComponentInChildren<BoxCollider2D>();
        player = GameObject.FindWithTag("Player");
        //player = GameObject.FindWithTag("Player");

        int rnd = Random.Range(0, 9);
        if (gameObject.CompareTag("Meteor"))
        {
            switch (DM.instance.GetLvl())
            {
                case 1:
                    text.text = DM.instance.wordsE[rnd];
                    BG.GetComponent<RectTransform>().sizeDelta = new Vector2(1,1);
                    coll2d.size = new Vector2(1, 1);
                    break;
                case 2:
                    text.text = DM.instance.wordsN[rnd];
                    BG.GetComponent<RectTransform>().sizeDelta = new Vector2(2,1);
                    coll2d.size = new Vector2(2, 1);
                    break;
                case 3:
                    text.text = DM.instance.wordsH[rnd];
                    BG.GetComponent<RectTransform>().sizeDelta = new Vector2(3,1);
                    coll2d.size = new Vector2(3, 1);
                    break;
            }
        }
        rb2d = GetComponent<Rigidbody2D>();
        float x = player.transform.position.x;
        float y = 4f;
        x = Random.Range(-7f, 7f);
        transform.position = new Vector3(x, y, 0);
        
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        //rb2d.mass = 1000;
        rb2d.velocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if((coll.gameObject.CompareTag("Ground") || 
            coll.gameObject.CompareTag("Rock")))
        {
            if (opt == 1) // In case of meteor(opt = 1), the meteor will be destroyed
                Destroy(gameObject);
        }
        else if (coll.gameObject.CompareTag("Player"))
        {
            if(coll.contacts[0].normal.y == -1) // �÷��̾ �������
            {
                count++; // ������ ���� -> �ݰ� ����
                if(count == 1) // �ݰ� ���� -> ����
                    Destroy(gameObject);
            }
            else if (coll.contacts[0].normal.y == 1) // �÷��̾� �Ӹ����� ����������
            { 
                // �÷��̾� ü�°��� || ���� ����
                GMS.instance.GameOver();
            }
        }
        //else if (!coll.gameObject.CompareTag("Player"))
        else if(coll.gameObject.CompareTag("Rock"))
        {
            rb2d.freezeRotation = false;
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }
}
