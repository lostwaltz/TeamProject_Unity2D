using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private GameObject fireBall;
    [SerializeField] private GameObject smallFireBall;
    [SerializeField] private GameObject monsterFireBall;

    [SerializeField] private float fireBall_Speed = 0.1f;
    [SerializeField] private float smallFireBall_Speed = 0.05f;
    [SerializeField] private float monsterFireBall_Speed = 1f;

    private float esay_Spawn_Speed = 1f;
    private float normal_Spewn_Speed = 0.8f;
    private float hard_Spewn_Spawn_Speed = 0.5f;

    private bool isEasy = true;
    private bool isNormal = false;
    private bool isHard = false;

    private float first_LevelUp_Time = 15f;
    private float Second_LevelUp_Time = 30f;
    private float time = 0;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
       
    }

    void Start()
    {
        LevelFireSpawn();

        //InvokeRepeating("MakeFireBall", 0.5f, 1f);
        //InvokeRepeating("MakeSmallFireBall", 0.5f, 1f);
        //InvokeRepeating("MakeMonsterFireBall", 0.5f, 1f);
    }

    private void Update()
    {
        time += Time.deltaTime;
    }

    private void LevelFireSpawn()
    {
        if (isEasy)
        {
            StartCoroutine(EasyLevel());
        }
        else if (isNormal)
        {
            StartCoroutine(NromalLevel());
        }
        else if (isHard)
        {
            StartCoroutine(HardLevel());
        }
    }

    void MakeFireBall()
    {
        GameObject go = Instantiate(fireBall, transform);
        float x = Random.Range(-8.5f, 8.5f);
        float y = 5.6f;
        go.transform.position = new Vector2(x, y);
        go.transform.position += Vector3.down * fireBall_Speed;
    }

    void MakeSmallFireBall()
    {
        GameObject go = Instantiate(smallFireBall, transform);
        float x = Random.Range(-8.5f, 8.5f);
        float y = 5.6f;
        go.transform.position = new Vector2(x, y);
        go.transform.position += Vector3.down * smallFireBall_Speed;
    }

    void MakeMonsterFireBall()
    {
        GameObject go = Instantiate(monsterFireBall, transform);
        float x = Random.Range(-8.5f, 8.5f);
        float y = 5.6f;
        go.transform.position = new Vector2(x, y);
        go.transform.position += Vector3.down * monsterFireBall_Speed;
    }

    IEnumerator EasyLevel()
    {
        while (isEasy)
        {
            MakeSmallFireBall();

            if (time > first_LevelUp_Time)
            {
                MakeSmallFireBall();
                MakeFireBall();
            }

            if (time > Second_LevelUp_Time)
            {
                MakeSmallFireBall();
                MakeFireBall();
                esay_Spawn_Speed = esay_Spawn_Speed / 2f;
                if (esay_Spawn_Speed <= 0.25f)
                {
                    esay_Spawn_Speed = 0.25f;
                }
                time = 0;
            }
            yield return new WaitForSeconds(esay_Spawn_Speed);
        }
    }

    IEnumerator NromalLevel()
    {
        while (isNormal)
        {
            MakeSmallFireBall();
            MakeFireBall();

            if (time > first_LevelUp_Time)
            {
                MakeSmallFireBall();
                MakeFireBall();
            }

            if (time > Second_LevelUp_Time)
            {
                MakeSmallFireBall();
                MakeFireBall();
                MakeMonsterFireBall();
                normal_Spewn_Speed = normal_Spewn_Speed / 2f;
                if (normal_Spewn_Speed <= 0.2f)
                {
                    normal_Spewn_Speed = 0.2f;
                }
                time = 0;
            }
            yield return new WaitForSeconds(normal_Spewn_Speed);
        }
    }

    IEnumerator HardLevel()
    {
        while (isHard)
        {
            MakeSmallFireBall();
            MakeFireBall();

            if (time > first_LevelUp_Time)
            {
                MakeSmallFireBall();
                MakeFireBall();
                MakeMonsterFireBall();
            }

            if (time > Second_LevelUp_Time)
            {
                MakeSmallFireBall();
                MakeFireBall();
                MakeMonsterFireBall();
                hard_Spewn_Spawn_Speed = hard_Spewn_Spawn_Speed / 2f;
                if (hard_Spewn_Spawn_Speed <= 0.125f)
                {
                    hard_Spewn_Spawn_Speed = 0.125f;
                }
                time = 0;
            }
            yield return new WaitForSeconds(hard_Spewn_Spawn_Speed);
        }
    }
}
