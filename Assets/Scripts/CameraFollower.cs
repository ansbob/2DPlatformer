using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Coin _coin;

    private void Start()
    {
        int numberOfSpawns = 10;
        int positionX;

        System.Random rand = new System.Random();

        for (int i = 0; i < numberOfSpawns; i++)
        {
            positionX = rand.Next(-3, 8);

            Vector3 point = new Vector3(positionX, -3, 0);

            Instantiate(_coin, point, Quaternion.identity);
        }
    }
}
