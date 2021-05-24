using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    /* public float moveSpeed = 0.2f;
    public float rotationSpeed = 2.5f;

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(vertical, 0.0f, 0);

        transform.Translate(movement * moveSpeed);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + horizontal * rotationSpeed, 0);
    }

    */

    Rigidbody rb;

    private bool isOnAbilities = false;

    public float forwardSpeed = 25f, strafeSpeed = 7.5f, hoverSpeed = 5f;
    private float activeForwardSpeed, activeStrafeSpeed, activeHoverSpeed;
    private float forwardAcceleration = 2f, strafeAcceleration = 2f, hoverAcceleration = 2f;

    public float lookRateSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;


    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("StartMusic");
        rb = GetComponent<Rigidbody>();
        screenCenter.x = Screen.width * .5f;
        screenCenter.y = Screen.height * .5f;
        
    }

    public void changeAbilitiesState()
    {
        if (isOnAbilities)
        {
            isOnAbilities = false;
        }
        else
            isOnAbilities = true;
    }

    public void doSpaceWarp()
    {
        transform.position += transform.forward * 25;
    }

    // Update is called once per frame
    void Update()
    {
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.x;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, mouseDistance.x * lookRateSpeed * Time.deltaTime, 0f, Space.Self);

        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAcceleration * Time.deltaTime);

        if (isOnAbilities)
        {
            activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAcceleration * Time.deltaTime);
            activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAcceleration * Time.deltaTime);
        }

        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
        
        transform.position += transform.right * activeStrafeSpeed * Time.deltaTime;
        transform.position += transform.up * activeHoverSpeed * Time.deltaTime;

        //rb.AddForce(Vector3.forward * 2);
        //rb.velocity = Vector3.forward * 10f;



        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    rb.AddForce(Vector3.right * 500);
        //    rb.velocity = Vector3.right * 10f;
        //}
        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    rb.AddForce(Vector3.up * 500);
        //    rb.velocity = Vector3.up * 10f;
        //}
        //if (Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    rb.AddForce(Vector3.down * 500);
        //    rb.velocity = Vector3.down * 10f;
        //}
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    rb.AddForce(Vector3.left * 500);
        //    rb.velocity = Vector3.left * 10f;
        //}
    }
}
