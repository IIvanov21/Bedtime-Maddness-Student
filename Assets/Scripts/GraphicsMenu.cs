using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GraphicsMenu : MonoBehaviour
{
    [SerializeField]
    private Toggle fullScreenTog, vSyncTog;

    [SerializeField]
    TMP_Text resolutionText;
    public List<ResItem> resolutions = new List<ResItem>();
    private int resolutionIndex;

    //Quality Settings 
    [SerializeField]
    TMP_Text qualityText;
    public Dictionary<int, string> qualitySettings = new Dictionary<int, string>();
    private int qualityIndex;
    // Start is called before the first frame update
    void Start()
    {
        //Full Screen check
        fullScreenTog.isOn = Screen.fullScreen;

        //VSync Check
        if (QualitySettings.vSyncCount == 0)
        {
            vSyncTog.isOn = false;
        }
        else
        {
            vSyncTog.isOn=true;
        }

        //Resolution Check
        bool foundRes = false;

        for (int i = 0; i < resolutions.Count; i++)
        {
            if (Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundRes = true;
                resolutionIndex = i;
                UpdateResolutionText();
            }
        }

        if (!foundRes)
        {
            ResItem newRes = new ResItem();
            newRes.horizontal=Screen.width;
            newRes.vertical=Screen.height;

            resolutions.Add(newRes);
            resolutionIndex = resolutions.Count - 1;
            UpdateResolutionText();
        }

        //Populate the dictionary with quality settings
        qualitySettings.Add(0,"Very Low");
        qualitySettings.Add(1, "Low");
        qualitySettings.Add(2, "Medium");
        qualitySettings.Add(3, "High");
        qualitySettings.Add(4, "Very High");
        qualitySettings.Add(5, "Ultra");

        qualityIndex = QualitySettings.GetQualityLevel();
        UpdateQualityText();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyGraphics()
    {
        //VSync handler
        if (vSyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else QualitySettings.vSyncCount = 0;
        

        //Set the resolution and fullscreen mode
        Screen.SetResolution(resolutions[resolutionIndex].horizontal, resolutions[resolutionIndex].vertical, fullScreenTog.isOn);

        //Set the quality settings
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void ResLeft()
    {
        resolutionIndex--;
        if(resolutionIndex<0)resolutionIndex = 0;
        UpdateResolutionText();
    }

    public void ResRight()
    {
        resolutionIndex++;
        if(resolutionIndex>resolutions.Count-1)resolutionIndex = resolutions.Count-1;
        UpdateResolutionText();
    }

    public void UpdateResolutionText()
    {
        resolutionText.text = resolutions[resolutionIndex].horizontal + "x" + resolutions[resolutionIndex].vertical;
    }

    public void QLeft()
    {
        qualityIndex--;
        if(qualityIndex<0)qualityIndex = 0;
        UpdateQualityText();
    }

    public void QRight()
    {
        qualityIndex++;
        if(qualityIndex>qualitySettings.Count-1)qualityIndex=qualitySettings.Count-1;
        UpdateQualityText();
    }

    public void UpdateQualityText()
    {
        qualityText.text = qualitySettings[qualityIndex];
    }
}

[System.Serializable]
public class ResItem
{
    public int horizontal;
    public int vertical;
}