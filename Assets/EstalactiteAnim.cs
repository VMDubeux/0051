using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstalactiteAnim : MonoBehaviour
{
    public GameObject[] stone = new GameObject[1];

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    private void OnMouseDown()
    {
        foreach (GameObject obj in stone)
        {
            Invoke("Chamar(obj)", 2f);

        }
    }
    private void Chamar(GameObject obj)
    {
        if (obj.GetComponent<InteractiveObjects>().status == true && GetComponent<InteractiveObjects>().status == true)
            anim.SetBool("Descendo", true);
    }
}
