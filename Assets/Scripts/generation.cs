using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
using ZXing;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine.SceneManagement;

public class generation : MonoBehaviour
{
    public RawImage rawImageReceiver;

    private Texture2D storeEncodedText;

    private GameObject[] profileObjects;
    private int profileNum;

    public string textWrite;

    public GameObject confirmDeletePopUp;

    private GameObject accounts;
    public TextMeshProUGUI name;

    private void Start()
    {
        storeEncodedText = new Texture2D(256, 256);

        profileObjects = GameObject.FindGameObjectsWithTag("Profile"); // Find said PROFILE object.

        profileNum = profileObjects.Length;

        accounts = GameObject.FindGameObjectWithTag("Accounts");
        name.text = accounts.GetComponent<accounts>().accountName;
    }

    private Color32[] Encode(string textForEncoding, int width, int height)
    {
        BarcodeWriter writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new ZXing.Common.EncodingOptions
            {
                Height = height,
                Width = width,
            }
        };
        return writer.Write(textForEncoding);
    }

    public void OnClickEncode()
    {
        EncodeTextToQRCode();
    }

    private void EncodeTextToQRCode()
    {
        for (int i = 0; i < profileObjects.Length; i++)
        {
            textWrite = textWrite +
                profileObjects[i].GetComponent<profile>().scouter + "," +
                profileObjects[i].GetComponent<profile>().teamNumber + "," +
                profileObjects[i].GetComponent<profile>().matchNumber + "," +
                profileObjects[i].GetComponent<profile>().color + "," +

                profileObjects[i].GetComponent<profile>().autoLowCones + "," +
                profileObjects[i].GetComponent<profile>().autoMidCones + "," +
                profileObjects[i].GetComponent<profile>().autoHighCones + "," +

                profileObjects[i].GetComponent<profile>().autoLowCubes + "," +
                profileObjects[i].GetComponent<profile>().autoMidCubes + "," +
                profileObjects[i].GetComponent<profile>().autoHighCubes + "," +

                profileObjects[i].GetComponent<profile>().autoHybrids + "," +
                profileObjects[i].GetComponent<profile>().autoChargingStationState + "," +
                profileObjects[i].GetComponent<profile>().leftCommunity + "," +
                profileObjects[i].GetComponent<profile>().autoHadPenalties + "," +
                profileObjects[i].GetComponent<profile>().secondPieceCollected + "," +

                profileObjects[i].GetComponent<profile>().lowCones + "," +
                profileObjects[i].GetComponent<profile>().midCones + "," +
                profileObjects[i].GetComponent<profile>().highCones + "," +

                profileObjects[i].GetComponent<profile>().lowCubes + "," +
                profileObjects[i].GetComponent<profile>().midCubes + "," +
                profileObjects[i].GetComponent<profile>().highCubes + "," +

                profileObjects[i].GetComponent<profile>().hybrids + "," +
                profileObjects[i].GetComponent<profile>().chargingStationState + "," +
                profileObjects[i].GetComponent<profile>().wasInCommunityOnEnd + "," +
                profileObjects[i].GetComponent<profile>().tripleBalance + ","+
                profileObjects[i].GetComponent<profile>().penalties + "," +
                profileObjects[i].GetComponent<profile>().disabled + "," +
                profileObjects[i].GetComponent<profile>().fellOver + "," +
                profileObjects[i].GetComponent<profile>().defense + ",";
        }

        Color32[] converPixelToTexture = Encode(textWrite, storeEncodedText.width, storeEncodedText.height);
        storeEncodedText.SetPixels32(converPixelToTexture);
        storeEncodedText.Apply();

        rawImageReceiver.texture = storeEncodedText;
    }

    public void BackButton()
    {
        SceneManager.LoadScene(1);
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
        }

        confirmDeletePopUp.SetActive(false);
    }

    public void Cancel()
    {
        confirmDeletePopUp.SetActive(false);
    }
}
