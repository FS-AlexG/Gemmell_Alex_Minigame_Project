using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{

    //Float variable that stores the speed at which the laser moves
    public float laserSpeed = 0.0f;

    //Float variable that stores the object border
    private float destroyObjectBorder = 20.0f;

    //Initialization
    void Start(){
        



    }

    //Every frame
    void Update(){

        //Move the laser down
        transform.Translate(Vector3.left * Time.deltaTime * laserSpeed);

        //Destroy lasers that go out of the borders
        CleanLasers();

    }

    //If the laser collides with another object destroy both the laser and the object
    private void OnTriggerEnter(Collider other){

        //Delete the player object
        Destroy(other.gameObject);
        Destroy(gameObject);

    }

    //Destroy lasers under certain conditions
    void CleanLasers(){

        //If the laser is at or further than 20.0x
        if (transform.position.x > destroyObjectBorder){

            //Destroy it
            Destroy(gameObject);

        }
        //Else if the laser is further than -20.0x
        else if (transform.position.x < -destroyObjectBorder){

            //Destroy it
            Destroy(gameObject);

        }

    }

}
