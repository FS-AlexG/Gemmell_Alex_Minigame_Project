using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour{

    //Float variable that stores the speed at which asteroids will fly by
    private float asteroidSpeed = 10.0f;
    //Float variable that stores how far away the asteroids have to be before they are cleaned up
    private float destroyObjectBorder = -20.0f;

    //Initialization
    void Start(){
        


    }

    //Every frame
    void Update(){

        //Move asteroids down the screen 
        transform.Translate(Vector3.left * Time.deltaTime * asteroidSpeed);
        CleanAsteroid();

    }

    //Upon collision
    private void OnTriggerEnter(Collider other){

        //Delete the player object
        Destroy(other.gameObject);

    }

    //Destroy Asteroid and Conditions
    void CleanAsteroid(){

        //If the asteroid is at or further than -20x
        if (transform.position.x < destroyObjectBorder){

            //Destroy it
            Destroy(gameObject);

        }

    }

}
