using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int _speed = 2;
    private float _minDeviationX, _maxDeviationX;

    private void Start()
    {
        _minDeviationX = transform.position.x - 1.5f;
        _maxDeviationX = transform.position.x + 1.5f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            thief.MakeThiefUnderAttack();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            thief.MakeThiefNormal();
        }
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime, 0, 0);

        if (transform.position.x > (_maxDeviationX) || transform.position.x < (_minDeviationX))
        {
            _speed = -_speed;
        }
    }
}
