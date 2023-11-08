using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotInteractiveObjects : Objects
{
    private void Start()
    {
        RemoveObject();
    }

    public NotInteractiveObjects()
    {
        // Implementar
    }

    public override void Active()
    {
        throw new System.NotImplementedException();
    }

    public override void Compatibilidade()
    {
        throw new System.NotImplementedException();
    }

    public override void Connect()
    {
        throw new System.NotImplementedException();
    }

    public override void OnMouseDown()
    {
        throw new System.NotImplementedException();
    }

    public void RemoveObject()
    {
        if (CompareTag("VFX")) Destroy(gameObject, 2.0f);
    }
}
