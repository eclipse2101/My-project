using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    public float vertical;
    public float horizontial; 
    public float speed;
    public float jumpPower;  
    public bool isGrounded = true;
    Rigidbody player; 
    // Start is called before the first frame update
    void Start()
    {
       player = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        horizontial = Input.GetAxis("Horizontal"); 
        vertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontial);

        if((vertical > 0.4f && isGrounded == true) || (Input.GetKeyDown(KeyCode.Space) && isGrounded == true))
        {
           isGrounded = false;
           player.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
           vertical = 0;
        }

        if (vertical < -0.1f && isGrounded == true)
        {
            Debug.Log("The player is crouching");
        }

        if(Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Button was Pressed");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.CompareTag("Ground"))
        {
             isGrounded = true;
        }
    }
}
