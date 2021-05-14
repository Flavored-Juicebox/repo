using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_controller : MonoBehaviour
{
    [SerializeField] private float movementSpeed, jumpForce, raycastDistance;
    Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        #region Movement
        Vector2 kd = new Vector2(Input.GetAxisRaw("Horizontal") * movementSpeed, Input.GetAxisRaw("Vertical") * movementSpeed);
        body.velocity = body.transform.TransformDirection(kd.x, body.velocity.y, kd.y);
        #endregion

        #region Jump
        if (groundCheck() && Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
        #endregion


    }
    private bool groundCheck()
    {
        return Physics.Raycast(transform.position, Vector3.down, raycastDistance);
    }
}
