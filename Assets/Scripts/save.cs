using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D.IK;

public class save : MonoBehaviour
{
    private const string SAVE_SEPARATOR = ",";

    private GameObject[] profileObjects;
    public GameObject profilePrefab;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
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


        PlayerPrefs.SetInt("saveNameCount", profileObjects.Length);
    }

    public void LoadDataFromDevice()
    {
        if (PlayerPrefs.GetInt("saveNameCount") == null)
        {
            Debug.Log("The saveNameCount variable is null.");
            return;
        }

        for (int i = 0; i < PlayerPrefs.GetInt("saveNameCount"); i++)
        {
            Debug.Log("The initiation process is starting.");
            // CHANGED PATH
            string savedString = File.ReadAllText("/sdcard/Document" + "/save" + i + ".txt");
            string[] contents = savedString.Split(new[] { SAVE_SEPARATOR }, System.StringSplitOptions.None);

            Instantiate(profilePrefab);
            profileObjects = GameObject.FindGameObjectsWithTag("Profile");

            profileObjects[i].GetComponent<profile>().scouter = int.Parse(contents[0]);
            profileObjects[i].GetComponent<profile>().teamNumber = int.Parse(contents[1]);
            profileObjects[i].GetComponent<profile>().matchNumber = int.Parse(contents[2]);
            profileObjects[i].GetComponent<profile>().color = int.Parse(contents[3]);

            profileObjects[i].GetComponent<profile>().autoLowCones = int.Parse(contents[4]);
            profileObjects[i].GetComponent<profile>().autoMidCones = int.Parse(contents[5]);
            profileObjects[i].GetComponent<profile>().autoHighCones = int.Parse(contents[6]);

            profileObjects[i].GetComponent<profile>().autoLowCubes = int.Parse(contents[7]);
            profileObjects[i].GetComponent<profile>().autoMidCubes = int.Parse(contents[8]);
            profileObjects[i].GetComponent<profile>().autoHighCubes = int.Parse(contents[9]);


            profileObjects[i].GetComponent<profile>().autoHybrids = int.Parse(contents[10]);
            profileObjects[i].GetComponent<profile>().autoChargingStationState = int.Parse(contents[11]);
            profileObjects[i].GetComponent<profile>().leftCommunity = int.Parse(contents[12]);
            profileObjects[i].GetComponent<profile>().autoHadPenalties = int.Parse(contents[13]);
            profileObjects[i].GetComponent<profile>().secondPieceCollected = int.Parse(contents[14]);

            profileObjects[i].GetComponent<profile>().lowCones = int.Parse(contents[19]);
            profileObjects[i].GetComponent<profile>().midCones = int.Parse(contents[16]);
            profileObjects[i].GetComponent<profile>().highCones = int.Parse(contents[15]);

            profileObjects[i].GetComponent<profile>().lowCubes = int.Parse(contents[20]);
            profileObjects[i].GetComponent<profile>().midCubes = int.Parse(contents[18]);
            profileObjects[i].GetComponent<profile>().highCubes = int.Parse(contents[17]);

            profileObjects[i].GetComponent<profile>().hybrids = int.Parse(contents[21]);
            profileObjects[i].GetComponent<profile>().chargingStationState = int.Parse(contents[22]);
            profileObjects[i].GetComponent<profile>().wasInCommunityOnEnd = int.Parse(contents[23]);
            profileObjects[i].GetComponent<profile>().tripleBalance = int.Parse(contents[24]);
            profileObjects[i].GetComponent<profile>().penalties = int.Parse(contents[25]);
            profileObjects[i].GetComponent<profile>().disabled = int.Parse(contents[26]);
            profileObjects[i].GetComponent<profile>().fellOver = int.Parse(contents[27]);
            profileObjects[i].GetComponent<profile>().defense = int.Parse(contents[28]);
        }
    }
}
