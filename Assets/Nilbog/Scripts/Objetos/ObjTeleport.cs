using UnityEngine;

public class ObjTeleport : MonoBehaviour
{
    [Header("Teleporte: ")]
    [SerializeField] private GameObject _TeleporteTo;

    public void Teleporte()
    {
        if (_TeleporteTo != null)
        {
            gameObject.transform.SetPositionAndRotation(_TeleporteTo.transform.position, _TeleporteTo.transform.rotation);
        }
    }
}
