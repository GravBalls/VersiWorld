using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class TestInputHandler : MonoBehaviour {

    public GameObject blueButtonItem;
    CommandParent blueButtonCommand;
    KeyCode blueButton = KeyCode.Q;

    // Use this for initialization
    void Start () {
        blueButtonCommand = blueButtonItem.GetComponent<CommandParent>();
        blueButtonCommand.LinkInput(Color.blue);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(blueButton))
        {
            blueButtonCommand.Activate();
        }
	}
}
