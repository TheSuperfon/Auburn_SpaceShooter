using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;
    public float timer = 0f;

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        DrawConstellations();
    }


    public void DrawConstellations()
    {
        for (int i = 0; i < starTransforms.Count - 1; ++i)
        {
            Debug.DrawLine(starTransforms[i].position, starTransforms[i + 1].position, Color.white);
            if (timer < 3)
            {
                timer += Time.deltaTime;
            }
            timer = 0f;
        }
    }
}
