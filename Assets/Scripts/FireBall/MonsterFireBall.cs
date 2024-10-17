using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFireBall : FireBalls
{
    [SerializeField] GameObject[] monsterPrefabs;

    Collider2D collider;
    Animator animator;
    Rigidbody2D rgbd;

    private void Awake()
    {
        base.Awake();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {         
            int randomMonster = Random.Range(0, monsterPrefabs.Length);
            Instantiate(monsterPrefabs[randomMonster]);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
