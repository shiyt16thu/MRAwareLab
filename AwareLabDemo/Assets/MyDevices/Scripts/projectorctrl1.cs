using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;

public class projectorctrl1 : MonoBehaviour
{
    private bool proison;
    private bool audioon;
    private bool musicon;
    private float volume_separation = 0.1f;
    public AudioSource _audio;
    public MeshRenderer _mesh;
    public GameObject _screen;
    // Start is called before the first frame update
    void Start()
    {
        proison = false;
        audioon = false;
        musicon = false;
        _audio = GetComponent<AudioSource>();
        _audio.enabled = false;
        _audio.spatialBlend = 1.0f;
        _audio.volume = 0.5f;
        _mesh = GetComponent<MeshRenderer>();
        _mesh.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_screen.GetComponent<projectorctrl>().openover)
        {
            proison = true;
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (proison && audioon)
            {
                turnonoroff();
                proison = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            turnonoroff();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            audioplayorpause();
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            volumeup();
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            volumedown();
        }
    }
    public void turnonoroff()
    {
        if (!proison)
        {
            return;
        }
        else
        {
            if (audioon)
            {
                _mesh.enabled = false;
                _audio.enabled = false;
                musicon = false;
            }
            else
            {
                _mesh.enabled = true;
                _audio.enabled = true;
                musicon = true;
            }
            audioon ^= true;
        }
    }
    public void audioplayorpause() //音乐暂停或播放
    {
        if (proison && audioon)
        {
            if (musicon)
            {
                _audio.Pause();
                musicon = false;
            }
            else
            {
                _audio.Play();
                musicon = true;
            }
        }
    }
    public void volumeup() //音量增大
    {
        if (musicon && _audio.volume < 1)
        {
            _audio.volume += volume_separation;
        }
    }
    public void volumedown() //音量减小
    {
        if (musicon && _audio.volume != 0)
        {
            if (_audio.volume >= volume_separation)
            {
                _audio.volume -= volume_separation;
            }
            else
            {
                _audio.volume = 0;
            }
        }
    }
}
