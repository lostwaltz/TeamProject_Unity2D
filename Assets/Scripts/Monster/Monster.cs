using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float MonsterSpeed;
    HealthSystem healthSystem;
    Rigidbody2D rgbd;
    float randomMove;
    SpriteRenderer spriteRenderer;
    Animator animator;
    Collider2D collider;

    private void Awake()
    {
        rgbd = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
        collider = GetComponentInChildren<Collider2D>();
        Invoke("RandomMove", 3);
    }

    //처리로직
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (transform.position.y < collision.transform.position.y)
            {
                MonsterDamaged();
                return;
            }
            collision.gameObject.GetComponent<HealthSystem>().ChangeHealth(-1f);
        }
    }

    //몬스터 움직임
    private void RandomMove()
    {
        randomMove = Random.Range(-1, 2);
        Invoke("RandomMove", 3);
        if(randomMove > 0)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("isRun",true);
        }
        if(randomMove == 0)
        {
            animator.SetBool("isRun", false);
        }
        if (randomMove < 0)
        {
            spriteRenderer.flipX=false;
            animator.SetBool("isRun", true);
        }
    }

    private void FixedUpdate()
    {
        rgbd.velocity = new Vector2(randomMove * MonsterSpeed, 0);
    }

    //사망로직
    public void MonsterDamaged()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        spriteRenderer.flipY = true;
        collider.enabled = false;
        rgbd.AddForce(Vector2.up * 5,ForceMode2D.Impulse);
        Destroy(gameObject,5);
        rgbd.constraints = RigidbodyConstraints2D.FreezePositionX;
    }
}
