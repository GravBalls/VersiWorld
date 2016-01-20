using UnityEngine;
using System.Collections;

public class MaterialSwapScript : CommandParent {

    public bool isActivatable = false;
    bool isFirstState = true;

    public string startingMaterialName;
    public PhysicMaterial startingMaterial;
    public Color startingColor;

    public string endingMaterialName;
    public PhysicMaterial endingMaterial;
    public Color endingColor;

    BoxCollider myBoxCollider;
    Material myMaterial;

    // Use this for initialization
    void Start () {
        myBoxCollider = GetComponent<BoxCollider>();

        myBoxCollider.material = startingMaterial;
        
        //default link color
        actionDescription = startingMaterialName;

        myMaterial = GetComponent<Renderer>().material;
        myMaterial.color = startingColor;
	}



    public override void Activate()
    {
        if (isActivatable && inputLinked)
        {
            if (isFirstState)
            {
                myBoxCollider.material = endingMaterial;
                actionDescription = endingMaterialName;
                myMaterial.color = endingColor;
            }
            else
            {
                myBoxCollider.material = startingMaterial;
                actionDescription = startingMaterialName;
                myMaterial.color = startingColor;
            }
            isFirstState = !isFirstState;
        }
    }
}
