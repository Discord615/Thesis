using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private bool isGrounded;
    Vector2 moveDirection;
    private Rigidbody player;
    
    private void Start() {
        player = GetComponent<Rigidbody>();
    }

    private void Update() {
        if (isGrounded) move();
        rotation();
        jump();
    }

    private void move(){
        moveDirection = inputManager.instance.getMovedPressed();

        float velocityX = speed * moveDirection.x;
        float velocityZ = speed * moveDirection.y;

        player.velocity = new Vector3(velocityX, 0, velocityZ);
    }

    private void rotation(){
        if (moveDirection != Vector2.zero)
        {
            Vector3 v3 = new Vector3(moveDirection.x, 0, moveDirection.y);

            Quaternion rotation = Quaternion.LookRotation(v3, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 720f * Time.deltaTime);

        }
    }

    private void jump(){
        if (inputManager.instance.getSpacePressed() && isGrounded)
        {
            isGrounded = false;
            player.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Floor"){
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other) {
        if (other.gameObject.tag == "Floor"){
            isGrounded = false;
        }
    }
}
