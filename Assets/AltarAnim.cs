using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarAnim : MonoBehaviour
{
    public ParticleSystem particulas;

    private void OnMouseDown()
    {
        if (GetComponent<InteractiveObjects>().status == true)
        {
            particulas.gameObject.SetActive(true);
        }
    }
}
