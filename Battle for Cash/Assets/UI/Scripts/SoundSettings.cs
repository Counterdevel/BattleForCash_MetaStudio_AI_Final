using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundSettings : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string MusicaPref = "MusicaPref";
    private static readonly string FxPref = "FxPref";
    private int firstPlayInt;
    public Slider musicaslider, fxslider;
    private float musicafloat, fxfloat;
    public AudioSource musicaAudio;
    public AudioSource[] fxAudio;

    private void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if(firstPlayInt == 0)
        {
            musicafloat = .1f;
            fxfloat = .1f;
            musicaslider.value = musicafloat;
            fxslider.value = fxfloat;
            PlayerPrefs.SetFloat(MusicaPref, musicafloat);
            PlayerPrefs.SetFloat(FxPref, fxfloat);
            PlayerPrefs.SetInt(FirstPlay, -1);

        }
        else
        {
            musicafloat = PlayerPrefs.GetFloat(MusicaPref);
            musicaslider.value = musicafloat;
            fxfloat = PlayerPrefs.GetFloat(FxPref);
            fxslider.value = fxfloat;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(MusicaPref, musicaslider.value);
        PlayerPrefs.SetFloat(FxPref, fxslider.value);
    }

    private void OnApplicationFocus(bool infocus)
    {
        if (!infocus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        musicaAudio.volume = musicaslider.value;

        for(int i = 0; i < fxAudio.Length; i++)
        {
            fxAudio[i].volume = fxslider.value;
        }
    }
}

