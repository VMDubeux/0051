using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Objects : MonoBehaviour
{
    [Header("Scriptable Object Settings: ")]
    public ObjInfo objInfo;

    [Header("Inputs, Outputs e Extraput: ")]
    public Objects[] objInput;
    public Objects[] objOutput;
    public Objects[] objExtraput;

    [Header("Incompatibilidade: ")]
    public Objects[] objIncompativel;
    public Objects[] outputIncompativeis;

    [Header("Situação:")]
    public bool status;

    [Header("Texto Derrota")]
    public GameObject objDerrota;

    public abstract void Active();

    public abstract void Connect();

    public abstract void Compatibilidade();

    public abstract void OnMouseDown();
}
