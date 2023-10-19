using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Novo Objeto", menuName = "Meu jogo/Objeto", order = 1)]
public class ObjInfo : ScriptableObject
{
    public Sprite Sprite;
    public GameObject Prefab;
}