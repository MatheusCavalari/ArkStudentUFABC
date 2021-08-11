using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float velocidade;
    public float direcao;
    public GameObject bala;
    public GameObject pontoBala;
    public bool atire = false;
    public float timer = 0;
    private gameManager gManagerScript;

    private Animator pAnimation;

    public bool ativaExplosao;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pAnimation = GetComponent<Animator>();
        ativaExplosao = false;
        gManagerScript = GameObject.Find("GameManager").GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        direcao = Input.GetAxisRaw("Horizontal");

        if (gManagerScript.vidas < 4)
        {
            if (atire == true && timer > 0)
            {
                if (Input.GetButtonDown("Fire4"))
                    Instantiate(bala, pontoBala.transform.position, Quaternion.identity);

                timer -= Time.deltaTime;
            }
        }

        if (timer <= 0)
            atire = false;
    }

    private void FixedUpdate()
    {
        if (gManagerScript.vidas < 4)
        {
            rb.velocity = new Vector2(direcao * velocidade, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (gManagerScript.vidas < 4)
        {
            if (outro.gameObject.tag == "tamanho")
            {
                pAnimation.Play("aumenta_player");
                Destroy(outro.gameObject);
            }

            if (outro.gameObject.tag == "tiro")
            {
                if (atire == false)
                {
                    timer = 10;
                    atire = true;
                }
                Destroy(outro.gameObject);
            }

            if (outro.gameObject.tag == "fogo")
            {
                StartCoroutine(bolafogo(10));
                Destroy(outro.gameObject);
            }
        }
    }

    void trocaAnim()
    {
        pAnimation.Play("parado");
    }

    IEnumerator bolafogo(int tempoDeEspera)
    {
        ativaExplosao = true;
        
        yield return new WaitForSeconds(tempoDeEspera);

        ativaExplosao = false;
    }
}
