using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFireBall : Balls
{
    [SerializeField] GameObject[] monsterPrefabs;

    Collider2D collider;
    HealthSystem healthSystem;

    private void Awake()
    {
        base.Awake();
        collider = GetComponent<Collider2D>(); 
    } 

    protected override void OnTriggerEffect(Collider2D collision)
    {
        Vector3 collisionPoint = collision.transform.position;

        int randomMonster = Random.Range(0, monsterPrefabs.Length);
        Instantiate(monsterPrefabs[randomMonster], collisionPoint, Quaternion.identity);
    }
}
