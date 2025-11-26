using UnityEngine;

public class LevelUnlocked : MonoBehaviour
{
    public GameObject targetToDeactivate;
    public GameObject text;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (targetToDeactivate != null)
            {
                targetToDeactivate.SetActive(false);
                text.SetActive(true);

            }
        }
    }
}
