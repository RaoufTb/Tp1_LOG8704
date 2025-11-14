using UnityEngine;

public class FormRoom : MonoBehaviour
{
    public GameObject door;

    private formValidator[] validators;
    private bool doorOpened = false;

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
            door.SetActive(false); 
            doorOpened = true;    
        }
    }
}
