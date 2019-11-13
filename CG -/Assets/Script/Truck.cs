using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    int force;
    bool jump;
    Rigidbody2D truck;

    private void Awake()
    {
        this.truck = this.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        force = 10;   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("LEFT");
            truck.AddForce(Vector2.left * force,ForceMode2D.Force);
        } 
        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            Debug.Log("RIGHT");
            truck.AddForce(Vector2.right * force, ForceMode2D.Force);
        }
        if(Input.GetKey(KeyCode.UpArrow) && jump)
        {
            Debug.Log("UP");
            truck.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            jump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jump = true;
    }
}
