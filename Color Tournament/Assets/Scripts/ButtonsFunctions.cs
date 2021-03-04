using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsFunctions : MonoBehaviour
{
    //SOUND CLIPS
    [Header("Sound Config")]
    private AudioSource source;
    public AudioClip OkButton;
    public AudioClip BackButton;
    public float volume_clip = 0.03f;

    //START_______________
    public void Start()
    {
        //GET AUDIO SOURCE
        source = GetComponent<AudioSource>();
    }

    private IEnumerator GoTo(int scene, float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene(scene);
    }

    public void _Menu()
    {
        source.PlayOneShot(BackButton, volume_clip);
        Time.timeScale = 1.0f;
        StartCoroutine(GoTo(0, BackButton.length));
    }

    public void _ModeSelect()
    {
        source.PlayOneShot(OkButton, volume_clip);
        StartCoroutine(GoTo(1, OkButton.length));
    }

    public void _ClassicMode()
    {
        source.PlayOneShot(OkButton, volume_clip);
        int index = UnityEngine.Random.Range(3, 9);
        StartCoroutine(GoTo(index, OkButton.length));
    }

    public void _BonusMode()
    {
        source.PlayOneShot(OkButton, volume_clip);

        //int index = UnityEngine.Random.Range(2, 6);
        //StartCoroutine(GoTo(index, OkButton.length));
    }

    public void okButtonSound()
    {
        source.PlayOneShot(OkButton, volume_clip);
    }

    public void backButtonSound()
    {
        source.PlayOneShot(BackButton, volume_clip);
    }
}