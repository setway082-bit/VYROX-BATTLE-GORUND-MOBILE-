using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; public Vector3 offset = new Vector3(0, 2.2f, -4.5f);
    public float sensitivity = 3f, followSmooth = 12f, minPitch = -25f, maxPitch = 65f;
    float yaw, pitch = 12f;
    void Start() { if (target) yaw = target.eulerAngles.y; Cursor.lockState = CursorLockMode.Locked; }
    void LateUpdate()
    {
        if (!target) return;
        yaw += Input.GetAxis("Mouse X") * sensitivity;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity; pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 desired = target.position + rotation * offset;
        transform.position = Vector3.Lerp(transform.position, desired, followSmooth * Time.deltaTime);
        transform.rotation = rotation;
    }
}
