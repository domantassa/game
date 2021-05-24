using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{

    public AudioMixer audioMixer;

    public int difficulty = 1;

    private void Awake()
    {
        //DontDestroyOnLoad(this);
        Cursor.visible = true;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetDifficulty(int difficultyIndex)
    {
        difficulty = difficultyIndex;
    }

}
