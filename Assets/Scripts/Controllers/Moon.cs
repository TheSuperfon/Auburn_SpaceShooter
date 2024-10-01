using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public GameObject Asteroid;
    bool active = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active == true)
        {
            OrbitalMotion(3, 0.05f , Asteroid.transform);
        } 
    }

    public void OrbitalMotion(float radius, float speed, Transform target)
    {
        float repeats = 20;
        active = false;
        Vector3 StartPosition = new Vector3(target.transform.position.x + radius, target.transform.position.y, 0);

        

        Vector3 previouscorner = StartPosition;

        for (int i = 0; i < repeats; i++)
        {
            float CornerChange = 2f * Mathf.PI / repeats * i;

            Vector3 Currentcorner = new Vector3(target.transform.position.x + Mathf.Cos(CornerChange) * radius, target.transform.position.y + Mathf.Sin(CornerChange) * radius, 0);

            //Debug.DrawLine((previouscorner), (Currentcorner), RadarrColor);
            
            transform.position = Vector3.Lerp(previouscorner, Currentcorner, speed);

            previouscorner = Currentcorner;


        }

        active = true;
        transform.position = Vector3.Lerp(previouscorner, StartPosition, speed);
        //Debug.DrawLine((StartPosition), (previouscorner), RadarrColor);

    }


}
