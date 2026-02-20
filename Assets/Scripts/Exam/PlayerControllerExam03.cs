using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerExam03 : MonoBehaviour
{
    public float speed;
    public float xRange = 10;
    public GameObject projectilePrefab;

    public bool enableAutoFireMode;
    public float autoFireInterval = 0.1f;

    private float horizontalInput;
    private InputAction moveAction;
    private InputAction shootAction;
    private InputAction enableAutoFire;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
        enableAutoFire = InputSystem.actions.FindAction("EnableAutoFire");
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (shootAction.triggered)
        {
            Shoot();
        }
        if (enableAutoFire.triggered)
        {
            Debug.Log("enabled");
            Debug.Log(enableAutoFireMode);
            InvokeRepeating(nameof(Shoot), autoFireInterval, autoFireInterval);
            enableAutoFireMode = !enableAutoFireMode;
        }
        if (enableAutoFire.triggered && enableAutoFireMode)
        {
            Debug.Log("disabled");
            CancelInvoke();
        }
    }

    private void Shoot()
    {
        Instantiate(projectilePrefab, transform.position, transform.rotation);
    }
}
