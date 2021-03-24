using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int _speed = 2;
    private float _defaultX;

    private void Start()
    {
        _defaultX = transform.position.x;
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

        if (transform.position.x > (_defaultX + 1.5) || transform.position.x < (_defaultX - 1.5))
        {
            _speed = -_speed;
        }
    }
}
