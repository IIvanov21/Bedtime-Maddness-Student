using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Gives access to Slider component
using TMPro; //Gives acces to TMP Text component
using UnityEngine.Audio;//Gives access to Audio Mixer component
public class AudioController : MonoBehaviour
{
    [SerializeField] private Slider master,ambient,music,player;//Slider references 
    [SerializeField] private TMP_Text masterVolume,ambientVolume,musicVolume,playerVolume;//Volume text references
    [SerializeField] private AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {

        SetStartingValues();
        master.onValueChanged.AddListener(delegate { SetMasterSound(); });
        ambient.onValueChanged.AddListener(delegate { SetAmbientSound(); });
        music.onValueChanged.AddListener (delegate { SetMusicSound(); });
        //player.onValueChanged.AddListener(delegate { SetPlayerSound(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMasterSound()
    {
        audioMixer.SetFloat("MasterVolume", master.value);
        float percentage = ((-80.0f - master.value) / -80.0f) * 100.0f;
        int wholeNum = (int)percentage;
        masterVolume.text = wholeNum.ToString();
    }

    public void SetMusicSound()
    {
        audioMixer.SetFloat("MusicVolume", music.value);
        float percentage = ((-80.0f - music.value) / -80.0f) * 100.0f;
        int wholeNum = (int)percentage;
        musicVolume.text = wholeNum.ToString();
    }

    public void SetAmbientSound()
    {
        audioMixer.SetFloat("AmbientVolume", ambient.value);
        float percentage = ((-80.0f - ambient.value) / -80.0f) * 100.0f;
        int wholeNum = (int)percentage;
        ambientVolume.text = wholeNum.ToString();
    }

    public void SetPlayerSound()
    {
        audioMixer.SetFloat("PlayerVolume", player.value);
        float percentage = ((-80.0f - player.value) / -80.0f) * 100.0f;
        int wholeNum = (int)percentage;
        playerVolume.text = wholeNum.ToString();
    }

    void SetStartingValues()
    {
        float percentage = 0, value = 0;
        int wholeNum = 0;

        audioMixer.GetFloat("MasterVolume", out value);
        master.value = value;
        percentage = ((-80.0f - value) / -80.0f) * 100.0f;
        wholeNum = (int)percentage;
        masterVolume.text = wholeNum.ToString();

        audioMixer.GetFloat("AmbientVolume", out value);
        ambient.value = value;
        percentage = ((-80.0f - value) / -80.0f) * 100.0f;
        wholeNum = (int)percentage;
        ambientVolume.text = wholeNum.ToString();

        audioMixer.GetFloat("MusicVolume", out value);
        music.value = value;
        percentage = ((-80.0f - value) / -80.0f) * 100.0f;
        wholeNum = (int)percentage;
        musicVolume.text = wholeNum.ToString();

        audioMixer.GetFloat("PlayerVolume", out value);
        player.value = value;
        percentage = ((-80.0f - value) / -80.0f) * 100.0f;
        wholeNum = (int)percentage;
        playerVolume.text = wholeNum.ToString();
    }

    
}
