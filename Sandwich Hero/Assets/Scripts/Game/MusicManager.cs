using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour
{

    public AudioClip pop;
    public AudioClip cheese;
    public AudioClip meat;
    public AudioClip dressing;
    public AudioClip veggie;

    private List<Beat> _beats;

    private List<List<Beat>> _pastBeats;

    public float beatTimer;

    private bool _active;

    // Use this for initialization
    void Start()
    {
        _beats = new List<Beat>();
        _pastBeats = new List<List<Beat>>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log (_beats.Count);
        if (!Game.Paused)
        {
            for (int i = 0; i < _beats.Count; i++)
            {
                _beats[i].waitTime += Time.deltaTime;
                if (_beats[i].waitTime >= beatTimer)
                {
                    PlaySound(_beats[i].clip);
                    _beats[i].waitTime = 0;
                }
            }
        }
    }

    public void ToggleBaseBeat(AudioClip audio)
    {
        gameObject.GetComponent<AudioSource>().clip = audio;
        if (gameObject.GetComponent<AudioSource>().isPlaying)
        {
            gameObject.GetComponent<AudioSource>().Stop();
            _pastBeats.Add(_beats);
            _beats.Clear();
            _active = false;
        }
        else
        {
            gameObject.GetComponent<AudioSource>().Play();
            _active = true;
        }
    }

    public void AddBeat(AudioClip sound, float time)
    {
        Beat beat = new Beat(sound, time);
        _beats.Add(beat);
    }

    public void PlaySound(AudioClip sound)
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(sound);
    }

    public void Pause()
    {
        if (_active)
            gameObject.GetComponent<AudioSource>().Pause();
    }

    public void Play()
    {
        if (_active)
            gameObject.GetComponent<AudioSource>().Play();
    }
}
