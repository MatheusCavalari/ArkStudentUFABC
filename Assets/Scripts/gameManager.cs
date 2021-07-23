using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{

    public SpriteRenderer renderBolinha;

    private player scriptPlayer;

    public Sprite[] sprBolinha;

    public Text crText;
    public Text caText;

    public Slider vidasSlider;

    //public int pontuacao;
    //public double pontuacao;
    //public double ca;

    public double pontuacao;
    public double ca;

    public int vidas;

    // Start is called before the first frame update
    void Start()
    {
        //vidas = 4;
        //vidas = 0;
        pontuacao = 4;
        ca = 0;
        scriptPlayer = GameObject.Find("Player").GetComponent<player>();
        renderBolinha = GameObject.Find("ball").GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        crText.text = pontuacao.ToString();
        caText.text = ca.ToString();
        vidasSlider.value = vidas;

        //if (vidas > 0) // 1 abaixo do bola.cs
        if (vidas < 4) // 1 abaixo do bola.cs

        {
            if (scriptPlayer.atire && !scriptPlayer.ativaExplosao)
            {
                renderBolinha.sprite = sprBolinha[1];
            }
            else if (!scriptPlayer.atire && scriptPlayer.ativaExplosao)
            {
                renderBolinha.sprite = sprBolinha[2];
            }
            else
            {
                renderBolinha.sprite = sprBolinha[0];
            }

            if (scriptPlayer.atire && scriptPlayer.ativaExplosao)
            {
                renderBolinha.color = Color.yellow;
            }
            else
            {
                renderBolinha.color = Color.white;  
            }

        }else if (Input.GetKeyDown(KeyCode.R)) //Reiniciar o jogo
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
