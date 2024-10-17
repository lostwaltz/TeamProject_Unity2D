using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioClip clip;

    public AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
