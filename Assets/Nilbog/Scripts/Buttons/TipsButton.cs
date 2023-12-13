using System.Collections.Generic;
using UnityEngine;

public class TipsButton : Buttons
{
    [Header("Main Menus (Active and Inactive):")]

    [SerializeField]
    private GameObject tipsMenu;

    [SerializeField]
    private GameObject blockObject;

    [SerializeField]
    internal bool status = false;

    public override void Click()
    {
        if (tipsMenu != null && status == false)
        {
            tipsMenu.SetActive(true);
            blockObject.SetActive(true);
            status = true;
        }
        else
        {
            tipsMenu.SetActive(false);
            blockObject.SetActive(false);
            status = false;
        }
        AudioManager.Instance.PlaySFX("Dicas", 1.0f);
        ButtonsManager.OnButtonClick -= Click;
    }
}