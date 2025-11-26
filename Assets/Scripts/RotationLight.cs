using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class RotationLight : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>();
    public Light myLight;

    public AudioClip goodSound;
    public AudioClip badSound;

    public AudioSource audioSource;

    private bool wasRight = false;

    void Update()
    {
        bool allZero = AllRotationZero();

        if (allZero)
        {
            myLight.color = Color.green;

            if (!wasRight)
            {
                PlaySound(goodSound); 
            }

            wasRight = true; 
        }
        else
        {
            myLight.color = Color.red;

            if (wasRight)
            {
                PlaySound(badSound);

                InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
                if (device.TryGetHapticCapabilities(out HapticCapabilities caps) && caps.supportsImpulse)
                {
                    device.SendHapticImpulse(0, 0.7f, 0.8f);
                }
            }

            wasRight = false; 
        }
    }

    bool AllRotationZero()
    {
        foreach (GameObject obj in objects)
        {
            if (obj.transform.rotation.x != 0)
                return false;
        }
        return true;
    }

    void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
