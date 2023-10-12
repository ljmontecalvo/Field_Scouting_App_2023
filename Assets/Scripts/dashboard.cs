using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class dashboard : MonoBehaviour
{
    public TextMeshProUGUI name;
    private GameObject accounts;

    private void Start()
    {
        accounts = GameObject.FindGameObjectWithTag("Accounts");
        name.text = accounts.GetComponent<accounts>().accountName; // Sets the name text at the upper left hand corner to the user inputed name (You will see this in scripts with an app bar).

        if (GameObject.Find("PROFILE(Clone)") != null)
        {
            GameObject[] profiles = GameObject.FindGameObjectsWithTag("Profile");
        }
    }

    public void SignOutButton()
    {
        SceneManager.LoadScene(0); // <-- Loads the sign in screen.
    }

    public void StartScout()
    {
        // Needs to be changed for team select screen.
        SceneManager.LoadScene(2); // <-- Loads the Team Select screen.
    }

    public void EditScout()
    {
        // Edit
    }

    public void GenerateButton()
    {
        SceneManager.LoadScene(6);
    }
}
