using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

   
    private void Start()
    {
        List<string> options = new List<string>();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }





}
    