using UnityEngine;

public class Player: MonoBehaviour
{
    
    public Rigidbody rb;
    public bool isTouching = true;
    public float maxDistance = 5;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isTouching)
        {

            float speed = 25.0f;
            float torque = 0.5f;

            if (Input.GetAxis("Vertical") > 0)
            {
                rb.AddRelativeForce(Vector3.forward * speed / 3);
                float turn = Input.GetAxis("Horizontal");
                rb.AddTorque(transform.up * (torque) * 10 * turn);

            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                rb.AddRelativeForce(Vector3.forward * -speed / 3);
                float turn = Input.GetAxis("Horizontal");
                rb.AddTorque(transform.up * (torque) * -10 * turn);

            }
        }

    }

    // void OnCollisionEnter(Collision other)
    // {


    //         isTouching = true; // they are touching AND close

        
    // }
    // void OnCollisionExit(Collision other)
    // {

    //         isTouching = false;

    // }

}
