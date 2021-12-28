using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaleMovement : MonoBehaviour
{
    public float move_Speed = 1f;
    public float bound_Y = 6f;

    private void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 temp = transform.position;
        temp.y -= move_Speed * Time.deltaTime;
        transform.position = temp;

        if (temp.y >= bound_Y)
        {
            gameObject.SetActive(false);
        }
    }
}
