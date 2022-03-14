using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollider : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.tag == "finger")
        {
            Debug.Log("ddd");
        }
    }
}
