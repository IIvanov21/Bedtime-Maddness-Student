using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GraphicsMenu : MonoBehaviour
{
    [SerializeField]
    TMP_Text resolutionText;
    public List<ResItem> resolutions = new List<ResItem>();
    private int resolutionIndex;

    [SerializeField]
    TMP_Text qualityText;
    private Dictionary<int,string> qualitySettings = new Dictionary<int,string>();
    private int qualityIndex;

    // Start is called before the first frame update
    void Start()
    {
        //Handle custom resolutions by extracting current Screen width and height from the Users system
        bool foundRes = false;

        for (int i = 0; i < resolutions.Count; i++)
        {
            if (Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundRes = true;
                resolutionIndex = i;
                UpdateResolutionLabel();
            }
        }

        if (!foundRes)
        {
            ResItem newRes = new ResItem();
            newRes.horizontal=Screen.width;
            newRes.vertical=Screen.height;

            resolutions.Add(newRes);
            resolutionIndex=resolutions.Count-1;
            UpdateResolutionLabel();
        }

        //Handle Quality Settings
        qualitySettings.Add(0, "Very Low");
        qualitySettings.Add(1, "Low");
        qualitySettings.Add(2, "Medium");
        qualitySettings.Add(3, "High");
        qualitySettings.Add(4, "Very High");
        qualitySettings.Add(5, "Ultra");

        qualityIndex = QualitySettings.GetQualityLevel();
        UpdateQualityLabel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyGraphics()
    {
        //Handle resolutions settings
        Screen.SetResolution(resolutions[resolutionIndex].horizontal, resolutions[resolutionIndex].vertical, false);

        //Handle quality settings
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void ResLeft()
    {
        resolutionIndex--;
        if (resolutionIndex < 0)
        {
            resolutionIndex = 0;
        }
        UpdateResolutionLabel();
    }

    public void ResRight()
    {
        resolutionIndex++;
        if(resolutionIndex>resolutions.Count-1)resolutionIndex=resolutions.Count-1;
        UpdateResolutionLabel();
    }

    public void UpdateResolutionLabel()
    {
        resolutionText.text = resolutions[resolutionIndex].horizontal + "X" + resolutions[resolutionIndex].vertical;
    }

    public void QLeft()
    {
        qualityIndex--;
        if(qualityIndex<0)qualityIndex = 0;
        UpdateQualityLabel();
    }

    public void QRight()
    {
        qualityIndex++;
        if(qualityIndex>qualitySettings.Count-1)qualityIndex=qualitySettings.Count-1;
        UpdateQualityLabel();
    }

    public void UpdateQualityLabel()
    {
        qualityText.text = qualitySettings[qualityIndex];
    }
}

[System.Serializable]
public class ResItem
{
    public int horizontal;//width
    public int vertical;//height
}