using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SettingsMenu : MonoBehaviour
{

   
    private void Start()
    {
        List<string> options = new List<string>();
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }





}
    