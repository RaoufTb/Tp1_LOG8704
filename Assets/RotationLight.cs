using System.Collections.Generic;
using UnityEngine;

public class RotationLight : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>();
    public Light myLight;


    void Update()
    {
        myLight.color = AllRotationZero() ? Color.green: Color.red;
        
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
}
