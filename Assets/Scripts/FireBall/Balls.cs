using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Balls : MonoBehaviour
{
    //Ư�� �Ҳ��� ���� ��ȯ 
    private bool isDestroy = false;
    Animator animator;
    Rigidbody2D rgbd;
    HealthSystem healthSystem;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rgbd = GetComponent<Rigidbody2D>();
        healthSystem = GetComponent<HealthSystem>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isDestroy", true);
            Destroy(this.gameObject, 1f);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rgbd.constraints = RigidbodyConstraints2D.FreezePositionY;
            OnTriggerEffect(collision);
        }
    }

    protected abstract void OnTriggerEffect(Collider2D collision);

    //�÷��̾ ���� �� ü���� ��ȭ
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            healthSystem.ChangeHealth(-1);
        }
    }   
}
