using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pontuacaoBlocos : MonoBehaviour
{
    private gameManager gManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        gManagerScript = GameObject.Find("GameManager").GetComponent<gameManager>();
        
    }

    void OnDestroy()
    {
        //if (gameObject.tag == "bloco_verde")
        //    gManagerScript.pontuacao = gManagerScript.pontuacao + 10;

        //if (gameObject.tag == "bloco_laranja")
        //if (gameObject.tag == "bloco_vermelho")
        //    gManagerScript.pontuacao = gManagerScript.pontuacao + 20;

        //if (gameObject.tag == "bloco_azul")
        //    gManagerScript.pontuacao = gManagerScript.pontuacao + 30;

        //if (gameObject.tag == "bloco_amarelo")
        //    gManagerScript.pontuacao = gManagerScript.pontuacao + 40;


    }
}
