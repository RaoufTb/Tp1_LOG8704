using TMPro;
using UnityEngine;

public class VRMessage : MonoBehaviour
{
    public TextMeshProUGUI messageText;

    public string textToShow = "Hello VR!";
    public float duration = 2f;

    private bool isShowing = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ShowMessage());
        }
    }

    private System.Collections.IEnumerator ShowMessage()
    {
        isShowing = true;
        messageText.text = textToShow;
        messageText.enabled = true;

        yield return new WaitForSeconds(duration);

        messageText.enabled = false;
        isShowing = false;
    }
}
