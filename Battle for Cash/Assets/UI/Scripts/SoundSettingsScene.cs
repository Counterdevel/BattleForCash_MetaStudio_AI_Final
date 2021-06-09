using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundSettingsScene : MonoBehaviour
{
    private static readonly string MusicaPref = "MusicaPref";
    private static readonly string FxPref = "FxPref";
    private float musicafloat, fxfloat;
    public AudioSource musicaAudio;
    public AudioSource[] fxAudio;
    private void Awake()
    {
        ContinueSettings();
    }
    private void ContinueSettings()
    {
        musicafloat = PlayerPrefs.GetFloat(MusicaPref);
        fxfloat = PlayerPrefs.GetFloat(FxPref);

        musicaAudio.volume = musicafloat;

        for (int i = 0; i < fxAudio.Length; i++)
        {
            fxAudio[i].volume = fxfloat;
        }
    }
}

