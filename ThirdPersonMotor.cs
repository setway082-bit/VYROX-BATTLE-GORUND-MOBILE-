using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ThirdPersonMotor : MonoBehaviour
{
    public Transform cameraTransform;
    public float walkSpeed = 4.5f, sprintSpeed = 7f, crouchSpeed = 2.2f;
    public float jumpHeight = 1.4f, gravity = -22f, turnSmoothTime = 0.12f;
    CharacterController controller; Vector3 verticalVelocity; float turnVelocity; bool crouching;

    void Awake() { controller = GetComponent<CharacterController>(); }
    void Update()
    {
        if (!cameraTransform) return;
        float x = Input.GetAxisRaw("Horizontal"), z = Input.GetAxisRaw("Vertical");
        Vector3 input = new Vector3(x, 0, z).normalized;
        bool sprint = Input.GetKey(KeyCode.LeftShift) && !crouching;
        float speed = crouching ? crouchSpeed : sprint ? sprintSpeed : walkSpeed;
        if (input.sqrMagnitude > 0.01f)
        {
            float targetAngle = Mathf.Atan2(input.x, input.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);
            Vector3 move = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            controller.Move(move.normalized * speed * Time.deltaTime);
        }
        if (controller.isGrounded && verticalVelocity.y < 0) verticalVelocity.y = -2f;
        if (controller.isGrounded && Input.GetButtonDown("Jump")) verticalVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        if (Input.GetKeyDown(KeyCode.C)) SetCrouch(!crouching);
        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);
    }
    void SetCrouch(bool value) { crouching = value; controller.height = value ? 1.15f : 1.9f; }
}
