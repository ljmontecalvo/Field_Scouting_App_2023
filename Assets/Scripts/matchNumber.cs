using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class matchNumber : MonoBehaviour
{
    public int displayedNumber = 1;
    public int storedNumber = 1;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void NumberUpOne()
    {
        storedNumber++;
        SetNumber();
    }

    public void GetNumber()
    {
        if (GameObject.FindGameObjectWithTag("Match Number Input") != null)
        {
            storedNumber = int.Parse(GameObject.FindGameObjectWithTag("Match Number Input").GetComponent<TMP_InputField>().text);
        }
    }

    public void SetNumber()
    {
        displayedNumber = storedNumber;
        GameObject.FindGameObjectWithTag("Match Number Input").GetComponent<TMP_InputField>().text = displayedNumber.ToString();
    }
}
