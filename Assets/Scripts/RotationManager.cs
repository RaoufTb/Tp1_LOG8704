using UnityEngine;

public class RotationManager : MonoBehaviour
{
    public GameObject[] objectsToRotate = new GameObject[4];

    public void RotateObject(int index)
    {
        if (index < 0 || index >= objectsToRotate.Length) return;
        if (objectsToRotate[index] == null) return;

        objectsToRotate[index].transform.Rotate(-90f, 0f, 0f, Space.Self);
    }
}
