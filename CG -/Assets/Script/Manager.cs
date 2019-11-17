using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public void gameOver(GameObject playerObject, GameObject objExplosion, GameObject objExplosionSound) 
    {
        new WaitForSeconds(2);
        Time.timeScale = 0;
        //Destroy(objExplosionSound);
        //Destroy(objExplosion);
        //Destroy(playerObject);

    }

}
