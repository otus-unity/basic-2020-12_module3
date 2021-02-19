using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Collider2D _collider2D;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    public LayerMask ground;
    
    // Start is called before the first frame update
    void Start()
    {
        _collider2D = GetComponent<Collider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float hDirection = Input.GetAxis("Horizontal");

        if (hDirection < 0.0f)
        {
            _rigidbody2D.velocity = new Vector2(-5, _rigidbody2D.velocity.y);
            _spriteRenderer.flipX = true;
            _animator.SetBool("running", true);
        } 
        else if (hDirection > 0.0f)
        {
            _rigidbody2D.velocity = new Vector2(5, _rigidbody2D.velocity.y);
            _spriteRenderer.flipX = false;
            _animator.SetBool("running", true);
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
            _animator.SetBool("running", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _collider2D.IsTouchingLayers(ground))
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 5);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bonus"))
        {
            Destroy(other.gameObject);
        }
    }
}
