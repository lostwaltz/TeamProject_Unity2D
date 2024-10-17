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

    private float smallFireBall_Spawn_Speed = 1f;
    private float fireball_Spewn_Speed = 0.8f;
    private float monsterFireBall_Spewn_Spawn_Speed = 0.5f;

    public static bool isEasy = false;
    public static bool isNormal = false;
    public static bool isHard = false;

    private float levelUp_Time = 10f;
    private float time = 0;

    private void Awake()
    {
        Debug.Log(isEasy);
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

        }
        else if (isHard)
        {

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
            Debug.Log(time);
            if (time > levelUp_Time)
            {
                MakeSmallFireBall();
                MakeFireBall();
            }

            if (time > 15)
            {
                MakeSmallFireBall();
                MakeFireBall();
                smallFireBall_Spawn_Speed = smallFireBall_Spawn_Speed / 2f;
                time = 0;
            }
            yield return new WaitForSeconds(smallFireBall_Spawn_Speed);
        }
    }
}
