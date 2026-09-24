using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 cameraOffset;

    private void Start()
    {
        cameraOffset = transform.position - player.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + cameraOffset;
    }
}
