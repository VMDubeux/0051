using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayButton : Buttons
{
    [Header("Menu Derrota:")]
    [SerializeField]
    private GameObject menu;

    public override void Click()
    {
        print("Desativar");
        menu.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
