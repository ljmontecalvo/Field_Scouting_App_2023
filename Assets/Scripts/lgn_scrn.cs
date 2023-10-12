using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;
using TMPro;
using System.IO;

public class lgn_scrn : MonoBehaviour
{
    // Variables for objects in the UI.
    public GameObject accountsPrefab;
    public GameObject savePrefab;
    public GameObject matchNumberPrefab;
    private GameObject accounts;
    public TMP_InputField names;
    public Animator anim;

    string y; // <-- Temporary variable that will later hold the user inputed name.

    private void Awake()
    {
        if (GameObject.Find("Save(Clone)") == null)
        {
            Instantiate(savePrefab);
        }

        if (GameObject.Find("Accounts(Clone)") == null) // <-- Looks for object in scene that contains the accounts script
        {
            Instantiate(accountsPrefab); // If it doesn't find one, it will create one.
        }

        if (GameObject.Find("Match Number(Clone)") == null)
        {
            Instantiate(matchNumberPrefab);
        }
    }

    private void Start() // <-- Start runs on compile
    {
        if (GameObject.Find("PROFILE(Clone)") == null)
        {
            // CHANGED PATH
            if (File.Exists(Application.dataPath + "/save0.txt"))
                GameObject.FindGameObjectWithTag("Save").GetComponent<save>().LoadDataFromDevice();
        }

        accounts = GameObject.FindGameObjectWithTag("Accounts"); // Set the accounts variable to the one in the scene with the given tag.
    }

    public void SigninButton() // Everything in here is a check through the array in accounts.cs, which validates the user.
    {
        bool x = false;
        
        for (int i = 0; i < accounts.GetComponent<accounts>().allNames.Length; i++) 
        {
            if (names.text == accounts.GetComponent<accounts>().allNames[i]) 
            {
                x = true;
                y = names.text; 
                break;
            } else if (names.text=="Q")
            {
                SceneManager.LoadScene(7);
            }
        }

        if (x == true) 
        {
            accounts.GetComponent<accounts>().accountName = y;
            SceneManager.LoadScene(1); // <-- Loads the dashbaord
        } else 
        {
            anim.SetTrigger("trig"); // <-- Animation stuff
        }
    }
}
