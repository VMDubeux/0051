using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public abstract class Buttons : MonoBehaviour, IPointerClickHandler
{
    internal Button currentButton;

    void Start()
    {
        currentButton = GetComponent<Button>();
    }

    public void OnPointerClick(PointerEventData data)
    {
        ButtonsManager.OnButtonClick += Click;
    }

    public virtual void Click() 
    {
        AudioManager.Instance.PlaySFX("Click", 1.0f);
        ButtonsManager.OnButtonClick -= Click;
    }
}
