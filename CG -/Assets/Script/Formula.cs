using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formula : MonoBehaviour
{
    Rigidbody2D formula;
    [SerializeField]
    float velocity;
    // Start is called before the first frame update
    void Start()
    {
        formula = this.GetComponent<Rigidbody2D>();
        this.formula.AddForce(Vector2.left * 500, ForceMode2D.Force);


    }

    // Update is called once per frame
    void Update()
    {
        velocity = this.formula.velocity.x;
        if(this.formula.velocity.x > -15)
            this.formula.AddForce(Vector2.left * 10, ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Untagged" && collision.collider.tag != "Coin")
        {
            Destroy(gameObject);
            
        }
    }

}
