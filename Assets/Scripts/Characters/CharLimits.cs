using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharLimits : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Limits"))
        {
            FindObjectOfType<CharPooler>().ResetChar(gameObject);
        }
    }
}
