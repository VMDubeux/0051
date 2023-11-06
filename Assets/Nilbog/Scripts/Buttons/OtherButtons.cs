using UnityEngine;

public class OtherButtons : Buttons
{
    [Header("Main Menus (Active and Inactive):")]
    [SerializeField]
    private Menu[] menu = new Menu[2];

    private void Start()
    {
        print("Apertou");
    }

    public override void Click()
    {
        if (menu != null)
        {
            menu[0].gameObjectMenu.SetActive(true);
            menu[1].gameObjectMenu.SetActive(false);
        }
    }
}
