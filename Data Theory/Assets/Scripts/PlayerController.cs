using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody playerRb;
    [SerializeField] float speed = 15f;
    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;
    [SerializeField] float rotationX;
    [SerializeField] float sensibility;
    [SerializeField] GameObject orientation;
    [SerializeField] Vector3 moveDirection;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] bool reload = false;
    [SerializeField] public bool isGameOn = true;
    [SerializeField] TextMeshProUGUI gameOverText;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOn)
        {
            playerRb.MoveRotation(orientation.transform.rotation);
            Shoot();
        }
        
    }
    private void FixedUpdate()
    {
        if(isGameOn)
        {
            Move();
        }
    }

    private void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        moveDirection = orientation.transform.right * horizontalInput + orientation.transform.forward * verticalInput;
        playerRb.AddForce(moveDirection.normalized * speed * 10f, ForceMode.Force);
    }
    IEnumerator cooldown()
    {
        reload = true;
        yield return new WaitForSeconds(0.5f);
        reload = false;
    }
    private void Shoot()
    {
        if(Input.GetKeyDown("space") && !reload)
        {
            Instantiate(bulletPrefab, orientation.transform.position, transform.rotation);
            StartCoroutine(cooldown());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hello");
            isGameOn = false;
            gameOverText.gameObject.SetActive(true);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hello");
            isGameOn = false;
            gameOverText.gameObject.SetActive(true);
        }
    }
}
