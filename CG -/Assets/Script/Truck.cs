using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    float[] rotationRight;
    float[] rotationLeft;
    bool right, left;
    int totalCoins;
    [SerializeField]
    GameObject coinSound;
    float velX;
    float velY;
    [SerializeField]
    Camera mainCamera;
    [SerializeField]
    Text text;
    [SerializeField]
    Text coinText;
    [SerializeField]
    GameObject renderCanvas;

    private void Awake()
    {
        this.truck = this.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rotationLeft = new float[3] { 0, 180, 0 };
        rotationRight = new float[3] { 0, 0, 0 };
        force = 10;
        forceUp = 7;
        right = true;
        left = false;
        totalCoins = 0;

    }

    // Update is called once per frame
    void Update()
    {
        velocity = this.truck.velocity.x;
        velX = this.truck.velocity.x;
        velY = this.truck.velocity.y;
        if (Input.GetKey(KeyCode.LeftArrow) && truck.velocity.x > -15)
        {
            if (right) 
            {
                truck.transform.rotation = Quaternion.Euler(rotationLeft[0], rotationLeft[1], rotationLeft[2]);
                right = false;
                left = true;
            }
            truck.AddForce(Vector2.left * force,ForceMode2D.Force);
        } 
        if (Input.GetKey(KeyCode.RightArrow) && truck.velocity.x < 15) 
        {
            if (left)
            {
                truck.transform.rotation = Quaternion.Euler(rotationRight[0], rotationRight[1], rotationRight[2]);
                right = true;
                left = false;
            }
            
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
            
            truck.velocity = Vector3.zero;
            truck.angularVelocity = 0f;

            objExplosion = GameObject.Instantiate(basicExplosion, this.transform.position, this.transform.rotation);
            objExplosionSound = GameObject.Instantiate(basicExplosionSound, this.transform.position, this.transform.rotation);
            Destroy(gameObject.GetComponent<SpriteRenderer>());
            Destroy(mainCamera.GetComponent<CameraFollow>());

            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
            for (var i = 0; i < gameObjects.Length; i++)
            {
                Destroy(gameObjects[i]);
            }

            StartCoroutine(GameOver());
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TRIGGER");
        objExplosionSound = GameObject.Instantiate(coinSound, this.transform.position, this.transform.rotation);
        Destroy(collision.gameObject);
        totalCoins++;
        coinText.text = totalCoins.ToString();
        Debug.Log(totalCoins);
    }


    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.76f);
        Destroy(objExplosion.GetComponent<Animator>());
        Destroy(objExplosion.GetComponent<SpriteRenderer>());

        float x = mainCamera.transform.position.x;
        float y = mainCamera.transform.position.y;

        Vector3 position = new Vector3(x - 6f, y, 0 );
        objGameOver = GameObject.Instantiate(basicGameOver, position, Quaternion.Euler(0,0,0));

        Vector3 pos = new Vector3(x - 20f, y - 10, 0);
        Text tempTextBox = Instantiate(text, pos, Quaternion.Euler(0, 0, 0)) as Text;
        tempTextBox.fontSize = 50;
        tempTextBox.alignment = TextAnchor.LowerLeft;

        RectTransform assign_text_1RT = tempTextBox.GetComponent<RectTransform>();
        assign_text_1RT.anchoredPosition = pos;
        assign_text_1RT.position = pos;
        assign_text_1RT.sizeDelta = new Vector2(330, 700);

        tempTextBox.transform.SetParent(renderCanvas.transform, false);
        

        Time.timeScale = 0;
    }

}
