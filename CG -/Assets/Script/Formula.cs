using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formula : MonoBehaviour
{
    Rigidbody2D formula;
    // Start is called before the first frame update
    void Start()
    {
        formula = this.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        this.formula.AddForce(Vector2.left * 20, ForceMode2D.Force);  
    }
}
