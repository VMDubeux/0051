using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameplayButton : Buttons
{
    [Header("Menu Derrota:")]
    [SerializeField]
    private GameObject menu;

    public override void Click()
    {
        menu.SetActive(false);
        Time.timeScale = 1.0f;
        base.Click();
    }
}
