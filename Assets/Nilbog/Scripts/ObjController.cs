using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjController : MonoBehaviour
{
    [Header("Scriptable Object Settings: ")]
    [SerializeField] private ObjInfo _objSettings;

    [Header("Inputs and Outputs: ")]
    [SerializeField] private ObjController[] _input;
    [SerializeField] private ObjController _output;
    [SerializeField] private bool _status;

    private void Active()
    {
        _status = true;
        if (_output != null && _status)
            _output.Connect();
    }

    private void OnMouseDown()
    {
        Active();
        gameObject.SetActive(false);
        Inventory.Instance.AddImage(_objSettings.Sprite);
    }

    private void Connect()
    {
        for (int i = 0; i < _input.Length; i++)
        {
            if (_input[i]._status == false)
            {
                _status = false;
                return;
            }
        }

        _status = true;
        gameObject.SetActive(true);

        if (_output != null && _status)
            _output.Connect();
    }
}
