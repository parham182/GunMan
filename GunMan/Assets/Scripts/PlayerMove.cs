using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;

    Rigidbody rb;
    CameraMovement cameraMovement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraMovement = FindAnyObjectByType<CameraMovement>();
    }

    void FixedUpdate()
    {
        PlayerRotate();
        PlayerMovePhysics();
    }

    void PlayerMovePhysics()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // MOVE IN LOCAL SPACE
        Vector3 moveDir = transform.forward * v + transform.right * h;
        Vector3 velocity = moveDir * movementSpeed;

        rb.linearVelocity = new Vector3(
            velocity.x,
            rb.linearVelocity.y,
            velocity.z
        );
    }

    void PlayerRotate()
    {
        transform.rotation = Quaternion.Euler(
            0f,
            cameraMovement.yRotation,
            0f
        );
    }
}

