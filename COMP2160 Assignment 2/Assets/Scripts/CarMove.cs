using UnityEngine;

public class CarMove: MonoBehaviour
{
    public int speed = 5;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));


        this.transform.position += Movement * speed * Time.deltaTime;
    }
}
