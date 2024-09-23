using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public float speed = 10f;
    public float MaxSpeed = 40f;
    public float AccelerationTime = 0;

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        playermovementMethod();
        
    }
    void playermovementMethod()
    {
        //transform.position += direction;
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += ((Vector3.up * speed) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += ((Vector3.down * speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += ((Vector3.left * speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += ((Vector3.right * speed * Time.deltaTime));
        }
        if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.D)))
        {
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
            speed = 10f;
            AccelerationTime = 0;
        }
    }


}
