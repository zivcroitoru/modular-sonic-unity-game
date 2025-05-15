using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlowerController : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("OnCollisionEnter2D " + col.gameObject.name);
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Mario Collision! Fire Flower");
            this.gameObject.SetActive(false);
            col.gameObject.GetComponent<PlayerPowerUp>().CollectPowerUp(new FireFlowerPowerUp());
            //Implement Power Up
        }
    }
}
