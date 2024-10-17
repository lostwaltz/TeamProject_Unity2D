using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GamaManager : MonoBehaviour
{
    [SerializeField] private GameObject easyBG;
    [SerializeField] private GameObject normalBG;
    [SerializeField] private GameObject hardBG;

    void Start()
    {
        BackGroundChanger();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BackGroundChanger()
    {
        if (LevelManager.isEasy==true)
        {
            easyBG.SetActive(true);
            normalBG.SetActive(false);
            hardBG.SetActive(false);
        }else if (LevelManager.isNormal==true)
        {
            easyBG.SetActive(false);
            normalBG.SetActive(true);
            hardBG.SetActive(false);
        }else if (LevelManager.isHard==true)
        {
            easyBG.SetActive(false);
            normalBG.SetActive(false);
            hardBG.SetActive(true);
        }
    }
}
