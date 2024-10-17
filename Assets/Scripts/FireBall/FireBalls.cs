using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireBalls : MonoBehaviour
{
    //특수 불꽃의 몬스터 소환 
    private bool isDestroy = false;
    Animator animator;
    Rigidbody2D rgbd;
    HealthSystem healthSystem;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rgbd = GetComponent<Rigidbody2D>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isDestroy", true);
            Destroy(this.gameObject, 1f);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rgbd.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }

    //플레이어가 맞을 때 체력의 변화
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            healthSystem.ChangeHealth(-1);
        }
    }   
}
