using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSound : MonoBehaviour
{
    public GameObject[] yourPanels; // Tus paneles
    public AudioSource[] yourAudioSources; // Tus fuentes de audio

    void Update()
    {
        for (int i = 0; i < yourPanels.Length; i++)
        {
            if (yourPanels[i].activeSelf && !yourAudioSources[i].isPlaying)
            {
                yourAudioSources[i].Play();
            }
            else if (!yourPanels[i].activeSelf && yourAudioSources[i].isPlaying)
            {
                yourAudioSources[i].Stop();
            }
        }
    }
}
