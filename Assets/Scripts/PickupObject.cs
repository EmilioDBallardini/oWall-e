using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "oWall-e" || collider.gameObject.tag == "oEva"){
            print ("item pickup");
            Destroy(gameObject);
        }
    }
}
