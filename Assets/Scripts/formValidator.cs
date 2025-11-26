using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class formValidator : MonoBehaviour
{
    public string requiredTag;
    public Color correctColor = Color.green;
    public Color wrongColor = Color.red;
    public Color defaultColor = Color.white;

    private Renderer rend;
    private MaterialPropertyBlock block;

    private string[] recognizedTags = { "prism", "cube", "sphere", "cylindre" };
    private List<Collider> objectsInside = new List<Collider>();

    private enum State { Default, Correct, Wrong }
    private State currentState = State.Default;

    void Start()
    {
        rend = GetComponent<Renderer>();

        if (rend == null)
        {
            Debug.LogError("formValidator: NO RENDERER on " + gameObject.name);
            enabled = false;
            return;
        }

        block = new MaterialPropertyBlock();
        ApplyColor(defaultColor);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == null) return;
        if (!other.CompareTag("Untagged") && !objectsInside.Contains(other))
        {
            objectsInside.Add(other);
            UpdateState();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (objectsInside.Contains(other))
        {
            objectsInside.Remove(other);
            UpdateState();
        }
    }

    private void UpdateState()
    {
        objectsInside.RemoveAll(item => item == null);

        bool hasCorrect = false;
        bool hasWrong = false;

        foreach (var obj in objectsInside)
        {
            if (obj == null) continue;

            string tag = obj.tag;
            if (tag == requiredTag)
            {
                hasCorrect = true;
            }
            else
            {
                foreach (var t in recognizedTags)
                {
                    if (tag == t)
                    {
                        hasWrong = true;
                        break;
                    }
                }
            }
        }

        State newState =
            hasWrong ? State.Wrong :
            hasCorrect ? State.Correct :
            State.Default;

        if (newState == currentState) return;
        currentState = newState;

        switch (newState)
        {
            case State.Correct: ApplyColor(correctColor); break;
            case State.Wrong:
                InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
                if (device.TryGetHapticCapabilities(out HapticCapabilities caps) && caps.supportsImpulse)
                {
                    device.SendHapticImpulse(0, 0.7f, 0.8f);
                }
                ApplyColor(wrongColor); 
                break;
            default: ApplyColor(defaultColor); break;
        }
    }

    private void ApplyColor(Color color)
    {
        block.SetColor("_Color", color);
        rend.SetPropertyBlock(block);
    }

    public bool IsCorrect()
    {
        return currentState == State.Correct;
    }
}
