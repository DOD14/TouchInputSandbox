using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Encounter")]
public class EncounterObject : ScriptableObject {

    public int myNumber;

    public int cubeHP;
    public int cubeATK;
    public int cubeDEF;

    public int sphereHP;
    public int sphereATK;
    public int sphereDEF;

    public Material cubeColor;
    public Material sphereColor;

}
