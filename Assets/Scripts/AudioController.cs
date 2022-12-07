using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Gets access to the Slider classes
using UnityEngine.Audio;//Gets access to the Audio Mixer
using TMPro; //Gets access to the TMP Text calsses
public class AudioController : MonoBehaviour
{
    //Reference for the sliders
    [SerializeField] private Slider master, music, ambient, player;
    //Reference for the volume text
    [SerializeField] private TMP_Text masterVolume,musicVolume,ambientVolume,playerVolume;
    //Reference for the Audio Mixer
    [SerializeField] private AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        SetStartingValues();

        master.onValueChanged.AddListener(delegate { SetMasterVolume(); });
        music.onValueChanged.AddListener(delegate { SetMusicVolume(); });
        ambient.onValueChanged.AddListener(delegate { SetAmbientVolume(); });
        player.onValueChanged.AddListener(delegate { SetPlayerVolume(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMasterVolume()
    {
        audioMixer.SetFloat("MasterVolume", master.value);//Updating the parameter inside the Audio Mixer
        float percentage = ((-80.0f - master.value) / -80.0f) * 100.0f;//Convert the slider value to a percentage
        int wholeNum = (int)percentage;//Convert the percentage to a whole number
        masterVolume.text = wholeNum.ToString() ;//Conver out whole number into a string
    }

    public void SetMusicVolume()
    {
        audioMixer.SetFloat("MusicVolume", music.value);//Updating the parameter inside the Audio Mixer
        float percentage = ((-80.0f - music.value) / -80.0f) * 100.0f;//Convert the slider value to a percentage
        int wholeNum = (int)percentage;//Convert the percentage to a whole number
        musicVolume.text = wholeNum.ToString();//Conver out whole number into a string
    }

    public void SetAmbientVolume()
    {
        audioMixer.SetFloat("AmbientVolume", ambient.value);//Updating the parameter inside the Audio Mixer
        float percentage = ((-80.0f - ambient.value) / -80.0f) * 100.0f;//Convert the slider value to a percentage
        int wholeNum = (int)percentage;//Convert the percentage to a whole number
        ambientVolume.text = wholeNum.ToString();//Conver out whole number into a string
    }

    public void SetPlayerVolume()
    {
        audioMixer.SetFloat("PlayerVolume", player.value);//Updating the parameter inside the Audio Mixer
        float percentage = ((-80.0f - player.value) / -80.0f) * 100.0f;//Convert the slider value to a percentage
        int wholeNum = (int)percentage;//Convert the percentage to a whole number
        playerVolume.text = wholeNum.ToString();//Conver out whole number into a string

        //Accurate calculation of volume
        //Ensure your slider min value is set to 0
        //Ensure your slider max value is set to 1
        float value = LinearToDecibel(player.value);//Turn our slider value into dB
        audioMixer.SetFloat("PlayerVolume", value);
        int wholeNum2 = (int)(player.value * 100.0f);
        playerVolume.text = wholeNum2.ToString();

    }

    private float LinearToDecibel(float linear)
    {
        float dB;
        if (linear != 0)
        {
            dB = 20.0f * Mathf.Log10(linear);
        }
        else
        {
            dB = -144.0f;
        }
        return dB;
    }

    private float DecibelToLinear(float dB)
    {
        float linear = Mathf.Pow(10.0f, dB / 20.0f);
        return linear;
    }

    void SetStartingValues()
    {
        float percentage = 0, value = 0;
        int wholeNum = 0;

        //Master
        audioMixer.GetFloat("MasterVolume", out value);//Extract the volume out of the audioMixer
        master.value = value;//Update the slider
        percentage = ((-80.0f - value) / -80.0f) * 100.0f;//Convert our value into percentage between -80(min) and 0(max)
        wholeNum = (int)percentage;//Convert our percentage to a whole number
        masterVolume.text=wholeNum.ToString();//Convert our wholeNumber into a string

        //Music
        audioMixer.GetFloat("MusicVolume", out value);//Extract the volume out of the audioMixer
        music.value = value;//Update the slider
        percentage = ((-80.0f - value) / -80.0f) * 100.0f;//Convert our value into percentage between -80(min) and 0(max)
        wholeNum = (int)percentage;//Convert our percentage to a whole number
        musicVolume.text = wholeNum.ToString();//Convert our wholeNumber into a string

        //Ambient
        audioMixer.GetFloat("AmbientVolume", out value);//Extract the volume out of the audioMixer
        ambient.value = value;//Update the slider
        percentage = ((-80.0f - value) / -80.0f) * 100.0f;//Convert our value into percentage between -80(min) and 0(max)
        wholeNum = (int)percentage;//Convert our percentage to a whole number
        ambientVolume.text = wholeNum.ToString();//Convert our wholeNumber into a string

        //Player
        audioMixer.GetFloat("PlayerVolume", out value);//Extract the volume out of the audioMixer
        player.value = value;//Update the slider
        percentage = ((-80.0f - value) / -80.0f) * 100.0f;//Convert our value into percentage between -80(min) and 0(max)
        wholeNum = (int)percentage;//Convert our percentage to a whole number
        playerVolume.text = wholeNum.ToString();//Convert our wholeNumber into a string
    }
}
