using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public GameObject powerupPrefab;
    public Transform bombsTransform;
    public float speed = 10f;
    public float MaxSpeed = 40f;
    public float AccelerationTime = 0;
    public float DecelerationTime = 2f;
    public Vector3 PlayerDirection;
    bool powerupsSpawned = false;



    void Update()
    {
        EnemyRadar(3f, 8);
        if (Input.GetKeyDown(KeyCode.P))
        {
            powerupsSpawned = false;
        }
    }

    private void FixedUpdate()
    {
        playermovementMethod();
        if (powerupsSpawned == false)
        {
            SpawnPowerups(3, 8);
            powerupsSpawned=true;
        }
        
    }
    void playermovementMethod()
    {
        
        //transform.position += direction;
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += ((Vector3.up * speed) * Time.deltaTime);
            PlayerDirection = Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += ((Vector3.down * speed * Time.deltaTime));
            PlayerDirection = Vector3.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += ((Vector3.left * speed * Time.deltaTime));
            PlayerDirection = Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += ((Vector3.right * speed * Time.deltaTime));
            PlayerDirection = Vector3.right;
        }
        if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.D)))
        {
            
            DecelerationTime = 1f;
            AccelerationTime += Time.deltaTime;
            if (AccelerationTime < 3)
            {
                speed += ((MaxSpeed * Time.deltaTime)/ 3);
            }

            
            if (speed >= MaxSpeed)
            {
                speed = MaxSpeed;
            }
        }
        else
        {
            DecelerationTime -= Time.deltaTime;
            if (DecelerationTime > 0)
            {
                transform.position += ((PlayerDirection * speed) * Time.deltaTime);
                if (speed > 0)
                {
                    speed -= ((MaxSpeed * Time.deltaTime) / 3);
                }
                
            }
            else
            {
                DecelerationTime = 0;
                speed = 10f;
                AccelerationTime = 0;
            }
            
            
        }
    }


    public void EnemyRadar(float radius, int circlePoints)
    {
        Color RadarrColor;
        float Enemydistance = Vector3.Distance(transform.position, enemyTransform.position);
        if (Enemydistance <= radius + (enemyTransform.localScale.x/2) || Enemydistance <= radius + (enemyTransform.localScale.y / 2))
        {
            RadarrColor = Color.red;
        }
        else
        {
            RadarrColor = Color.green;
        }

        Vector3 StartPosition = new Vector3(transform.position.x + radius, transform.position.y, 0);

        Vector3 previouscorner = StartPosition;

        for (int i = 0; i < circlePoints; i++)
        {
            
            float CornerChange = 2f * Mathf.PI / circlePoints * i;

            Vector3 Currentcorner = new Vector3(transform.position.x + Mathf.Cos(CornerChange) * radius, transform.position.y + Mathf.Sin(CornerChange) * radius, 0);

            Debug.DrawLine((previouscorner), (Currentcorner), RadarrColor);

            previouscorner = Currentcorner;


        }

        Debug.DrawLine((StartPosition), (previouscorner), RadarrColor);

    }

    public void SpawnPowerups(float radius, int numberofPowerups)
    {
        
        Instantiate(powerupPrefab, new Vector3(transform.position.x + radius, transform.position.y, 0), Quaternion.identity);


        for (int i = 0; i < numberofPowerups; i++)
        {

            float CornerChange = 2f * Mathf.PI / numberofPowerups * i;

            Vector3 CurrentPowerupSpawn = new Vector3(transform.position.x + Mathf.Cos(CornerChange) * radius, transform.position.y + Mathf.Sin(CornerChange) * radius, 0);

            Instantiate(powerupPrefab, CurrentPowerupSpawn, Quaternion.identity);


        }



    }

}
