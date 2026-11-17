using UnityEngine;

public class VehicleController : MonoBehaviour
{
    public Transform driverSeat; public float acceleration = 18f, maxSpeed = 22f, turnSpeed = 65f;
    Rigidbody body; Transform driver; bool occupied;
    void Awake() { body = GetComponent<Rigidbody>(); }
    public bool Enter(Transform player)
    {
        if (occupied || !player || !driverSeat) return false;
        driver = player; occupied = true; player.gameObject.SetActive(false); return true;
    }
    public void Exit()
    {
        if (!occupied) return;
        driver.position = driverSeat.position + transform.right * 2f; driver.gameObject.SetActive(true); driver = null; occupied = false;
    }
    void FixedUpdate()
    {
        if (!occupied || !body) return;
        float throttle = Input.GetAxis("Vertical"), steer = Input.GetAxis("Horizontal");
        if (body.velocity.magnitude < maxSpeed) body.AddForce(transform.forward * throttle * acceleration, ForceMode.Acceleration);
        body.MoveRotation(body.rotation * Quaternion.Euler(0, steer * turnSpeed * Time.fixedDeltaTime, 0));
        if (Input.GetKeyDown(KeyCode.F)) Exit();
    }
}
