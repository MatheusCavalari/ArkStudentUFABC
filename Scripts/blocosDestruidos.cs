using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blocosDestruidos : MonoBehaviour
{

    private contaBlocos contaBlocoScript;
    void Start()
    {
        contaBlocoScript = GameObject.Find("contaBlocos").GetComponent<contaBlocos>();
    }

    void OnDestroy()
    {
        contaBlocoScript.blocoContador--;                        
    }
}
