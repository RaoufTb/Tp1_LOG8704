using UnityEngine;

public class FormRoom : MonoBehaviour
{
    public GameObject door;

    private formValidator[] validators;
    private bool doorOpened = false;
    public AudioSource audioRoom;
    private bool unlockedRoom = false;
    public AudioClip roomUnlocked;

    private void Start()
    {
        validators = GetComponentsInChildren<formValidator>();
    }

    private void Update()
    {
        if (doorOpened)
            return;

        bool allCorrect = true;

        foreach (var validator in validators)
        {
            if (!validator.IsCorrect())
            {
                allCorrect = false;
                break;
            }
        }

        if (allCorrect)
        {
            if (!unlockedRoom)
            {
                audioRoom.PlayOneShot(roomUnlocked);
                unlockedRoom = true;
            }
            door.SetActive(false); 
            doorOpened = true;    
        }
    }
}
