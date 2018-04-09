using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //pentru UI, de remarcat ca e inclus in mod normal, trebuie pus explicit

public class DrawPattern : MonoBehaviour {

    public GameObject[] buttons; //vectorul cu bulinele ca GameObject
    public Transform tracer; //un obiect care urmareste locul apasat pe ecran

    public Text topText; //textul care arata numarul curent
    public Text bottomText; //arata secventa de numere formata

    private List<int> numberList = new List<int>(0); //numarul bulinei atinse e adaugat la lista asta
    private Dictionary<GameObject, int> dictionary = new Dictionary<GameObject, int>(); //fiecarei buline ii corespunde un numar, cam asta e dictionarul

    private TrailRenderer trail; //'pentru linia desenata pe ecran

	// Use this for initialization
	void Start () {

        trail = tracer.GetComponent<TrailRenderer>(); //GetComponent ca sa salvam componenta in variabila trail

        for (int i = 0; i <= 8; i++) //bag in dictionar intrari de tipul GameObject:int, adica bulina:nr_bulina pentru toate obiectele
            dictionary.Add(buttons[i], i);
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) //cand mouse-ul e apasat (click-stanga are codul 0)
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //gasim pozitia in WorldSpace pentru obiectul tracer, pornind de la ecran
            tracer.transform.position = worldPos + Vector3.forward; //l-am dus putin in spate ca sa nu fie fix in fata camerei

            //urmeaza sa facem un RayCast, e ca si cum tragi cu pistolul pe o directie si te uiti ce ai nimerit
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //directia indicata de locul apasat pe ecran, asa cum se vede pe ecran
            RaycastHit hit; //variabila care va memora ce am nimerit in RayCast

            if (Physics.Raycast(ray, out hit)) //foc!
            {
                //o sa ne uitam ce am lovit si intrebam dictionarul ce numar corespunde bulinei
                int hitButtonNumber; //aici o sa stocam numarul gasit de dictionar
                dictionary.TryGetValue(hit.collider.gameObject, out hitButtonNumber);//self-explanatory
                Debug.Log(hitButtonNumber); //for debugging purposes
                if (numberList.Count == 0 || numberList[numberList.Count - 1] != hitButtonNumber) //am adaugat conditia asta pentru ca imi baga acelasi numar de mai multe ori altfel
                { numberList.Add(hitButtonNumber); topText.text = hitButtonNumber.ToString(); } //bag numarul in lista curenta si il afisez in textul de sus
            }
        }
    
        if (Input.GetMouseButtonUp(0)) //la ridicarea butonului mouse-ului
        {
            trail.Clear(); //stergem urma lasata


            string output = ""; //pregatim un string in care sa bagam numerele din lista

            foreach (var i in numberList)
                output += i.ToString(); //le punem in string

            bottomText.text = output; //il afisam in textul de jos
            Debug.Log(output);
            numberList.Clear(); //golim lista
        }


	}


  
}
