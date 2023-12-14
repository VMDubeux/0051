using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Novo Objeto", menuName = "Meu jogo/Objeto", order = 1)]
public class ObjInfo : ScriptableObject
{
    public Sprite sprite;
    public Sprite sprite_2;
    public List<ParticleSystem> particleEffect = new List<ParticleSystem>();
    public TMP_Text[] notasDerrota = new TMP_Text[3];
}
