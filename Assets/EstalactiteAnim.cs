using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstalactiteAnim : MonoBehaviour
{
    public GameObject[] pedra = new GameObject[1];

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        foreach (GameObject obj in pedra)
        {
            if (obj.GetComponent<InteractiveObjects>().status == true && GetComponent<InteractiveObjects>().status == true)
                anim.SetBool("Jogando", true);
        }
    }
}


