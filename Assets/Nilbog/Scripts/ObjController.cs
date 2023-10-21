using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Rendering;

public class ObjController : MonoBehaviour
{
    [Header("Scriptable Object Settings: ")]
    [SerializeField] private ObjInfo _objSettings;

    [Header("Inputs and Outputs: ")]
    [SerializeField] private ObjController[] _input;
    [SerializeField] private ObjController[] _output;
    [SerializeField] private bool _status;

    [Header("Incompatibilidade: ")]
    [SerializeField] private ObjController[] _incompativeis;
    [SerializeField] private ObjController[] _outputIncompativeis;

    [Header("Teleporte: ")]
    [SerializeField] private GameObject _TeleporteTo;

    private void Active()
    {
        if (_input.Length > 0)
        {
            for (int i = 0; i < _input.Length; i++)
            {
                if (_input[i]._status == false)
                {
                    _status = false;
                    return;
                }

                else if (_input[i] == GameManager.Instance.LastSelected)
                {
                    _status = true;
                }
            }
        }
        else _status = true;

        if (_output.Length > 0 && _status)
        {
            for (int i = 0; i < _output.Length; i++)
            {
                _output[i].Connect();
            }

            if (CompareTag("Over")) gameObject.SetActive(false);
        }
        else if (CompareTag("ObjetoFinal") && _status)
        {
            Debug.Log("Fim da atual cena");
            //GameManager.Instance.SceneLoad();
        }
    }

    private void Connect()
    {
        gameObject.SetActive(true);

        if (_output != null && _status)
        {
            for (int i = 0; i < _output.Length; i++)
            {
                _output[i].Connect();
            }
        }
    }

    private void Compatibilidade()
    {
        for (int i = 0; i < _incompativeis.Length; i++)
        {
            if (_incompativeis[i] == GameManager.Instance.LastSelected)
            {
                _outputIncompativeis[i].gameObject.SetActive(true);
            }
        }
    }

    private void OnMouseDown()
    {
        GameManager.Instance.LastSelected = GameManager.Instance.CurrentSelected;
        GameManager.Instance.CurrentSelected = this;
        Active();
        Compatibilidade();
        Teleporte();
        Inventory.Instance.AddImage(_objSettings.Sprite);
    }

    private void Teleporte() 
    {
        if (_TeleporteTo != null) 
        {
            gameObject.transform.position = _TeleporteTo.transform.position;
            gameObject.transform.rotation = _TeleporteTo.transform.rotation;
        }
    }
}