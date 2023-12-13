using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatoAnim : MonoBehaviour
{
    public GameObject[] pedra = new GameObject[1];

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        foreach (GameObject obj in pedra)
        {
            if (obj.GetComponent<InteractiveObjects>().status == true && GetComponent<InteractiveObjects>().status == true)
                anim.SetBool("Lado", true);
        }
    }
}