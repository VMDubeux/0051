using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsCanvas : MonoBehaviour
{
    private bool isOpen = false;

    public void ManageTipsCanvas()
    {
        if (isOpen == false)
        {
            gameObject.SetActive(true);
            isOpen = true;
        }
        else
        {
            gameObject.SetActive(false);
            isOpen = false;
        }
    }
}