using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void callMainScene()
    {
        LevelManager.isEasy=true;
        SceneManager.LoadScene("MainScene");
    }
}
