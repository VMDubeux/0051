using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BalaoAnim : MonoBehaviour
{
    private void Start()
    {
        Invoke(nameof(Desabilitar), 6.0f);
    }

    void Desabilitar() 
    {
        gameObject.SetActive(false);
    }

}
