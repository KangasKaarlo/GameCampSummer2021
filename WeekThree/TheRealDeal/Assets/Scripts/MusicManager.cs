using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    static MusicManager instance;
    public GameObject music;
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            music.GetComponent<AudioSource>().Play();
            DontDestroyOnLoad(music);
        }
        else
        {
            if (this != instance)
                Destroy(this.gameObject);
        }
    }
}