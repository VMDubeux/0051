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
    [SerializeField] private ObjController _output;
    [SerializeField] private bool _status;

    [Header("Materials: ")]
    public Material ClickedObjectMaterial;
 
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
            }
        }

        _status = true;

        if (_output != null && _status)
            _output.Connect();
    }

    private void OnMouseDown()
    {
        Active();
        //gameObject.SetActive(false);
        Inventory.Instance.AddImage(_objSettings.Sprite);
    }

    private void OnMouseExit()
    {
        //NotClicked = GetComponent<MeshRenderer>().material;
    }

    private void Connect()
    {

        gameObject.SetActive(true);

        if (_output != null && _status)
            _output.Connect();
    }
}
