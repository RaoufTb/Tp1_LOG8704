using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.XR;

public class LogicRoomManager : MonoBehaviour
{
    public Light myLightQ1;
    public Light myLightQ2;
    public Light myLightQ3;

    public TMP_Text myTextQ1;
    public TMP_Text myTextQ2;
    public TMP_Text myTextQ3;

    public GameObject door;

    private int answerQ1 = 42;
    private int answerQ2 = 40;
    private int answerQ3 = 25;

    public AudioClip goodSound;
    public AudioClip badSound;
    public AudioClip roomUnlocked;



    public AudioSource audioSourceQ1;
    public AudioSource audioSourceQ2;
    public AudioSource audioSourceQ3;

    public AudioSource audioRoom;


    private bool wasRightQ1 = false;
    private bool wasRightQ2 = false;
    private bool wasRightQ3 = false;

    private bool unlockedRoom = false;

    void Update()
    {
        CheckAnswers();
    }

    void CheckAnswers()
    {
        bool q1Correct = CheckQuestion(myTextQ1, myLightQ1, answerQ1, ref wasRightQ1, audioSourceQ1);
        bool q2Correct = CheckQuestion(myTextQ2, myLightQ2, answerQ2, ref wasRightQ2, audioSourceQ2);
        bool q3Correct = CheckQuestion(myTextQ3, myLightQ3, answerQ3, ref wasRightQ3, audioSourceQ3);

        if (q1Correct && q2Correct && q3Correct && door != null)
        {
            if (!unlockedRoom){
                audioRoom.PlayOneShot(roomUnlocked);
                unlockedRoom = true;
            }

            door.SetActive(false);
        }
    }

    bool CheckQuestion(TMP_Text textField, Light lightField, int correctAnswer, ref bool wasRight, AudioSource audioSource)
    {
        if (textField == null || lightField == null || audioSource == null)
            return false;

        int currentValue;
        if (int.TryParse(textField.text, out currentValue))
        {
            if (currentValue == correctAnswer)
            {
                lightField.color = Color.green;

                if (!wasRight)
                {
                    audioSource.PlayOneShot(goodSound);
                    wasRight = true;
                }

                return true;
            }
            else
            {
                lightField.color = Color.red;

                if (wasRight)
                {
                    audioSource.PlayOneShot(badSound);
                    wasRight = false;

                    InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
                    if (device.TryGetHapticCapabilities(out HapticCapabilities caps) && caps.supportsImpulse)
                    {
                        device.SendHapticImpulse(0, 0.7f, 0.8f);
                    }
                }

                return false;
            }
        }
        else
        {
            lightField.color = Color.red;

            if (wasRight)
            {
                audioSource.PlayOneShot(badSound);
                wasRight = false;
            }

            return false;
        }
    }
}
