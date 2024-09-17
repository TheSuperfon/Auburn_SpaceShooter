using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public float speed = 0.2f;

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
            transform.position += (Vector3.up * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += (Vector3.down * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += (Vector3.left * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += (Vector3.right * speed);
        }
    }


}
