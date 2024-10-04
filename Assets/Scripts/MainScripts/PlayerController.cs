using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject ViewCamera = null;
    public AudioClip CoinSound = null;
    public float moveSpeed = 5f;  // Movement speed
    public float rotationSpeed = 10f;  // Speed of rotation

    private Rigidbody mRigidBody = null;
    private AudioSource mAudioSource = null;

    void Start()
    {
        mRigidBody = GetComponent<Rigidbody>();
        mAudioSource = GetComponent<AudioSource>();
        mRigidBody.freezeRotation = true;  // Prevent the character from rotating due to physics
    }

    void FixedUpdate()
    {
        MovementHandler();
        CameraHandler();
    }

    private void MovementHandler()
    {
        // Get movement input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        if (movement.magnitude > 0.1f)
        {
            // Move the character smoothly
            transform.position += movement * moveSpeed * Time.deltaTime;

            // Rotate the character to face the movement direction smoothly
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void CameraHandler()
    {
        if (ViewCamera != null)
        {
            Vector3 direction = (Vector3.up * 2 + Vector3.back) * 2;
            RaycastHit hit;
            Debug.DrawLine(transform.position, transform.position + direction, Color.red);
            if (Physics.Linecast(transform.position, transform.position + direction, out hit))
            {
                ViewCamera.transform.position = hit.point;
            }
            else
            {
                ViewCamera.transform.position = transform.position + direction;
            }
            ViewCamera.transform.LookAt(transform.position);
        }
    }
}
