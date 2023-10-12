using TMPro;
using UnityEngine.UI;
using UnityEngine;
using ZXing;
using UnityEngine.SceneManagement;

public class scanningTest : MonoBehaviour
{
    [SerializeField]
    private RawImage _rawImageBackground;
    [SerializeField]
    private AspectRatioFitter _aspectRatioFitter;
    [SerializeField]
    private RectTransform _scanZone;

    private bool _isCamAvaible;
    private WebCamTexture _cameraTexture;

    public GameObject profilePrefab;

    private const string SAVE_SEPARATOR = ",";

    void Start()
    {
        SetUpCamera();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateCameraRender();
        Scan();
    }

    private void SetUpCamera()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length == 0)
        {
            _isCamAvaible = false;
            return;
        }
        for (int i = 0; i < devices.Length; i++)
        {
            if (devices[i].isFrontFacing == false)
            {
                _cameraTexture = new WebCamTexture(devices[i].name, (int)_scanZone.rect.width, (int)_scanZone.rect.height);
                break;
            }
        }
        _cameraTexture.Play();
        _rawImageBackground.texture = _cameraTexture;
        _isCamAvaible = true;
    }

    private void UpdateCameraRender()
    {
        if (_isCamAvaible == false)
        {
            return;
        }
        float ratio = (float)_cameraTexture.width / (float)_cameraTexture.height;
        _aspectRatioFitter.aspectRatio = ratio;

        int orientation = _cameraTexture.videoRotationAngle;
        orientation = orientation * 3;
        _rawImageBackground.rectTransform.localEulerAngles = new Vector3(0, 0, orientation);

    }
    public void OnClickScan()
    {
        Scan();
    }

    private void Scan()
    {
        IBarcodeReader barcodeReader = new BarcodeReader();
        Result result = barcodeReader.Decode(_cameraTexture.GetPixels32(), _cameraTexture.width, _cameraTexture.height);
        if (result != null)
        {
            Debug.Log(result.Text);
            string savedString = result.Text;
            string[] contents = savedString.Split(new[] { SAVE_SEPARATOR }, System.StringSplitOptions.None);

            int scoutCount = contents.Length / 26;

            for (int i = 0; i < scoutCount; i++)
            {
                Debug.Log(contents[i]);
            }

            for (int i = 0; i < scoutCount; i++)
            {
                GameObject profile = Instantiate(profilePrefab);
                profile.GetComponent<profile>().scouter = int.Parse(contents[0 + (29 * i)]);
                profile.GetComponent<profile>().teamNumber = int.Parse(contents[1 + (29 * i)]);
                profile.GetComponent<profile>().matchNumber = int.Parse(contents[2 + (29 * i)]);
                profile.GetComponent<profile>().color = int.Parse(contents[3 + (29 * i)]);

                profile.GetComponent<profile>().autoLowCones = int.Parse(contents[4 + (29 * i)]);
                profile.GetComponent<profile>().autoMidCones = int.Parse(contents[5 + (29 * i)]);
                profile.GetComponent<profile>().autoHighCones = int.Parse(contents[6 + (29 * i)]);

                profile.GetComponent<profile>().autoLowCubes = int.Parse(contents[7 + (29 * i)]);
                profile.GetComponent<profile>().autoMidCubes = int.Parse(contents[8 + (29 * i)]);
                profile.GetComponent<profile>().autoHighCubes = int.Parse(contents[9 + (29 * i)]);

                profile.GetComponent<profile>().autoHybrids = int.Parse(contents[10 + (29 * i)]);
                profile.GetComponent<profile>().autoChargingStationState = int.Parse(contents[11 + (29 * i)]);
                profile.GetComponent<profile>().leftCommunity = int.Parse(contents[12 + (29 * i)]);
                profile.GetComponent<profile>().autoHadPenalties = int.Parse(contents[13 + (29 * i)]);
                profile.GetComponent<profile>().secondPieceCollected = int.Parse(contents[14 + (29 * i)]);

                profile.GetComponent<profile>().lowCones = int.Parse(contents[17 + (29 * i)]);
                profile.GetComponent<profile>().midCones = int.Parse(contents[16 + (29 * i)]);
                profile.GetComponent<profile>().highCones = int.Parse(contents[15 + (29 * i)]);

                profile.GetComponent<profile>().lowCubes = int.Parse(contents[20 + (29 * i)]);
                profile.GetComponent<profile>().midCubes = int.Parse(contents[19 + (29 * i)]);
                profile.GetComponent<profile>().highCubes = int.Parse(contents[18 + (29 * i)]);

                profile.GetComponent<profile>().hybrids = int.Parse(contents[21 + (26 * i)]);
                profile.GetComponent<profile>().chargingStationState = int.Parse(contents[22 + (29 * i)]);
                profile.GetComponent<profile>().wasInCommunityOnEnd = int.Parse(contents[23 + (29 * i)]);
                profile.GetComponent<profile>().tripleBalance = int.Parse(contents[24 + (29 * i)]);
                profile.GetComponent<profile>().penalties = int.Parse(contents[25 + (29 * i)]);
                profile.GetComponent<profile>().disabled = int.Parse(contents[26 + (29 * i)]);
                profile.GetComponent<profile>().fellOver = int.Parse(contents[27 + (29 * i)]);
                profile.GetComponent<profile>().defense = int.Parse(contents[28 + (29 * i)]);
            }

            SceneManager.LoadScene(7);
        }
    }

    public void Back()
    {
        SceneManager.LoadScene(7); 
    }
}