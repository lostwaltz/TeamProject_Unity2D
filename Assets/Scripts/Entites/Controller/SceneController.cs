using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField] AudioClip easyClip;
    [SerializeField] AudioClip normalClip;
    [SerializeField] AudioClip hardClip;
    [SerializeField] AudioClip button_Click_Clip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void callEasyMainScene()
    {
        StartCoroutine(ButtonSound());
    }
    public void callNolamlMainScene()
    {
        LevelManager.isNormal=true;
        AudioManager.instance.audioSource.clip = normalClip;
        AudioManager.instance.audioSource.Play();
        SceneManager.LoadScene("MainScene");
    }
    public void callHardMainScene()
    {
        LevelManager.isHard=true;
        AudioManager.instance.audioSource.clip = hardClip;
        AudioManager.instance.audioSource.Play();
        SceneManager.LoadScene("MainScene");
    }
    public void callTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

    IEnumerator ButtonSound()
    {
        audioSource.PlayOneShot(button_Click_Clip);
        yield return new WaitForSeconds(audioSource.clip.length);
        LevelManager.isEasy = true;
        AudioManager.instance.audioSource.clip = easyClip;
        AudioManager.instance.audioSource.Play();
        SceneManager.LoadScene("MainScene");
    }
}
