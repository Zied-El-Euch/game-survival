using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zombie : MonoBehaviour
{
    Vector3 direction;
    Transform playerTransform;
    Rigidbody rb;
    Animator animator;
    public GameObject WinPanel;
    public GameObject LosePanel;
 
   
    bool dealDamage;
    [SerializeField] float damage;


    public float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        // Look for the Player in the scene
        playerTransform = GameObject.Find("Player").transform;
       
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            Time.timeScale = 0;
            LosePanel.SetActive(true);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Player")
            dealDamage = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (!playerTransform)
        {
            direction = Vector3.zero;
            return;
        }

        direction = playerTransform.position - transform.position;
        direction.y = 0;
        rb.rotation = Quaternion.LookRotation(direction);
        rb.angularVelocity = Vector3.zero;
        rb.MovePosition(rb.position + direction.normalized * speed * Time.deltaTime);
        animator.SetFloat("Movespeed", 1);
        // Take damage over time.
       
    }

}
