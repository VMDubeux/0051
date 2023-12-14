using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defeatCanvas : MonoBehaviour
{
    public GameObject screenBlock;

    private void Start()
    {
        if(gameObject.activeSelf)
            screenBlock.SetActive(true);
        else
            screenBlock.SetActive(false);
    }
}
