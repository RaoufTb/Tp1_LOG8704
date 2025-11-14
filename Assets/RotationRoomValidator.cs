using System.Collections.Generic;
using UnityEngine;

public class RotationRoomValidator : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>();
    public GameObject door;


    void Update()
    {
        if (AllRotationZero())
            door.SetActive(false);
    }

    bool AllRotationZero() {

        foreach (GameObject obj in objects) {
            if (obj.transform.rotation.x != 0)
                return false;
        }

        return true; 
    }
}
