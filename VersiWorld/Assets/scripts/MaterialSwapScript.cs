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
    Collider myCollider;
    Material myMaterial;

    // Use this for initialization
    void Start () {
        myCollider = GetComponent<Collider>();

        myCollider.material = startingMaterial;
        
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
                myCollider.material = endingMaterial;
                actionDescription = endingMaterialName;
                myMaterial.color = endingColor;
            }
            else
            {
                myCollider.material = startingMaterial;
                actionDescription = startingMaterialName;
                myMaterial.color = startingColor;
            }
            isFirstState = !isFirstState;
        }
    }
}
