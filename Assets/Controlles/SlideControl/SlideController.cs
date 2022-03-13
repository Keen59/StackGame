using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideController : MonoBehaviour
{
    public bool dragging = false;
    private float distance;
    public Vector3 CharacterVector;
   
    
    public float  Xmax, Xmin;
    public Vector3 FirstTouch;

    public void ScreenTouchDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 rayPoint = ray.GetPoint(distance);
        FirstTouch = rayPoint - transform.position;
    }

    public void ScreenTouchUp()
    {
        dragging = false;
    }
   
    void Update()
    {

        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            CharacterVector = new Vector3(Mathf.Clamp(rayPoint.x - FirstTouch.x, Xmin, Xmax), transform.position.y, transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, CharacterVector, 10f * Time.deltaTime);
        }

    }
   
}
