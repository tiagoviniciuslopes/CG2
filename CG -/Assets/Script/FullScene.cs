using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScene : MonoBehaviour
{
    Vector3 initialPosition;
    [SerializeField]
    float timeGap;
    float ticker;
    int count;
    float distance;
    GameObject obj;
    [SerializeField]
    GameObject initialObj;

    private void Awake()
    {
        this.initialPosition = this.transform.position;
        this.ticker = timeGap;
        count = 1;
        distance = 76.9f-(-17.08892f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ticker -= Time.deltaTime;

        if (ticker < 0)
        {
            generateScene();
            ticker = timeGap;
        }
    }

    void generateScene()
    {
        var pos = this.transform.position;
        pos.x = pos.x + (distance * count);
        obj = GameObject.Instantiate(initialObj, pos, gameObject.transform.rotation);
        count++;
    }
}
