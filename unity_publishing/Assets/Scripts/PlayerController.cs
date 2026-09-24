using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;

    private int score = 0;
    private Rigidbody playerRigidbody;
    private Vector3 movementInput;

    public int health = 5;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            health = 5;
            score = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        movementInput = new Vector3(horizontalInput, 0f, verticalInput);
        movementInput = Vector3.ClampMagnitude(movementInput, 1f);
    }

    private void FixedUpdate()
    {
        playerRigidbody.AddForce(movementInput * movementSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            Debug.Log("You win!");
            return;
        }

        if (other.CompareTag("Trap"))
        {
            health--;
            Debug.Log($"Health: {health}");
            return;
        }

        if (!other.CompareTag("Pickup"))
        {
            return;
        }

        score++;
        Debug.Log($"Score: {score}");
        Destroy(other.gameObject);
    }
}
