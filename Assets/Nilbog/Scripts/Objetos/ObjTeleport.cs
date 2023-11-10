using UnityEngine;

public class ObjTeleport : MonoBehaviour
{
    [Header("Teleporte: ")]
    [SerializeField] private GameObject _TeleporteTo;

    [Header("Vari�vel de posi��o: ")]
    [SerializeField]
    private Vector3 newPosition;

    [Header("Vari�vel de rota��o: ")]
    [SerializeField]
    private Quaternion newRotation;

    void Update()
    {
        if (_TeleporteTo != null &&
            _TeleporteTo.GetComponent<InteractiveObjects>().status)
            Teleporte();
    }

    public void Teleporte() => gameObject.transform.SetPositionAndRotation
        (_TeleporteTo.transform.position + newPosition,
        newRotation);
}
