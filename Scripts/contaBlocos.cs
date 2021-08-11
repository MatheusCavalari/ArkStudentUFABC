using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class contaBlocos : MonoBehaviour
{
    public string proximaFase; 
    public int blocoContador;
    public Image aprovado;
    // Start is called before the first frame update
    void Start()
    {
        blocoContador = 0;
        foreach (Transform bloco in GameObject.Find("Blocos").transform)
        {
            blocoContador++;
        }
                
    }

    [System.Obsolete]
    void Update()
    {
        if(blocoContador < 1)
        {
            if(proximaFase == "fim")
            {
                aprovado.enabled = true;
            }
            else
            {
                aprovado.enabled = true;
                if (Input.GetKey(KeyCode.S))
                {
                    Application.LoadLevel(proximaFase);
                }
            }
        }        
    }

}
