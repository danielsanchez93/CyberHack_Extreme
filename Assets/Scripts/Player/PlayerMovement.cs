using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool isFlip;

    Vector2 movement;
    Rigidbody2D rb;
    Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.velocity = speed * movement;
        animator.SetFloat("vel",Mathf.Abs(movement.magnitude));

        #region Inverted
        if (rb.velocity.x > 0)
        {
            isFlip = false;
        }
        else if (rb.velocity.x < 0)
        {
            isFlip = true;
        }
        GetComponent<SpriteRenderer>().flipX = isFlip;
        #endregion
    }
}
