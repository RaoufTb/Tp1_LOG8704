using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

public class formValidator : MonoBehaviour
{
    public string requiredTag;

    public Color correctColor = Color.green;
    public Color wrongColor = Color.red;
    public Color defaultColor = Color.white;

    private Renderer rend;

    private string[] recognizedTags = { "prism", "cube", "sphere", "cylindre" };

    private List<Collider> objectsInside = new List<Collider>();
    private AudioSource audioSource;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        if (rend != null)
            rend.material.color = defaultColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!objectsInside.Contains(other))
            objectsInside.Add(other);
    }

    private void OnTriggerExit(Collider other)
    {
        if (objectsInside.Contains(other))
            objectsInside.Remove(other);
    }


    private void Update()
    {
        bool hasCorrect = false;
        bool hasWrong = false;

        foreach (var obj in objectsInside)
        {
            string tagLower = obj.tag.ToLower();

            if (tagLower == requiredTag.ToLower())
                hasCorrect = true;
            else if (System.Array.Exists(recognizedTags, tag => tag == tagLower))
                hasWrong = true;
        }

        if (hasWrong)
        {
            rend.material.color = wrongColor;
        }
        else if (hasCorrect)
        {
            rend.material.color = correctColor;
        }
        else
        {
            rend.material.color = defaultColor;
        }

    }


    public bool IsCorrect()
    {
        bool hasCorrect = false;
        bool hasWrong = false;

        foreach (var obj in objectsInside)
        {
            string tagLower = obj.tag.ToLower();

            if (tagLower == requiredTag.ToLower())
                hasCorrect = true;
            else if (System.Array.Exists(recognizedTags, tag => tag == tagLower))
                hasWrong = true;
        }

        return hasCorrect && !hasWrong;
    }

}
