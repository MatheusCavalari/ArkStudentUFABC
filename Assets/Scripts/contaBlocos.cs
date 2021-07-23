using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contaBlocos : MonoBehaviour
{
    public int blocoContador;
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
            Application.LoadLevel("Cena2");
        }        
    }

}
