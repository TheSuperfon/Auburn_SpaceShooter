using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CircleExercise : MonoBehaviour
{
    public Vector3 Offset = Vector3.zero;
    public float radius = 3;
    public List<float> angleslist;
    int currentAngle = 0;
    float elapsedTime = 0;
    public float delayinSeconds = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        if (angleslist == null)
        {
            angleslist = new List<float>();
        }

        for (int i = 0; i < 10; i++)
        {
            angleslist.Add(Random.value * 360);
        }

        transform.position += Offset;
    }

    private void OnValidate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > delayinSeconds)
        {
            currentAngle = (currentAngle + 1) % angleslist.Count;
            elapsedTime = 0;
        }

        /*if(Input.GetKeyDown(KeyCode.Space))
        {
            currentAngle = (currentAngle + 1 ) % angleslist.Count;
        }*/


        float radians = Mathf.Deg2Rad * angleslist[currentAngle];
        float xPosition = Mathf.Cos(radians);
        float yPosition = Mathf.Sin(radians);
        Vector3 Endpoint = transform.position + new Vector3(xPosition, yPosition, 0f) * radius;
        Debug.DrawLine(transform.position, Endpoint, Color.magenta);
    }
}
