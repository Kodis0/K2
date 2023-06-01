using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    public Transform cameraTransform;
    public float rotationSpeed = 10f;

    void Update()
    {
        float y = cameraTransform.eulerAngles.y;
        float cameraRotation = y;

        Quaternion newRotation = Quaternion.Euler(transform.eulerAngles.x, cameraRotation, transform.eulerAngles.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * rotationSpeed);
    }
}
