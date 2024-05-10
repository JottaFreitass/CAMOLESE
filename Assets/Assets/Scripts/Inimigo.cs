using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public Transform player;
    SpriteRenderer SR;
    public float speed, entreNos;

    bool Visao = false;
    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        entreNos = Vector2.Distance(transform.position, player.position);
        if (entreNos < 6)
        {
            Visao= true;
        }
        else if (entreNos > 10)
        {
            Visao = false;
        }
        Seguir();
    }

    void Seguir()
    {
        if(Visao)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }


    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.tag == "Player")
        {
            colisao.gameObject.GetComponent<SpriteRenderer>().color = new Color(240, 0, 0);
        }
    }

    void OnCollisionExit2D(Collision2D colisao)
    {
        if (colisao.gameObject.tag == "Player")
        {
            colisao.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
        }
    }
}
