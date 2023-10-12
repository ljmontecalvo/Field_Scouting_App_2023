using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PostMatch : MonoBehaviour
{
    public TextMeshProUGUI name;
    private GameObject accounts;

    private const string SAVE_SEPARATOR = ",";

    // Other GUI elements.
    public Toggle penalties;
    public Toggle disabled;
    public Toggle fellOver;
    public Toggle defense;

    public GameObject[] profileObjects;
    private GameObject saveObject;
    private GameObject matchNumberObject;

    public TMP_Text robotNumberBox;

    private void Start()
    {
        accounts = GameObject.FindGameObjectWithTag("Accounts");
        name.text = accounts.GetComponent<accounts>().accountName;
        profileObjects = GameObject.FindGameObjectsWithTag("Profile");
        saveObject = GameObject.FindGameObjectWithTag("Save");
        matchNumberObject = GameObject.FindGameObjectWithTag("Match Number Object");

        robotNumberBox.text = profileObjects[profileObjects.Length - 1].GetComponent<profile>().teamNumber.ToString();
    }

    public void BackButton()
    {
        SceneManager.LoadScene(3);
    }

    public void Finish()
    {
        CompileData();
        SceneManager.LoadScene(1);
        saveObject.GetComponent<save>().SaveDataToDevice();
    }

    public int toggleData(Toggle buttonSwitch)
    {
        if (buttonSwitch.isOn)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    // Logic for inputs.
    public void CompileData()
    {
        // Apply all stats to the newest PROFILE object in the scene.

        int profileNum = profileObjects.Length - 1;

        profileObjects[profileNum].GetComponent<profile>().disabled = toggleData(disabled);
        profileObjects[profileNum].GetComponent<profile>().fellOver = toggleData(fellOver);
        profileObjects[profileNum].GetComponent<profile>().defense = toggleData(defense);
        profileObjects[profileNum].GetComponent<profile>().penalties = toggleData(penalties);

        SaveDataToDevice();

        SceneManager.LoadScene(1);
    }

    public void SaveDataToDevice()
    {
        profileObjects = GameObject.FindGameObjectsWithTag("Profile");

        string[] contents = new string[]
        {
            "" + profileObjects[profileObjects.Length - 1].GetComponent<profile>().scouter,
            "" + profileObjects[profileObjects.Length - 1].GetComponent<profile>().teamNumber,
            "" + profileObjects[profileObjects.Length - 1].GetComponent<profile>().matchNumber,
            "" + profileObjects[profileObjects.Length - 1].GetComponent<profile>().color,
            
            "" + profileObjects[profileObjects.Length - 1].GetComponent<profile>().autoLowCones,
            "" + profileObjects[profileObjects.Length - 1].GetComponent<profile>().autoMidCones,
            "" + profileObjects[profileObjects.Length - 1].GetComponent<profile>().autoHighCones,

            "" + profileObjects[profileObjects.Length - 1].GetComponent<profile>().autoLowCubes,
            "" + profileObjects[profileObjects.Length - 1].GetComponent<profile>().autoMidCubes,
            "" + profileObjects[profileObjects.Length - 1].GetComponent<profile>().autoHighCubes,
        
            "" + profileObjects[profileObjects.Length - 1].GetComponent<profile>().autoHybrids,
            "" + profileObjects[profileObjects.Length - 1].GetComponent<profile>().autoChargingStationState,
            "" + profileObjects[profileObjects.Length - 1].GetComponent<profile>().leftCommunity,
            "" + profileObjects[profileObjects.Length - 1].GetComponent<profile>().autoHadPenalties,
            "" + profileObjects[profileObjects.Length - 1].GetComponent<profile>().secondPieceCollected,

            "" + profileObjects[profileObjects.Length - 1].GetComponent<profile>().lowCones,
            "" + profileObjects[profileObjects.Length - 1].GetComponent<profile>().midCones,
            "" + profileObjects[profileObjects.Length - 1].GetComponent<profile>().highCones,

            "" + profileObjects[profileObjects.Length - 1].GetComponent<profile>().lowCubes,
            "" + profileObjects[profileObjects.Length - 1].GetComponent<profile>().midCubes,
            "" + profileObjects[profileObjects.Length - 1].GetComponent<profile>().highCubes,
            
            "" + profileObjects[profileObjects.Length - 1].GetComponent<profile>().hybrids,
            "" + profileObjects[profileObjects.Length - 1].GetComponent<profile>().chargingStationState,
            "" + profileObjects[profileObjects.Length - 1].GetComponent<profile>().wasInCommunityOnEnd,
            "" + profileObjects[profileObjects.Length - 1].GetComponent<profile>().tripleBalance,
            "" + profileObjects[profileObjects.Length - 1].GetComponent<profile>().penalties,
            "" + profileObjects[profileObjects.Length - 1].GetComponent<profile>().disabled,
            "" + profileObjects[profileObjects.Length - 1].GetComponent<profile>().fellOver,
            "" + profileObjects[profileObjects.Length - 1].GetComponent<profile>().defense,
        };

        string saveString = string.Join(SAVE_SEPARATOR, contents);
        // CHANGED PATH
        File.WriteAllText("/sdcard/Documents" + "/save" + PlayerPrefs.GetInt("saveNameCount") + ".txt", saveString);
        PlayerPrefs.SetInt("saveNameCount", PlayerPrefs.GetInt("saveNameCount") + 1);
    }
}
