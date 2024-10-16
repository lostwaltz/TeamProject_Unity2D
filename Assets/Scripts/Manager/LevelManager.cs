using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject fireBall;
    [SerializeField] private GameObject smallFireBall;
    [SerializeField] private GameObject monsterFireBall;

    [SerializeField] private float fireBall_Speed = 0.1f;
    [SerializeField] private float smallFireBall_Speed = 0.05f;
    [SerializeField] private float monsterFireBall_Speed = 1f;

    private bool isEasy = true;
    private bool isNormal = false;
    private bool isHard = false;

    private float time = 0;

    void Start()
    {
        LevelFireSpawn();

        //InvokeRepeating("MakeFireBall", 0.5f, 1f);
        //InvokeRepeating("MakeSmallFireBall", 0.5f, 1f);
        //InvokeRepeating("MakeMonsterFireBall", 0.5f, 1f);
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
            time += 1;
            MakeSmallFireBall();
            Debug.Log(time);
            if (time > 10)
            {
                MakeFireBall();
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
