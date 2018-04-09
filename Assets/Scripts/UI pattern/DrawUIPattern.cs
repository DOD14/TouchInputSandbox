using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class DrawUIPattern : MonoBehaviour {

    public Transform tracer;
    public Text topText;
    public Text bottomText;

    private List<int> numberList = new List<int>(0);

    private TrailRenderer trail;
    private ParticleSystem particles;


	// Use this for initialization
	void Start () {

        trail = tracer.GetComponent<TrailRenderer>();
        particles = tracer.GetComponent<ParticleSystem>();
      
	}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isTouching = true;
            particles.Play();
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            tracer.transform.position = worldPos + Vector3.forward;
        }
    
        if (Input.GetMouseButtonUp(0)) 
        {

            trail.Clear();
            particles.Stop();


            string output = ""; 

            foreach (var i in numberList)
                output += i.ToString(); 

            bottomText.text = output; 
            numberList.Clear(); 
        }


	}

    public void AddNumberToList(int calledNumber)
    {
        //if(isTouching)
            if (numberList.Count == 0 || numberList[numberList.Count - 1] != calledNumber)
            { 
                numberList.Add(calledNumber); topText.text = calledNumber.ToString(); 
            } 
    }


  
}
