using UnityEngine;

public class exitGrab : MonoBehaviour
{
    public Collider requiredSurface; // invisible zone with "Is Trigger" checked

    private Vector3 startPosition;
    private Quaternion startRotation;
    private Rigidbody myRigidbody;

    private bool isTouching = false;

    void Awake()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;

        myRigidbody = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other == requiredSurface)
        {
            isTouching = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other == requiredSurface)
        {
            isTouching = false;
        }
    }

    void Update()
    {
        if (!isTouching)
        {
            TeleportToStart();
        }
    }

    private void TeleportToStart()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;

        if (myRigidbody != null)
        {
            myRigidbody.linearVelocity = Vector3.zero;
            myRigidbody.angularVelocity = Vector3.zero;
        }
    }
}
