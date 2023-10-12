using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class admin : MonoBehaviour
{
    private string fileName = "";

    private GameObject[] profiles;
    public GameObject[] profileObjects;

    public GameObject confirmDeletePopUp;

    [System.Serializable]
    public class AutoMode
    {
        public string scouter;
        public int teamNumber;
        public int matchNumber;
        public string color;

        public int highCones;
        public int midCones;
        public int highCubes;
        public int midCubes;
        public int hybirds;
        public bool secondPieceCollected;

        public bool leftCommunity;
        public bool hadPenalties;

        public string chargingStationState;
    }

    [System.Serializable]
    public class TeleopMode
    {
        public int highCones;
        public int midCones;
        public int highCubes;
        public int midCubes;
        public int hybirds;
        public int piecesCollected;

        public bool wasInCommunityOnGameEnd;
        public bool hadPenalties;

        public string chargingStationState;
    }

    [System.Serializable]
    public class MatchList
    {
        public AutoMode[] autoModes;
        public TeleopMode[] teleopModes;
    }

    public MatchList matchList = new MatchList();

    private void Start()
    {
        fileName = Application.dataPath + "/sheet.csv";
        profiles = GameObject.FindGameObjectsWithTag("Profile");
        profileObjects = GameObject.FindGameObjectsWithTag("Profile");
    }

    public void Scan()
    {
        SceneManager.LoadScene(5);
    }

    string allData;

    public void GenerateFile()
    {
        profileObjects = GameObject.FindGameObjectsWithTag("Profile");
        int profileNum = profileObjects.Length;

        Debug.Log(profileNum);

        allData = "Scouter,Team Num,Match Num,Alliance,AutoHighCones,AutoMidCones,AutoLowCones,AutoHighCubes,AutoMidCubes,AutoLowCubes,AutoHybrid,autoCharge,leftCommunity,autoPenalties,Collected 2nd piece,TeleHighCones,TeleMidCones,TeleLowCones,TeleHighCubes,TeleMidCubes,TeleLowCubes,TeleHybrid,Charging Station,Ended in Community,Triple Balance,Penalties,Disabled,Fell Over,Defense\n";

        for (int i = 0; i < profileNum; i++)
        {
            
            allData += profileObjects[i].GetComponent<profile>().scouter; allData += ",";
            allData += profileObjects[i].GetComponent<profile>().teamNumber; allData += ",";
            allData += profileObjects[i].GetComponent<profile>().matchNumber; allData += ",";
            allData += profileObjects[i].GetComponent<profile>().color; allData += ",";
            allData += profileObjects[i].GetComponent<profile>().autoHighCones; allData += ",";
            allData += profileObjects[i].GetComponent<profile>().autoMidCones; allData += ",";
            allData += profileObjects[i].GetComponent<profile>().autoLowCones; allData += ",";
            allData += profileObjects[i].GetComponent<profile>().autoHighCubes; allData += ",";
            allData += profileObjects[i].GetComponent<profile>().autoMidCubes; allData += ",";
            allData += profileObjects[i].GetComponent<profile>().autoLowCubes; allData += ",";
            allData += profileObjects[i].GetComponent<profile>().autoHybrids; allData += ",";
            allData += profileObjects[i].GetComponent<profile>().autoChargingStationState; allData += ",";
            allData += profileObjects[i].GetComponent<profile>().leftCommunity; allData += ",";
            allData += profileObjects[i].GetComponent<profile>().autoHadPenalties; allData += ",";
            allData += profileObjects[i].GetComponent<profile>().secondPieceCollected; allData += ",";
            allData += profileObjects[i].GetComponent<profile>().highCones; allData += ",";
            allData += profileObjects[i].GetComponent<profile>().midCones; allData += ",";
            allData += profileObjects[i].GetComponent<profile>().lowCones; allData += ",";
            allData += profileObjects[i].GetComponent<profile>().highCubes; allData += ",";
            allData += profileObjects[i].GetComponent<profile>().midCubes; allData += ",";
            allData += profileObjects[i].GetComponent<profile>().lowCubes; allData += ",";
            allData += profileObjects[i].GetComponent<profile>().hybrids; allData += ",";
            allData += profileObjects[i].GetComponent<profile>().chargingStationState; allData += ",";
            allData += profileObjects[i].GetComponent<profile>().wasInCommunityOnEnd; allData += ",";
            allData += profileObjects[i].GetComponent<profile>().tripleBalance; allData += ",";
            allData += profileObjects[i].GetComponent<profile>().penalties; allData += ",";
            allData += profileObjects[i].GetComponent<profile>().disabled; allData += ",";
            allData += profileObjects[i].GetComponent<profile>().fellOver; allData += ",";
            allData += profileObjects[i].GetComponent<profile>().defense; allData += "\n";
            
            Debug.Log(allData);
        }

        Debug.Log(allData);

        if (profileNum > 0)
        {
            // CHANGED PATH
            File.WriteAllText("/sdcard/Documents" + "/Data.csv", allData);
        }
    }

    public void SignOut()
    {
        SceneManager.LoadScene(0);
    }

    public void Delete()
    {
        confirmDeletePopUp.SetActive(true);
    }

    public void DeleteEverything()
    {
        PlayerPrefs.DeleteAll();

        for (int i = 0; i < profileObjects.Length; i++)
        {
            Destroy(profileObjects[i]);
            File.Delete("/sdcard/Documents" + "/save" + i + ".txt");
            if (File.Exists("/sdcard/Documents/Data.csv"))
            {
                File.Delete("/sdcard/Documents/Data.csv");
            }
        }

        confirmDeletePopUp.SetActive(false);
    }

    public void Cancel()
    {
        confirmDeletePopUp.SetActive(false);
    }
}
