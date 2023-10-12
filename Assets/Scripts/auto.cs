using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class auto : MonoBehaviour
{
    public TextMeshProUGUI name;
    private GameObject accounts;

    // Other GUI elements.
    public Toggle exitedCommunity;
    public Toggle hadPenaltiesToggle;
    public Toggle failed;
    public Toggle balanced;
    public Toggle secondPieces;

    // All scouter inputed stats.
    private int coneHighCount = 0;
    private int coneMidCount = 0;
    private int cubeHighCount = 0;
    private int cubeMidCount = 0;
    private int hybridCount = 0;
    private int cubeLowCount = 0;
    private int coneLowCount = 0;
    private int chargingStationStatus = 0;
    public Text cubeHighCounter;
    public Text cubeMidCounter;
    public Text coneHighCounter;
    public Text coneMidCounter;
    public Text coneLowCounter;
    public Text cubeLowCounter;

    public GameObject[] profileObjects;

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
        SceneManager.LoadScene(1); // <-- Load Dashboard.
    }

    public void Teleop()
    {
        CompileData();
        SceneManager.LoadScene(4); // <-- Load Teleop.
    }

    public bool verify()
    {
        if ((coneHighCount + coneMidCount + coneLowCount + cubeHighCount + cubeMidCount + cubeLowCount) >= 5)
        {
            return true;
        }
        else
            return false;
    }

    public void HighCubeAdd()
    {
        if (!verify())
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
        if (!verify())
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
        if (!verify())
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
        if (!verify())
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
        if(!verify())
        coneMidCount++;
        coneMidCounter.text = coneMidCount.ToString();
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
        if (!verify())
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

        if (balanced.isOn)
        {
            chargingStationStatus = 2;
        } else if (failed.isOn)
        {
            chargingStationStatus = 1;
        } else
        {
            chargingStationStatus = 0;
        }

        hybridCount = coneLowCount + cubeLowCount;

        int profileNum = profileObjects.Length - 1;

        if (secondPieces.isOn)
            profileObjects[profileNum].GetComponent<profile>().secondPieceCollected = 1;
        else
            profileObjects[profileNum].GetComponent<profile>().secondPieceCollected = 0;

        if (exitedCommunity.isOn)
            profileObjects[profileNum].GetComponent<profile>().leftCommunity = 1;
        else
            profileObjects[profileNum].GetComponent<profile>().leftCommunity = 0;

        if (hadPenaltiesToggle.isOn)
            profileObjects[profileNum].GetComponent<profile>().autoHadPenalties = 1;
        else
            profileObjects[profileNum].GetComponent<profile>().autoHadPenalties = 0;
        
        profileObjects[profileNum].GetComponent<profile>().autoHighCones = coneHighCount;
        profileObjects[profileNum].GetComponent<profile>().autoMidCones = coneMidCount;
        profileObjects[profileNum].GetComponent<profile>().autoHighCubes = cubeHighCount;
        profileObjects[profileNum].GetComponent<profile>().autoMidCubes = cubeMidCount;
        profileObjects[profileNum].GetComponent<profile>().autoLowCones = coneLowCount;
        profileObjects[profileNum].GetComponent<profile>().autoLowCubes = cubeLowCount;
        profileObjects[profileNum].GetComponent<profile>().autoHybrids = hybridCount;
        profileObjects[profileNum].GetComponent<profile>().autoChargingStationState = chargingStationStatus;

        SceneManager.LoadScene(4);
    }
}
