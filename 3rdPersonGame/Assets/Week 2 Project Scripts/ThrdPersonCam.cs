using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrdPersonCam : MonoBehaviour
{
    [Header("References")]
    public Transform Orientation;
    public Transform Player;
    public Transform protoPlayer;
    public Rigidbody rb;

    public float rotationSpeed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector3 viewDir = Player.position - new Vector3(transform.position.x, Player.position.y, transform.position.z);
        Orientation.forward = viewDir.normalized;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = Orientation.forward * verticalInput + Orientation.right * horizontalInput;

        if (inputDir != Vector3.zero)
            protoPlayer.forward = Vector3.Slerp(protoPlayer.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
    }
}
