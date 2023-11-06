using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Novo Objeto", menuName = "Meu jogo/Objeto", order = 1)]
public class ObjInfo : ScriptableObject
{
    public Sprite sprite;
    public List<ParticleSystem> particleEffect = new List<ParticleSystem>();
}