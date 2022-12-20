using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;

    public float horizontalInput;
    public float verticalInput;
    public float playerSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        float xRaw = Input.GetAxisRaw("Horizontal");
        float yRaw = Input.GetAxisRaw("Vertical");

        // player left border
        if (transform.position.x < -1.6f)
        {
            transform.position = new Vector3(-1.6f, transform.position.y, transform.position.z);
        }

        // player right border
        if (transform.position.x > 6)
        {
            transform.position = new Vector3(6, transform.position.y, transform.position.z);
        }

        // player up border
        if (transform.position.z > 2.65f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 2.65f);
        }

        // player down border
        if (transform.position.z < -2.1f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -2.1f);
        }

        transform.Translate(Vector3.right * _joystick.Horizontal * Time.deltaTime * playerSpeed);
        transform.Translate(Vector3.up * _joystick.Vertical * Time.deltaTime * playerSpeed);
    }

}
