using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControllerVFX : MonoBehaviour
{

    private void Start()
    {
        if (CompareTag("VFX")) Destroy(gameObject, 2.0f);
    }
}
