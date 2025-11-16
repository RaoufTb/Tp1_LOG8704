using TMPro;
using UnityEngine;

public class KeyPadManager : MonoBehaviour
{
    [SerializeField] private TMP_Text displayText;
    private string currentInput = "";

    public void OnNumberPressed(string value)
    {
        currentInput += value;
        UpdateDisplay();
    }

    public void OnClearPressed()
    {
        currentInput = "";
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        if (displayText != null)
            displayText.text = currentInput;
    }

    public string GetCurrentInput()
    {
        return currentInput;
    }
}
