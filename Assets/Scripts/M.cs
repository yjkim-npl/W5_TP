using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M : MonoBehaviour
{
    [SerializeField] private GameObject rFE;
    [SerializeField] private GameObject player;
    [SerializeField] private int opt;

    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        float x = player.transform.position.x;
        float y = 4f;
        x += Random.Range(-2f, 2f);
        transform.position = new Vector3(x, y, 0);
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if((coll.gameObject.CompareTag("Ground") || 
            coll.gameObject.CompareTag("Rock")) &&
            !gameObject.CompareTag("Rock"))
        {
            if (opt == 1) // In case of meteor, the meteor will be destroyed
                Destroy(gameObject);
            rFE.SetActive(false);
        }
        else if (coll.gameObject.CompareTag("Player"))
        {
            // coll.contacts.Length = 2
            // [ContactPoint2D] coll.contact[idx] 
            // [Vector2], normal vector, coll.contact[idx].normal
            // (-1,0), (1,0), (
            foreach(var i in coll.contacts)
            {
                Debug.Log(i.normal);
            }
            if(coll.contacts[0].normal.y == -1) // 플레이어가 밟았을때
            {
                count++; // 멀쩡한 바위 -> 금간 바위
                if(count == 1) // 금간 바위 -> 터짐
                    Destroy(gameObject);
            }
            else if (coll.contacts[0].normal.y == 1) // 플레이어 머리위로 떨어졌을때
            { 
                // 플레이어 체력감소 || 게임 오버
                GameManager.instance.GameOver();
            }
        }
    }
}
