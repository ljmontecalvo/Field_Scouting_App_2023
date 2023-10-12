using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class teleop : MonoBehaviour
{
    public TextMeshProUGUI name;
    private GameObject accounts;

    // Other GUI elements.
    public Toggle wasInCommunityOnEndToggle;
    public Toggle failed;
    public Toggle balanced;
    public Toggle tripleBalanceToggle;
    public Toggle preventedBalance;

    private int coneHighCount = 0;
    private int coneMidCount = 0;
    private int cubeHighCount = 0;
    private int cubeMidCount = 0;
    private int hybridCount = 0;
    private int cubeLowCount = 0;
    private int coneLowCount = 0;
    private int chargingStationStatus = 0;
    private bool wasInCommunityOnEnd = false;
    private bool tripleBalance = false;
    private bool preventedMulti = false;
    public Text cubeHighCounter;
    public Text cubeMidCounter;
    public Text coneHighCounter;
    public Text coneMidCounter;
    public Text coneLowCounter;
    public Text cubeLowCounter;

    public GameObject[] profileObjects;
    private GameObject saveObject;
    private GameObject matchNumberObject;

    public TMP_Text robotNumberBox;

    private void Start()
    {
        accounts = GameObject.FindGameObjectWithTag("Accounts");
        name.text = accounts.GetComponent<accounts>().accountName;
        profileObjects = GameObject.FindGameObjectsWithTag("Profile");

        robotNumberBox.text = profileObjects[profileObjects.Length - 1].GetComponent<profile>().teamNumber.ToString();
    }

    public void BackButton()
    {
        SceneManager.LoadScene(3);
    }

    public void Finish()
    {
        CompileData();
        SceneManager.LoadScene(8);
        //saveObject.GetComponent<save>().SaveDataToDevice();
        //matchNumberObject.GetComponent<matchNumber>().UpOne();
    }
    
    public void HighCubeAdd()
    {
        if (cubeHighCount < 3)
        {
            cubeHighCount++;
            cubeHighCounter.text = cubeHighCount.ToString();
        }
    }

    public void HighCubeSubtract()
    {
        if (cubeHighCount != 0)
        {
            cubeHighCount--;
            cubeHighCounter.text = cubeHighCount.ToString();
        }

    }
    public void MidCubeAdd()
    {
        if (cubeMidCount<3)
        {
            cubeMidCount++;
            cubeMidCounter.text = cubeMidCount.ToString();
        }
    }

    public void MidCubeSubtract()
    {
        if (cubeMidCount != 0)
        {
            cubeMidCount--;
            cubeMidCounter.text = cubeMidCount.ToString();
        }

    }
    public void CubeLowAdd()
    {
        if (hybridCount < 9)
        {
            cubeLowCount++;
            hybridCount++;
            cubeLowCounter.text = cubeLowCount.ToString();
        }
    }

    public void CubeLowSubtract()
    {
        if (cubeLowCount != 0)
        {
            cubeLowCount--;
            hybridCount--;
            cubeLowCounter.text = cubeLowCount.ToString();
        }

    }
    public void HighconeAdd()
    {
        if (coneHighCount<6)
        {
            coneHighCount++;
            coneHighCounter.text = coneHighCount.ToString();
        }
    }

    public void HighconeSubtract()
    {
        if (coneHighCount != 0)
        {
            coneHighCount--;
            coneHighCounter.text = coneHighCount.ToString();
        }

    }
    public void MidconeAdd()
    {
        if (coneMidCount < 6)
        {
            coneMidCount++;
            coneMidCounter.text = coneMidCount.ToString();
        }
    }

    public void MidconeSubtract()
    {
        if (coneMidCount != 0)
        {
            coneMidCount--;
            coneMidCounter.text = coneMidCount.ToString();
        }

    }
    public void coneLowAdd()
    {
        if (hybridCount < 9)
        {
            coneLowCount++;
            hybridCount++;
            coneLowCounter.text = coneLowCount.ToString();
        }
    }

    public void coneLowSubtract()
    {
        if (coneLowCount != 0)
        {
            coneLowCount--;
            hybridCount--;
            coneLowCounter.text = coneLowCount.ToString();
        }

    }

    // Logic for inputs.
    public void CompileData()
    {
        // Apply all stats to the newest PROFILE object in the scene.

        wasInCommunityOnEnd = wasInCommunityOnEndToggle.isOn;
        tripleBalance = tripleBalanceToggle.isOn;
        preventedMulti = preventedBalance.isOn;


        if (balanced.isOn)
        {
            chargingStationStatus = 2;
        }
        else if (failed.isOn)
        {
            chargingStationStatus = 1;
        }
        else
        {
            chargingStationStatus = 0;
        }

        int profileNum = profileObjects.Length - 1;

        if (wasInCommunityOnEnd && !balanced.isOn)
            profileObjects[profileNum].GetComponent<profile>().wasInCommunityOnEnd = 1;
        else
            profileObjects[profileNum].GetComponent<profile>().wasInCommunityOnEnd = 0;

        if (tripleBalance)
            profileObjects[profileNum].GetComponent<profile>().tripleBalance = 1;
        else
            profileObjects[profileNum].GetComponent<profile>().tripleBalance = 0;
        if (preventedMulti)
            profileObjects[profileNum].GetComponent<profile>().preventedBalance = 1;
        else
            profileObjects[profileNum].GetComponent<profile>().preventedBalance = 0;

        hybridCount = coneLowCount + cubeLowCount;
       
        profileObjects[profileNum].GetComponent<profile>().highCones = coneHighCount;
        profileObjects[profileNum].GetComponent<profile>().midCones = coneMidCount;
        profileObjects[profileNum].GetComponent<profile>().highCubes = cubeHighCount;
        profileObjects[profileNum].GetComponent<profile>().midCubes = cubeMidCount;
        profileObjects[profileNum].GetComponent<profile>().lowCones = coneLowCount;
        profileObjects[profileNum].GetComponent<profile>().lowCubes = cubeLowCount;
        profileObjects[profileNum].GetComponent<profile>().hybrids = hybridCount;
        profileObjects[profileNum].GetComponent<profile>().chargingStationState = chargingStationStatus;
    }
}
