using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Thief : MonoBehaviour
{
    [SerializeField] private int _speed;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Rigidbody2D _rigidbody;

    private Animator _animator;

    private float _jumpForce = 1.0F;
    private float _minDeviationForJump = -2.5f, _maxDeviationForJump = -2.3f;

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
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            _animator.SetTrigger("Run");
        if (Input.GetKey(KeyCode.A))
            transform.Translate(-_speed * Time.deltaTime, 0, 0);
        else if (Input.GetKey(KeyCode.D))
            transform.Translate(_speed * Time.deltaTime, 0, 0);

        if (transform.position.y > _minDeviationForJump && transform.position.y < _maxDeviationForJump && Input.GetKey(KeyCode.Space))
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
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
