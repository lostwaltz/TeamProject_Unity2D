using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float MonsterSpeed;
    Collider2D collider;
    HealthSystem healthSystem;
    Rigidbody2D rgbd;
    float randomMove;
    SpriteRenderer spriteRenderer;
    Animator animator;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        rgbd = GetComponent<Rigidbody2D>();
        healthSystem = GetComponent<HealthSystem>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();    
        Invoke("RandomMove", 3);
    }

    //피격시 플레이어 체력감소
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collider.CompareTag("Player"))
        {
            healthSystem.ChangeHealth(-1f);

            if (collision.rigidbody.velocity.y < 0f && transform.position.y < collision.transform.position.y)
            {
                MonsterDamaged();
            }
        }
    }

    //몬스터 AI 구현 랜덤한 좌우 움직임 플레이어에게 향하게 되면 너무 어려워질 듯
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

    //랜덤 움직임을 구현한 것을 속도로 적용시킴
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
    }
}
