using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IsPrimeNumber : MonoBehaviour
{
    //[SerializeField] int value;
    [SerializeField] bool isPrime;
    public int value;
    [SerializeField] Renderer objectRenderer;
    public Vector3 teleportPosition = new(-19, 0, 0); 
    [SerializeField] GameObject cameraRig;
    [SerializeField] GameObject cameraCollider;
    [SerializeField] TextMeshPro textMesh;
    List<int> primes = new() { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };


    public AudioSource audioRoom;
    public AudioClip goodAnswer;
    public AudioClip badAnswer;

    private void Start()
    {
        this.value =  isPrime ? GetRandomPrime() : GetRandomNumber();
        if (textMesh != null)
        {
            textMesh.text = value.ToString();
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == cameraCollider || other.transform.IsChildOf(cameraCollider.transform))
        {
            if (IsPrime(value))
            {
                objectRenderer.material.color = Color.yellow;
                audioRoom.PlayOneShot(goodAnswer);
            }
            else
            {
                objectRenderer.material.color = Color.red;
                if (teleportPosition != null && cameraRig != null)
                {
                    cameraRig.transform.position = teleportPosition;
                    audioRoom.PlayOneShot(badAnswer);
                }
            }
        }
    }



    public int GetRandomPrime()
    {
        return primes[Random.Range(0, primes.Count)];
    }

    public int GetRandomNumber()
    {
        int number;

        while (true)
        {
            number = Random.Range(0, 101);
            if(!IsPrime(number)) {
                break;
            }
        }
        return number;
    }
    private bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        int boundary = (int)Mathf.Floor(Mathf.Sqrt(number));
        for (int i = 3; i <= boundary; i += 2)
        {
            if (number % i == 0) return false;
        }
        return true;
    }
}

