using UnityEngine;

public class ObjTeleport2 : MonoBehaviour
{
    public static ObjTeleport2 instance;

    [Header("Teleporte: ")]
    [SerializeField] private GameObject teleporteTo;

    [Header("Variável de posição: ")]
    [SerializeField]
    private Vector3 newPosition;

    [Header("Variável de rotação: ")]
    [SerializeField]
    private Quaternion newRotation;

    [Header("Status: ")]
    [SerializeField]
    internal bool statusTeleporte = false;

    private void Start()
    {
    }

    void Update()
    {
        if (teleporteTo != null &&
            teleporteTo.GetComponent<InteractiveObjects>().status)
            Teleporte();
    }

    public void Teleporte()
    {
        gameObject.transform.SetPositionAndRotation
        (teleporteTo.transform.position + newPosition,
        newRotation);

        statusTeleporte = true;
    }
}