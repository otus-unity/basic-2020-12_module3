using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Collider2D _collider2D;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    public LayerMask ground;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
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
            // LayerMask.NameToLayer("Default") = 0
            // LayerMask.GetMask("Default") = 1             // 000000001   // (1 << index)

            // LayerMask.NameToLayer("TransparentFX") = 1
            // LayerMask.GetMask("TransparentFX") = 2       // 000000010   // (1 << index)

            int layer = LayerMask.NameToLayer("Player");
            int mask = Physics2D.GetLayerCollisionMask(layer);
            mask |= LayerMask.GetMask("Crate");
            // mask &= ~LayerMask.GetMask("Crate");   // remove bit
            Physics2D.SetLayerCollisionMask(layer, mask);

            Destroy(other.gameObject);
        }
    }
}
