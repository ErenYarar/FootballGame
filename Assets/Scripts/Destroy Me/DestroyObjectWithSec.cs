using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectWithSec : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "isGrounded")
        {
            Destroy(gameObject, 10f);
        }
    }
}
