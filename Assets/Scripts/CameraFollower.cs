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
        int positionX, positionY = -3, positionZ = 0;
        int minPositionX = -3;
        int maxPositionX = 8;

        System.Random rand = new System.Random();

        for (int i = 0; i < numberOfSpawns; i++)
        {
            positionX = rand.Next(minPositionX, maxPositionX);

            Vector3 point = new Vector3(positionX, positionY, positionZ);

            Instantiate(_coin, point, Quaternion.identity);
        }
    }
}
