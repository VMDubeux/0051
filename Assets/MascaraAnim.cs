using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MascaraAnim : MonoBehaviour
{
    public GameObject[] crab = new GameObject[1];

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        foreach (GameObject obj in crab)
        {
            if (obj.GetComponent<InteractiveObjects>().status == true)
                anim.SetBool("Quebrou", true);
        }
    }
}
