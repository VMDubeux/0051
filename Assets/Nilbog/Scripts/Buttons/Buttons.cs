using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class Buttons : MonoBehaviour
{
    internal Button currentButton;

    void Start()
    {
        currentButton = GetComponent<Button>();
    }

    void Update()
    {
        currentButton.onClick.AddListener(() => ButtonsManager.OnButtonClick += Click);
    }

    public abstract void Click();
}
