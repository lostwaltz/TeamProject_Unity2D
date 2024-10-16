using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBalls : MonoBehaviour
{
    private bool isDestroy = false;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Destroy(this.gameObject, 1f);
            animator.SetBool("isDestroy", true);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
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
