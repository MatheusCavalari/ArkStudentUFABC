using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerups : MonoBehaviour
{
    public Rigidbody2D rb;
    public float velocidade;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -Vector2.up * velocidade;
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if(outro.gameObject.tag == "colisorBaixo")
        {
            Destroy(gameObject);
        }
        
    }
}
