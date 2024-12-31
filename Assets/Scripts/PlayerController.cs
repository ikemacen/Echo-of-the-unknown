using TMPro.Examples;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f, rotationSpeed = 500f;
    CameraController cameraController;
    Animator animator;
    Quaternion targetRotation;
    private void Awake()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
        animator = GetComponent<Animator>();

    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal"), v = Input.GetAxis("Vertical");
        float moveAmount = Mathf.Clamp01(Mathf.Abs(h) + Mathf.Abs(v));

        var moveInput = (new Vector3(h, 0, v)).normalized;
        var moveDir = cameraController.PlanarRotation * moveInput;

        if(moveAmount > 0)
        {
            transform.position += moveDir * moveSpeed * Time.deltaTime;
            targetRotation = Quaternion.LookRotation(moveDir);
        }
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 
            rotationSpeed * Time.deltaTime);
        animator.SetFloat("Blend", moveAmount);
    }
}