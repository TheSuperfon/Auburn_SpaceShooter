using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float arrivalDistance;
    public float maxFloatDistanceX;
    public float maxFloatDistanceY;
    public Vector3 Newposition;
    

    // Start is called before the first frame update
    void Start()
    {
        maxFloatDistanceX = Random.Range(-5,6);
        maxFloatDistanceY = Random.Range(-5, 6);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        AsteroidMovement();
        
    }


    public void AsteroidMovement()
    {
        //Newposition = new Vector3(transform.position.x + maxFloatDistance,transform.position.y + maxFloatDistance,0);
        Newposition = new Vector3(transform.position.x + maxFloatDistanceX, transform.position.y + maxFloatDistanceY, 0);
        transform.position = Vector3.Lerp(transform.position, Newposition, moveSpeed);
    }

}
