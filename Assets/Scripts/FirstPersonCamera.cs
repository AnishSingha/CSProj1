using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 2f;
    [SerializeField] float maxLookUpAngle = 80f; // Maximum angle to look up
    [SerializeField] float maxLookDownAngle = 80f; // Maximum angle to look down
    [SerializeField] float maxLookrightAngle = 80f; // Maximum angle to look down
    [SerializeField] float maxLookleftAngle = 80f; // Maximum angle to look down

    private float rotationX = 0f;
    private float rotationY = 0f;

   


    void Update()
    {
        float rotLeftRight = Input.GetAxis("Mouse X");
        float rotUpDown = Input.GetAxis("Mouse Y");

        // Rotate the camera horizontally (left-right)
        transform.Rotate(Vector3.up * rotLeftRight * mouseSensitivity);

        // Calculate the new vertical rotation (up-down)
        rotationX -= rotUpDown * mouseSensitivity;
        rotationX = Mathf.Clamp(rotationX, -maxLookDownAngle, maxLookUpAngle);

        // Apply the new rotation to the camera
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        // Rotate the entire player object (left-right)
        rotationY += rotLeftRight * mouseSensitivity;
        rotationY = Mathf.Clamp(rotationY, -maxLookleftAngle, maxLookrightAngle);

        transform.parent.rotation = Quaternion.Euler(0f, rotationY, 0f);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        

    }
}
