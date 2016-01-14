using UnityEngine;
using System.Collections;

public class PlatformScript : CommandParent {

    public bool isActivatable = false;
    bool isFirstState = true;

    public string startingMaterialName;
    public PhysicMaterial startingMaterial;
    public string endingMaterialName;
    public PhysicMaterial endingMaterial;

    BoxCollider myBoxCollider;

    // Use this for initialization
    void Start () {
        myBoxCollider = GetComponent<BoxCollider>();

        myBoxCollider.material = startingMaterial;
        
        //default link color
        actionDescription = startingMaterialName;
	}

    public override void Activate()
    {
        if (isActivatable && inputLinked)
        {
            if (isFirstState)
            {
                myBoxCollider.material = endingMaterial;
                actionDescription = endingMaterialName;
            }
            else
            {
                myBoxCollider.material = startingMaterial;
                actionDescription = startingMaterialName;
            }
            isFirstState = !isFirstState;
        }
    }
}
