using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour{

    //Store prefabs
    public GameObject asteroid;
    public GameObject enemy;

    //Boolean variable that stores if there is an enemy on the board currently or not.
    public bool enemyExists = false;

    //Two float variables that store the limits for the region an asteroid can spawn
    private float spawnBorderStart = 12.0f;
    private float spawnBorderEnd = 20.0f;
    //Stores the x position the asteroids will spawn at
    private float asteroidXPosition = 18.0f;

    //Vector3 that stores the starting spawn position of an enemy
    private Vector3 enemySpawnPosition = new Vector3(8.0f, 1.0f, 10.0f);

    //Variables for the repeating method
    private float startDelay = 1.0f;
    private float spawnInterval = 0.25f;


    //Initialization
    void Start(){

        //Initially start a repeating method to call SpawnAsteroids
        InvokeRepeating("SpawnAsteroids", startDelay, spawnInterval);

    }

    //Every frame
    void Update(){

        //If there is no enemy on the board  spawn the enemy
        SpawnEnemy();

    }

    //Spawns Asteroid 
    void SpawnAsteroids(){

        //Switches which side the asteroid will spawn on after each method call
        spawnBorderEnd *= -1;
        spawnBorderStart *= -1;

        //Vector variable that stores where the asteroid will spawn
        Vector3 spawnPosition = new Vector3(asteroidXPosition, 1.0f, Random.Range(spawnBorderStart, spawnBorderEnd));

        //Create an asteroid and set where is spawns according to the random position of the spawnPosition variable
        Instantiate(asteroid, spawnPosition, asteroid.transform.rotation);

    }

    //Spawns Enemies
    void SpawnEnemy(){

        //If there is no enemy currently
        if(enemyExists == false){

            //Create an enemy
            Instantiate(enemy, enemySpawnPosition, enemy.transform.rotation);

            //indicate that an enemy now exists
            enemyExists = true;

        }

    }

}

