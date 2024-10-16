using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject fireBall;
    [SerializeField] private float speed = 0.05f;

    void Start()
    {
        InvokeRepeating("MakeFireBall", 0.5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void MakeFireBall()
    {
        GameObject go = Instantiate(fireBall, transform);
        float x = Random.Range(-8.5f, 8.5f);
        float y = 5.6f;
        go.transform.position = new Vector2(x, y);
        go.transform.position += Vector3.down * speed;
    }
}
