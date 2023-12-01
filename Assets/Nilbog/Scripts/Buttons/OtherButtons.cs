using System.Collections.Generic;
using UnityEngine;

public class OtherButtons : Buttons
{
    [Header("Main Menus (Active and Inactive):")]

    [SerializeField]
    private List<Menu> menuInactive = new();

    [SerializeField]
    private List<Menu> menuActive = new();

    public override void Click()
    {
        if (menuActive != null)
        {
            for (sbyte x = 0; x < menuActive.Count; x++)
                menuActive[x].gameObjectMenu.SetActive(true);
        }

        if (menuInactive != null)
        {
            for (sbyte x = 0; x < menuInactive.Count; x++)
                menuInactive[x].gameObjectMenu.SetActive(false);
        }
        base.Click();
    }
}