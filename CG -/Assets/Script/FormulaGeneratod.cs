using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormulaGeneratod : MonoBehaviour
{
    [SerializeField]
    float timeGap;
    float ticker;
    [SerializeField]
    GameObject basicFormula;
    GameObject obj;

    private void Awake()
    {
        this.ticker = timeGap;
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
            generateFormula();
            ticker = timeGap;
        }
    }

    void generateFormula() 
    {
        obj = GameObject.Instantiate(basicFormula, this.transform.position, basicFormula.transform.rotation);
        obj.tag = "Enemy";
    }
}
