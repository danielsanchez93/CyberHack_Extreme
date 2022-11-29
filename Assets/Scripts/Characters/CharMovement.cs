using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    [SerializeField] float speed = 3;
    [SerializeField] bool isFlip;

    Vector2 movement;
    Rigidbody2D rb;
    Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    /// <summary>
    /// TODO
    /// Esto requiere un REFACTORING URGENTE
    /// </summary>
    public void InitializeCharacter()
    {
        if (transform.position.x < 0)
        {
            isFlip = false;
            transform.localScale = Vector3.one;
            speed = Mathf.Abs(speed);
        }
        else {
            isFlip = true;        
            transform.localScale = new Vector3(-1,1,1);
            speed = -speed;
        } 

    }

    private void FixedUpdate()
    {
        rb.velocity=(transform.right*speed);
    }
}
