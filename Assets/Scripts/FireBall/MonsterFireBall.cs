using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFireBall : Balls
{
    [SerializeField] GameObject[] monsterPrefabs;

    Collider2D collider;

    private void Awake()
    {
        base.Awake();
        collider = GetComponent<Collider2D>(); 
    } 

    protected override void OnTriggerEffect(Collider2D collision)
    {
        Vector3 collisionPoint = new Vector3 (gameObject.transform.position.x, collision.transform.position.y, collision.transform.position.z);
        
        int randomMonster = Random.Range(0, monsterPrefabs.Length);
        Instantiate(monsterPrefabs[randomMonster], collisionPoint,Quaternion.identity);
        Debug.LogError(collisionPoint);
    }
}
