using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotate : MonoBehaviour
{
    void Awake()
    {
        transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
    }
}
