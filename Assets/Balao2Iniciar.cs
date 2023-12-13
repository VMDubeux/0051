using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balao2Iniciar : MonoBehaviour
{
    public GameObject []balao;

    void Update() 
    {
        if(!balao[0].activeSelf && !balao[1].activeSelf) Invoke(nameof(Iniciar), 2.0f);
    }

    private void Iniciar()
    {
        balao[2].SetActive(true);
    }
}
