using UnityEngine;

public class CarMove: MonoBehaviour
{
    
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    // Update is called once per frame
    void FixedUpdate()
    {
        float speed = 60.0f;
        float torque = 0.5f;
        if (Input.GetAxis("Vertical") > 0)
        {
            rb.AddRelativeForce(Vector3.forward * speed/3);
            float turn = Input.GetAxis("Horizontal");
            rb.AddTorque(transform.up * (torque) * 10 * turn);

        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            rb.AddRelativeForce(Vector3.forward * -speed/3);
            float turn = Input.GetAxis("Horizontal");
            rb.AddTorque(transform.up * (torque) * -10 * turn);
        }



        
    }


}
