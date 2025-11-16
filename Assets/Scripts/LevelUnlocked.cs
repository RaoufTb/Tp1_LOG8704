using UnityEngine;

public class LevelUnlocked : MonoBehaviour
{
    public GameObject targetToDeactivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (targetToDeactivate != null)
            {
                targetToDeactivate.SetActive(false);
            }
        }
    }
}
