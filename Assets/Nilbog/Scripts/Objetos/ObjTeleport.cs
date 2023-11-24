using UnityEngine;

public class ObjTeleport : MonoBehaviour
{
    public static ObjTeleport instance; 

    [Header("Teleporte: ")]
    [SerializeField] private GameObject teleporteTo;

    [Header("Vari�vel de posi��o: ")]
    [SerializeField]
    private Vector3 newPosition;

    [Header("Vari�vel de rota��o: ")]
    [SerializeField]
    private Quaternion newRotation;

    [Header("Status: ")]
    [SerializeField]
    internal bool statusTeleporte = false;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (teleporteTo != null &&
            teleporteTo.GetComponent<InteractiveObjects>().status)
            Teleporte();
    }

    public void Teleporte()
    {
        animator.enabled = false;

        gameObject.transform.SetPositionAndRotation
        (teleporteTo.transform.position + newPosition,
        newRotation);

        statusTeleporte = true;
    }
}
