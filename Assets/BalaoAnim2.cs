using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaoAnim2 : MonoBehaviour
{
    public GameObject[] altar = new GameObject[1];

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        foreach (GameObject obj in altar)
        {
            if (obj.GetComponent<InteractiveObjects>().status == true && GetComponent<InteractiveObjects>().status == true)
                anim.SetBool("Encher", true);
        }
    }
}
