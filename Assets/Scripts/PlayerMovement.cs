using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Vector2 jumpVector;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private const string JumpButtonName = "Jump";
    private const string HorizontalAxisName = "Horizontal";
    private const string IsRunningParameterName = "IsRunning";

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        jumpVector = new Vector2(0, jumpForce);
    }

    // Update is called once per frame
    void Update()
    {
        var directionX = Input.GetAxisRaw(HorizontalAxisName);

        rigidBody.velocity = new Vector2(directionX * moveSpeed, rigidBody.velocity.y);

        if (Input.GetButtonDown(JumpButtonName))
        {
            rigidBody.velocity = jumpVector;
        }

        UpdateAnimationState(directionX);
    }

    private void UpdateAnimationState(float directionX)
    {
        if (directionX > 0f)
        {
            spriteRenderer.flipX = false;
            animator.SetBool(IsRunningParameterName, true);
        }
        else if (directionX < 0f)
        {
            spriteRenderer.flipX = true;
            animator.SetBool(IsRunningParameterName, true);
        }
        else
        {
            animator.SetBool(IsRunningParameterName, false);
        }
    }
}
