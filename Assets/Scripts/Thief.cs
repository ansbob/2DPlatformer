using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private int _speed;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Rigidbody2D _rigidbody;

    private Animator _animator;

    private float _jumpForce = 1.0F;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _animator.SetTrigger("Run");

            transform.Translate(-_speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _animator.SetTrigger("Run");

            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }
        if (transform.position.y > -2.5f && transform.position.y < -2.3 && Input.GetKey(KeyCode.Space))
        {
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    public void MakeThiefUnderAttack()
    {
        _spriteRenderer.color = Color.red;
    }

    public void MakeThiefNormal()
    {
        _spriteRenderer.color = Color.white;
    }
}
