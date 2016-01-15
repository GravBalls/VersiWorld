using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class TestInputHandler : MonoBehaviour {

    public GameObject blueButtonItem;
    CommandParent blueButtonCommand;
    KeyCode blueButton = KeyCode.Q;

    public GameObject UILinkHandler;
    UIScript UIHandler;

    // Use this for initialization
    void Start () {
        UIHandler = UILinkHandler.GetComponent<UIScript>();

        blueButtonCommand = blueButtonItem.GetComponent<CommandParent>();
        blueButtonCommand.LinkInput(Color.blue);
        UIHandler.linkButton(UIScript.UI_BUTTON.BUTTON_BLUE, blueButtonCommand);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(blueButton))
        {
            blueButtonCommand.Activate();
        }
	}
}
