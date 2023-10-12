using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teamSelect : MonoBehaviour
{
    public TextMeshProUGUI name;
    private GameObject accounts;
    public GameObject profilePrefab;
    public GameObject[] profileObjects;
    public GameObject matchNumberObject;

    public TMP_Dropdown teamSelectDropdown;
    public TMP_Dropdown colorSelectDropdown;
    public TMP_InputField matchNumberInput;

    int x;

    private void Start()
    {
        GameObject.FindGameObjectWithTag("Match Number Object").GetComponent<matchNumber>().NumberUpOne();
        accounts = GameObject.FindGameObjectWithTag("Accounts");
        name.text = accounts.GetComponent<accounts>().accountName; // Sets the name text at the upper left hand corner to the user inputed name (You will see this in scripts with an app bar).
        matchNumberObject = GameObject.FindGameObjectWithTag("Match Number Object");
    }

    public void BackButton()
    {
        SceneManager.LoadScene(1); // <-- Load Dashboard.
    }

    public void Continue()
    {
        if(teamSelectDropdown.value != 0 && matchNumberInput.text != "Match Number")
        {
            Instantiate(profilePrefab); // <-- Creates a PROFILE object

            profileObjects = GameObject.FindGameObjectsWithTag("Profile"); // Find said PROFILE object.

            int profileNum = profileObjects.Length;

            for (int i = 0; i < accounts.GetComponent<accounts>().allNames.Length; i++)
            {
                if (name.text == accounts.GetComponent<accounts>().allNames[i])
                {
                    x = i;
                }
            }

            // Return the team number from the dropdown to the PROFILE's profile script.
            int teamDropdownValue = int.Parse(teamSelectDropdown.options[teamSelectDropdown.value].text);
            string colorDropdownValue = colorSelectDropdown.options[colorSelectDropdown.value].text;

            profileObjects[profileNum - 1].GetComponent<profile>().teamNumber = teamDropdownValue;
            if (colorDropdownValue == "red")
                profileObjects[profileNum - 1].GetComponent<profile>().color = 0;
            else
                profileObjects[profileNum - 1].GetComponent<profile>().color = 1;
            profileObjects[profileNum - 1].GetComponent<profile>().matchNumber = int.Parse(matchNumberInput.text);
            profileObjects[profileNum - 1].GetComponent<profile>().scouter = x;

            GameObject.FindGameObjectWithTag("Match Number Object").GetComponent<matchNumber>().GetNumber();

            SceneManager.LoadScene(3);
        }
        
    }
}
