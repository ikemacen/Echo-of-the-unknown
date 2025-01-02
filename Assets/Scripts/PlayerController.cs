using TMPro.Examples;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f, rotationSpeed = 500f;
    [SerializeField] float groundCheckRadius = 0.2f;
    [SerializeField] Vector3 groundCheckOffset;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float jumpHeight = 2f;
    [SerializeField] float gravity = -9.81f;

    CameraController cameraController;
    Animator animator;
    Quaternion targetRotation;
    CharacterController characterController;
    bool isGrounded;
    float velocityY;

    private void Awake()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal"), v = Input.GetAxis("Vertical");
        float moveAmount = Mathf.Clamp01(Mathf.Abs(h) + Mathf.Abs(v));

        var moveInput = (new Vector3(h, 0, v)).normalized;
        var moveDir = cameraController.PlanarRotation * moveInput;
        GroundCheck();
        Debug.Log("isGrounded = " + isGrounded);

        if (moveAmount > 0)
        {
            characterController.Move(moveDir * moveSpeed * Time.deltaTime);
            targetRotation = Quaternion.LookRotation(moveDir);
        }

        /*
        if (isGrounded && velocityY < 0)
        {
            velocityY = -2f;
        }
        */
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocityY = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity
        velocityY += gravity * Time.deltaTime;

        // Apply movement (including gravity)
        characterController.Move(new Vector3(0, velocityY, 0) * Time.deltaTime);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation,
            rotationSpeed * Time.deltaTime);
        animator.SetFloat("Blend", moveAmount);
    }

    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(transform.TransformPoint(groundCheckOffset), groundCheckRadius, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.TransformPoint(groundCheckOffset), groundCheckRadius);
    }
}
