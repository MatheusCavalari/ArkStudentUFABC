using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoBala : MonoBehaviour
{
    private Rigidbody2D rb;

    public float velInicial;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(0, velInicial);
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if(outro.gameObject.tag == "bloco_verde" || outro.gameObject.tag == "bloco_vermelho" || outro.gameObject.tag == "bloco_azul" || outro.gameObject.tag == "bloco_amarelo")
        {
            Destroy(outro.gameObject);
            Destroy(gameObject);
        }

        if(outro.gameObject.tag == "Finish")
        {
            Destroy(gameObject);
        }
    }
}
