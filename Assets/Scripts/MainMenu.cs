using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;

    private void Start()
    {
        Cursor.visible = true;
    }
    public void PlayLevel1()
    {
        SceneManager.LoadScene("GameLevel1");
    }
    public void PlayLevel2()
    {
        SceneManager.LoadScene("GameLevel2");
    }
    public void PlayLevel3()
    {
        SceneManager.LoadScene("GameLevel3");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("Music", volume);
    }
    public void SetFXVolume(float volume)
    {
        audioMixer.SetFloat("FX", volume);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}