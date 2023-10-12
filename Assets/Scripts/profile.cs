using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class profile : MonoBehaviour
{
    // Data
    public int scouter;
    public int teamNumber;
    public int matchNumber;
    public int color;

    public int autoLowCones;
    public int autoMidCones;
    public int autoHighCones;
    public int autoLowCubes;
    public int autoMidCubes;
    public int autoHighCubes;

    public int autoHybrids;
    public int autoChargingStationState; // 0: Off, 1: On, 2: On Engaged
    public int leftCommunity;
    public int autoHadPenalties;
    public int secondPieceCollected;

    public int lowCones;
    public int midCones;
    public int highCones;
    public int lowCubes;
    public int midCubes;
    public int highCubes;

    public int hybrids;
    public int chargingStationState; // 0: Off, 1: On, 2: On Engaged
    public int wasInCommunityOnEnd;
    public int tripleBalance;
    public int preventedBalance;

    public int penalties;
    public int disabled;
    public int fellOver;
    public int defense;

    [HideInInspector] public string finalData;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
