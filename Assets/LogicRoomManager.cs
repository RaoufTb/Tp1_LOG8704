using TMPro;
using UnityEngine;

public class LogicRoomManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Light myLightQ1;
    public Light myLightQ2;
    public Light myLightQ3;

    public TMP_Text myTextQ1;
    public TMP_Text myTextQ2;
    public TMP_Text myTextQ3;

    public GameObject door;
    // Correct answers
    private int answerQ1 = 42;
    private int answerQ2 = 18;
    private int answerQ3 = 25;

    void Update()
    {
        CheckAnswers();
    }

    void CheckAnswers()
    {
        bool q1Correct = CheckQuestion(myTextQ1, myLightQ1, answerQ1);
        bool q2Correct = CheckQuestion(myTextQ2, myLightQ2, answerQ2);
        bool q3Correct = CheckQuestion(myTextQ3, myLightQ3, answerQ3);

        if (q1Correct && q2Correct && q3Correct)
        {
            if (door != null)
                door.SetActive(false);
        }
        }

        bool CheckQuestion(TMP_Text textField, Light lightField, int correctAnswer)
    {
        if (textField == null || lightField == null)
            return false;

        int currentValue;
        if (int.TryParse(textField.text, out currentValue))
        {
            if (currentValue == correctAnswer)
            {
                lightField.color = Color.green;
                return true;
            }
            else
            {
                lightField.color = Color.red;
                return false;
            }
        }
        else
        {
            lightField.color = Color.red;
            return false;
        }
    }
}
