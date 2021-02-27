using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour{

    //Stores the laser prefab the enemy will be shooting
    public GameObject laser;

    //Float variables that stores the speed at which the enemy moves back and forth, changes with each new enemy
    private float enemySpeedMin = 10.0f;
    private float enemySpeedMax = 40.0f;
    //The actual speed will be intitialized upon creation of the enemy
    private float enemySpeed;

    //Float variable that stores the border in which the enemy moves
    private float enemyBorder = 10.0f;
    //Boolean that stores if the enemy has hit the border
    private bool hitRightBorder = false;

    //Variables for the InvokeRepeating, changes between each new enemy
    private float delayLow = 0.0f;
    private float delayHigh = 5.0f;
    private float intervalLow = 0.1f;
    private float intervalHigh = 2.0f;

    //Initialization
    void Start(){

        //Repeatedly call the ShootLaser method with a range of speeds at which the enemy can fire
        InvokeRepeating("ShootLaser", Random.Range(delayLow, delayHigh), Random.Range(intervalLow, intervalHigh));

        //Set the speed of this current enemy that has spawned
        enemySpeed = Random.Range(enemySpeedMin, enemySpeedMax);

    }

    //Every Frame
    void Update(){

        //Move the enemy using the speed that has been initialized previously
        MoveEnemy(enemySpeed);

    }

    //Upon collision with player laser
    private void OnTriggerEnter(Collider other){

        //Set the public variable enemy exists to false to indicate to the spawn manager it needs to spawn another enemy
        GameObject.Find("SpawnManager").GetComponent<SpawnManager>().enemyExists = false;

        GameObject.Find("Counter").GetComponent<CounterManager>().counterNumber++;

    }

    //Move the enemy back and forth
    void MoveEnemy(float enemySpeed){

        //If the enemy has yet to hit the right border
        if (hitRightBorder == false){

            //Move it to the right
            transform.Translate(Vector3.back * Time.deltaTime * enemySpeed);

            //If it then hits the right border
            if(transform.position.z < -enemyBorder){

                //Indicate that it has hit the right border
                hitRightBorder = true;

            }

        }
        //If the enemy has hit the right border
        if(hitRightBorder == true){

            //Move it left
            transform.Translate(Vector3.forward * Time.deltaTime * enemySpeed);

            //If it has hit the left border
            if (transform.position.z > enemyBorder){

                //Indicate that it hit the left border
                hitRightBorder = false;

            }

        }

    }

    //Fires the laser for the enemy
    void ShootLaser(){

        //Vector3 that stores where the laser should spawn according to where the enemy is
        Vector3 laserPosition = new Vector3(7.0f, 1.0f, transform.position.z);

        //Create the laser and put it in the position determined by the laserPosition vector
        Instantiate(laser, laserPosition, laser.transform.rotation);

    }

}
