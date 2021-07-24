using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class bola : MonoBehaviour
{
    public Rigidbody2D rb;
    public float velBola;
    public Transform jogador;

    public float posicaoBolinha;
    private bool comecou;

    public GameObject[] powerUps;
    public float porcentagem;

    private player scriptPlayer;
    public GameObject explosao;

    private gameManager gManagerScript;

    public Image reprovadoImage;

    public AudioClip somBloco;

    public AudioClip somPlayer;

    // Start is called before the first frame update
    void Start()
    {
        gManagerScript = GameObject.Find("GameManager").GetComponent<gameManager>();

        scriptPlayer = GameObject.Find("Player").GetComponent<player>();
        rb = GetComponent<Rigidbody2D>();
        //rb.velocity = new Vector2(Random.Range(-2, 2), velBola);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !comecou)
        {
            rb.velocity = new Vector2(Random.Range(-2f, 2f), velBola);
            comecou = true;
        }

        if (!comecou)
        {
            transform.position = new Vector2(jogador.position.x, transform.position.y);
        }
    }

    void FixedUpdate()
    {
        if (comecou)
        {

            if (rb.velocity.y < 2 && rb.velocity.y > -2)
            {
                rb.gravityScale = 3;
            }
            else
            {
                rb.gravityScale = 0;
            }
        }
    }

    float colisaoBolinha(Vector2 posicaoBolinha, Vector2 posicaoJogador, float larguraJogador)
    {
        return (posicaoBolinha.x - posicaoJogador.x) / larguraJogador;
    }

    void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.tag == "bloco_verde" || outro.gameObject.tag == "bloco_vermelho" || outro.gameObject.tag == "bloco_azul" || outro.gameObject.tag == "bloco_amarelo")
        {
            if (scriptPlayer.ativaExplosao)
                Instantiate(explosao, outro.transform.position, Quaternion.identity);
            //Instantiate()
            if (Random.Range(0f, 1f) <= porcentagem)
            {
                Instantiate(powerUps[Random.Range(0, powerUps.Length)], outro.gameObject.transform.position, Quaternion.identity);
            }

            AudioSource.PlayClipAtPoint(somBloco, transform.position);
            Destroy(outro.gameObject);
        }

        if (outro.gameObject.tag == "Player")
        {
            float resultadoCalculo = colisaoBolinha(transform.position, outro.transform.position, ((BoxCollider2D)outro.collider).size.x);

            Vector2 novaDirecao = new Vector2(resultadoCalculo, 1).normalized;

            rb.velocity = novaDirecao * velBola;

            AudioSource.PlayClipAtPoint(somPlayer, transform.position);
        }

        if (outro.gameObject.tag == "colisorBaixo")
        {
            if (gManagerScript.vidas < 3)
            {
                gManagerScript.vidas += 1; 
                transform.position = new Vector2(jogador.position.x, jogador.position.y + posicaoBolinha);
                comecou = false;
                rb.velocity = Vector2.zero;
                //Adc
                gManagerScript.pontuacao = gManagerScript.pontuacao * 0.7;
            }
            else
            {
                reprovadoImage.enabled = true;
                gManagerScript.vidas += 1;
                Destroy(gameObject);
                if (Input.GetKey(KeyCode.R))
                {
                    Application.LoadLevel("Cena1");
                }
            }
        }
    }


}
