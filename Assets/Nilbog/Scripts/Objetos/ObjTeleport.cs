using UnityEngine;

public class ObjTeleport : MonoBehaviour
{
    [Header("Teleporte: ")]
    [SerializeField] private GameObject _TeleporteTo;

    void Update()
    {
        if (_TeleporteTo != null &&
            _TeleporteTo.GetComponent<InteractiveObjects>().status)
            Teleporte();
    }

    public void Teleporte() => gameObject.transform.SetPositionAndRotation
        (_TeleporteTo.transform.position + new Vector3(0, 0.25f, 0),
        Quaternion.Euler(-90, 0, 0));
}
