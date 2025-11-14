using UnityEngine;
using Meta.XR.BuildingBlocks;


public class PhysicsMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveForce = 500f;
    public float rotateForce = 500f;
    private Rigidbody rb;
    private bool isGrabbed = false;
    private Transform grabTarget;

    void Awake() => rb = GetComponent<Rigidbody>();

    public void OnSelect(Transform hand)
    {
        grabTarget = hand;
        isGrabbed = true;
    }

    public void OnDeselect()
    {
        isGrabbed = false;
        grabTarget = null;
    }

    void FixedUpdate()
    {
        if (!isGrabbed || grabTarget == null) return;

        var posDelta = grabTarget.position - rb.position;
        rb.AddForce(posDelta * moveForce * Time.fixedDeltaTime, ForceMode.Acceleration);

        var rotDelta = grabTarget.rotation * Quaternion.Inverse(rb.rotation);
        rotDelta.ToAngleAxis(out float angle, out Vector3 axis);
        rb.AddTorque(axis * angle * rotateForce * Time.fixedDeltaTime, ForceMode.Acceleration);
    }
}
