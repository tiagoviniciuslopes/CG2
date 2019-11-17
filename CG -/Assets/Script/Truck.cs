using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    int force;
    int forceUp;
    bool jump;
    Rigidbody2D truck;
    [SerializeField]
    float velocity;
    [SerializeField]
    GameObject basicExplosion;
    GameObject objExplosion;
    [SerializeField]
    GameObject basicExplosionSound;
    GameObject objExplosionSound;
    [SerializeField]
    GameObject basicGameOver;
    GameObject objGameOver;

    private void Awake()
    {
        this.truck = this.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        force = 10;
        forceUp = 7;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = this.truck.velocity.x;
        if (Input.GetKey(KeyCode.LeftArrow) && truck.velocity.x > -15)
        {
            truck.AddForce(Vector2.left * force,ForceMode2D.Force);
        } 
        if (Input.GetKey(KeyCode.RightArrow) && truck.velocity.x < 15) 
        {
            truck.AddForce(Vector2.right * force, ForceMode2D.Force);
        }
        if(Input.GetKey(KeyCode.UpArrow) && jump )
        {
            truck.AddForce(Vector2.up * forceUp, ForceMode2D.Impulse);
            jump = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jump = true;
        if (collision.collider.tag == "Enemy")
        {
            objExplosion = GameObject.Instantiate(basicExplosion, this.transform.position, this.transform.rotation);
            objExplosionSound = GameObject.Instantiate(basicExplosionSound, this.transform.position, this.transform.rotation);
            Destroy(gameObject.GetComponent<SpriteRenderer>());

            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
            for (var i = 0; i < gameObjects.Length; i++)
            {
                Destroy(gameObjects[i]);
            }

            StartCoroutine(GameOver());
            
            
        }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.76f);
        Destroy(objExplosion.GetComponent<Animator>());
        Destroy(objExplosion.GetComponent<SpriteRenderer>());

        objGameOver = GameObject.Instantiate(basicGameOver, this.transform.position, this.transform.rotation);

        Time.timeScale = 0;
    }

}
