using UnityEngine;

public class FollowCameraRig : MonoBehaviour
{
    [SerializeField] private Transform cameraRig;
    [SerializeField] private Vector3 offset = Vector3.zero; 

    void LateUpdate()
    {
        if (cameraRig != null)
        {
            transform.position = cameraRig.position + offset;
            transform.rotation = cameraRig.rotation; 
        }
    }
}
