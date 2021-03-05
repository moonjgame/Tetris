using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManger : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip click;
    public AudioClip drop;
    public AudioClip clear;
    public AudioClip move;
    public AudioClip rotate;
    public Controller controller;



    private void Awake()
    {
        controller = GetComponent<Controller>();
    }
    public void PlayAudio(AudioClip clip)
    {
        if (controller.model.IsMute == 1) return;
        audioSource.clip = clip;
        audioSource.Play();
    }


    public void PlayMoveAudio()
    {
        PlayAudio(move);
    }

    public void PlayRotateAudio()
    {
        PlayAudio(rotate);
    }
    public void PlayClearLineAudio()
    {
        PlayAudio(clear);
    }
    public void PlayButtonClickAudio()
    {
        PlayAudio(click);
    }
    public void PlayDropAudio()
    {
        PlayAudio(drop);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
