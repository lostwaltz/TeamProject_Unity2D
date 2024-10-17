using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void callEasyMainScene()
    {
        LevelManager.isEasy=true;
        SceneManager.LoadScene("MainScene");
    }
    public void callNolamlMainScene()
    {
        LevelManager.isNormal=true;
        SceneManager.LoadScene("MainScene");
    }
    public void callHardMainScene()
    {
        LevelManager.isHard=true;
        SceneManager.LoadScene("MainScene");
    }
    public void callTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
