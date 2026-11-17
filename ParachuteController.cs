using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ParachuteController : MonoBehaviour
{
    public float descentSpeed = 5f, steerSpeed = 5f; public GameObject parachuteVisual;
    CharacterController controller; bool descending;
    void Awake() { controller = GetComponent<CharacterController>(); }
    public void BeginDrop() { descending = true; if (parachuteVisual) parachuteVisual.SetActive(true); }
    void Update()
    {
        if (!descending) return;
        Vector3 steer = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 move = transform.TransformDirection(steer) * steerSpeed; move.y = -descentSpeed;
        controller.Move(move * Time.deltaTime);
        if (controller.isGrounded) { descending = false; if (parachuteVisual) parachuteVisual.SetActive(false); }
    }
}
