using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balao : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (GetComponent<InteractiveObjects>().status == true)
        {
            gameObject.SetActive(false);
        }
    }
}
