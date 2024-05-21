using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Rigidbody2D rb2d;
    [SerializeField] private int opt;

    int count = 0;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        //player = GameObject.FindWithTag("Player");
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
            if(coll.contacts[0].normal.y == -1) // 플레이어가 밟았을때
            {
                count++; // 멀쩡한 바위 -> 금간 바위
                if(count == 1) // 금간 바위 -> 터짐
                    Destroy(gameObject);
            }
            else if (coll.contacts[0].normal.y == 1) // 플레이어 머리위로 떨어졌을때
            { 
                // 플레이어 체력감소 || 게임 오버
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
