using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform followTarget;
    [SerializeField] float distance = 5f;
    [SerializeField] float minVerticalAngle = -45f, maxVerticalAngle = 45f;
    //[SerializeField] float minHorizontalAngle = -45f, maxHorizontalAngle = 45f;
    [SerializeField] Vector2 framingOffset;
    [SerializeField] float rotationSpeed = 2f;
    [SerializeField] bool invertX, invertY;

    float rotationX, rotationY, invertXVal, invertYVal;
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        invertXVal = (invertX) ? -1 : 1;
        invertYVal = (invertY) ? -1 : 1;

        rotationX += Input.GetAxis("Mouse Y") * rotationSpeed * invertYVal;
        rotationX = Mathf.Clamp(rotationX, minVerticalAngle, maxVerticalAngle);

        rotationY += Input.GetAxis("Mouse X") * rotationSpeed * invertXVal;
        //rotationY = Mathf.Clamp(rotationY, minHorizontalAngle, maxHorizontalAngle);

        var targetRotation = Quaternion.Euler(rotationX, rotationY, 0);
        var foxusPosition = followTarget.position + new Vector3(framingOffset.x, framingOffset.y);

        transform.position = foxusPosition - targetRotation * new Vector3(0, 0, distance);
        transform.rotation = targetRotation;
    }

    public Quaternion PlanarRotation => Quaternion.Euler(0, rotationY, 0);
}