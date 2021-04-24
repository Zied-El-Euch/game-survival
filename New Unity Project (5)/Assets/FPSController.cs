using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 5f;
    [SerializeField] CapsuleCollider col;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float gravity = -9.8f;
    public GameObject WinPanel;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
            // Get input from Arrow keys or WASD
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            // Calculate the Direction
            Vector3 direction = transform.right * x + transform.forward * y;

            Vector3 movement = direction.normalized * speed * Time.deltaTime;

            // Move the rigidbody to the new position 
            rb.MovePosition(rb.position + movement);

            // Make sure the player isn't spinning crazily when hitting an object
            rb.angularVelocity = Vector3.zero;
            if (Input.GetKeyDown(KeyCode.Space) && groundCheck())
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }

    }
    bool groundCheck()
    {
        return Physics.CheckCapsule(
        col.bounds.center,
        new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z),
        col.radius * 0.9f,
        groundLayer
        );
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Exit" && Equip.Instance.hasBawly)
        {
            Debug.Log("Bawly");
            Time.timeScale = 0;
            WinPanel.SetActive(true);
        }
    }
}