using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageEncounters : MonoBehaviour {

    public GameObject cube;
    public GameObject sphere;

    public Text infoText;

    public Text cubeHPtext;
    public Text cubeATKText;
    public Text cubeDEFText;

    public Text sphereHPText;
    public Text sphereATKText;
    public Text sphereDEFText;

    public List<EncounterObject> encounters;

    private EncounterObject currentEncounter;
    private int encounterNumber;

    private int currentCubeHP;
    private int currentSphereHP;

	// Use this for initialization
	void Start () {
        NextBattle();
	}
	
	// Update is called once per frame
	

    void InitBattle()
    {
        infoText.text = "Encounter from list: " + currentEncounter.myNumber.ToString();
        
        currentCubeHP = currentEncounter.cubeHP;
        currentSphereHP = currentEncounter.sphereHP;

        cubeHPtext.text = "HP:" + currentEncounter.cubeHP.ToString();
        cubeATKText.text = "ATK:" + currentEncounter.cubeATK.ToString();
        cubeDEFText.text = "DEF:" + currentEncounter.cubeDEF.ToString();

        sphereHPText.text = "HP:" + currentEncounter.sphereHP.ToString();
        sphereATKText.text = "ATK:" + currentEncounter.sphereATK.ToString();
        sphereDEFText.text = "DEF:" + currentEncounter.sphereDEF.ToString();

        cube.GetComponent<MeshRenderer>().material = currentEncounter.cubeColor;
        sphere.GetComponent<MeshRenderer>().material = currentEncounter.sphereColor;

    }

    public void UpdateSphereHP()
    {
        currentSphereHP -=  currentEncounter.cubeATK - currentEncounter.sphereDEF;
        if (currentSphereHP <= 0) { Debug.Log("Cube wins"); NextBattle(); }
        else sphereHPText.text = "HP:" + currentSphereHP.ToString();
    }

    public void UpdateCubeHP()
    {
        currentCubeHP -= currentEncounter.sphereATK - currentEncounter.cubeDEF;
        if (currentCubeHP <= 0) { Debug.Log("Sphere wins"); NextBattle(); }
        else cubeHPtext.text = "HP:" + currentCubeHP.ToString();
    }

    void NextBattle()
    {
        if (encounters.Count >= 1)
        {
            encounterNumber = Random.Range(0, encounters.Count);
            currentEncounter = encounters[encounterNumber];
            encounters.Remove(currentEncounter);
            Debug.Log(currentEncounter.myNumber);
            InitBattle();
        }
        else { Debug.Log("Finished!"); infoText.text = "Finished!"; }

    
    }
}
