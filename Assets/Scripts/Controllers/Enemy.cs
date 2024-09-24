using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float Timer = 0;
    public float direction;
    public float speed = 4f;
    public Vector3 Velocity;

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        EnemyMovement();
    }


    public void EnemyMovement()
    {
        
        Timer += Time.deltaTime;
        if (direction == 1)
        {
            Velocity = Vector3.up;
        }
        else if (direction == 2)
        {
            Velocity = Vector3.down;
        }
        else if (direction == 3)
        {
            Velocity = Vector3.left;
        }
        else
        {
            Velocity = Vector3.right;
        }
        if (Timer < 5)
        {
            transform.position += ((Velocity * speed) * Time.deltaTime);



        }
        else
        {
            direction = Random.Range(1, 5);
            Timer = 0;
        }


    }

}
