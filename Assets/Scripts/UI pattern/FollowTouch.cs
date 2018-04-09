using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTouch : MonoBehaviour {

    private TrailRenderer trail;
	// Use this for initialization
	void Start () {
        trail = GetComponent<TrailRenderer>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(Input.GetMouseButtonDown(0))
        {
           trail.enabled = true;
           Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = worldPos + Vector3.forward;
        }

       
        if(Input.GetMouseButtonUp(0))
        {
            trail.enabled = false;
            trail.Clear();
        }
	}
}
