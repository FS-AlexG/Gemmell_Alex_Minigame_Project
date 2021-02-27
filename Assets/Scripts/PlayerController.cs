using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    //Stores the blue laser prfab
    public GameObject laser;

    //Float variable that stores if the user is trying to move left, right, or stay in place (-1, 1, 0)
    public float horizontalInput = 0.0f;

    //Float variable that stores how fast the player can move left or right
    private float playerSpeed = 10.0f;
    //Float variable that stores the distance the player can move left or right
    private float playerLimits = 20.0f;

    //Creating a delay for when the user is allowed to fiere
    private float fireRate = 0.5f;
    private float nextFire = 0.0f;

    //Initialization
    void Start(){
        


    }

    //Every Frame
    void Update(){

        //Method call to control play movements
        UpdateMovement();

        //If the space bar is pressed within limits
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire){

            //Update the timer for the delay
            nextFire = Time.time + fireRate;

            //Vector3 that stores where the laser should spawn according to where the player
            Vector3 laserPosition = new Vector3(-5.0f, 1.0f, transform.position.z);

            //Create the laser and put it in the position determined by the laserPosition vector
            Instantiate(laser, laserPosition, laser.transform.rotation);

        }

    }

    //Control player movement
    void UpdateMovement(){

        //Consistantly store the users input into the horizontalInput variable
        horizontalInput = Input.GetAxis("Horizontal");

        //Move the player object every second  right or left by the speed set depending on the input of the user
        transform.Translate(Vector3.back * horizontalInput * Time.deltaTime * playerSpeed);



        //If the player moves to far to the left
        if (transform.position.z < -playerLimits){

            //fix their position to stop them from going any further
            transform.position = new Vector3(transform.position.x, transform.position.y, -playerLimits);

        }
        //Else if the player moves to far to the right
        else if (transform.position.z > playerLimits){

            //fix their position to stop them from going any further
            transform.position = new Vector3(transform.position.x, transform.position.y, playerLimits);

        }

    }

}
