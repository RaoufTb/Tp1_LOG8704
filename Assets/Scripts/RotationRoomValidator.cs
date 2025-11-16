using System.Collections.Generic;
using UnityEngine;

public class RotationRoomValidator : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>();
    public GameObject door;


    public AudioSource audioRoom;
    private bool unlockedRoom = false;
    public AudioClip roomUnlocked;



    void Update()
    {
        if (AllRotationZero()) { 
            
            if (!unlockedRoom)
            {
                audioRoom.PlayOneShot(roomUnlocked);
                unlockedRoom = true;
            }
            door.SetActive(false);


        }


    }

    bool AllRotationZero() {

        foreach (GameObject obj in objects) {
            if (obj.transform.rotation.x != 0)
                return false;
        }

        return true; 
    }
}
