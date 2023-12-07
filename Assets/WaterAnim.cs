using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAnim : MonoBehaviour
{
    public GameObject[] sunRay = new GameObject[1];

    private Animator anim;

    //private InteractiveObjects interactiveObjects;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        foreach (GameObject sun in sunRay)
        {
            if (sun.activeSelf)
            {
                anim.SetBool("Descendo", true);
                GetComponent<InteractiveObjects>().status = true;
            }
        }
    }
}
