using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class TestInputHandler : MonoBehaviour
{
    /*
    down and dirty implementation, could refactor this into more pretty if we need/want
    */

    public GameObject blueButtonItem;
    public GameObject redButtonItem;
    public GameObject yellowButtonItem;
    public GameObject greenButtonItem;


    CommandParent blueButtonCommand;
    CommandParent redButtonCommand;
    CommandParent yellowButtonCommand;
    CommandParent greenButtonCommand;

    KeyCode blueButton = KeyCode.LeftArrow;
    KeyCode redButton = KeyCode.RightArrow;
    KeyCode yellowButton = KeyCode.UpArrow;
    KeyCode greenButton = KeyCode.DownArrow;

    public GameObject UILinkHandler;
    UIScript UIHandler;
    
    // Use this for initialization
    void Start () {
        UIHandler = UILinkHandler.GetComponent<UIScript>();


        blueButtonCommand = blueButtonItem.GetComponent<CommandParent>();
        blueButtonCommand.LinkInput(Color.blue);
        UIHandler.linkButton(UIScript.UI_BUTTON.BUTTON_BLUE, blueButtonCommand);

        redButtonCommand = redButtonItem.GetComponent<CommandParent>();
        redButtonCommand.LinkInput(Color.red);
        UIHandler.linkButton(UIScript.UI_BUTTON.BUTTON_RED, redButtonCommand);

        yellowButtonCommand = redButtonItem.GetComponent<CommandParent>();
        yellowButtonCommand.LinkInput(Color.yellow);
        UIHandler.linkButton(UIScript.UI_BUTTON.BUTTON_YELLOW, yellowButtonCommand);

        greenButtonCommand = redButtonItem.GetComponent<CommandParent>();
        greenButtonCommand.LinkInput(Color.green);
        UIHandler.linkButton(UIScript.UI_BUTTON.BUTTON_GREEN, greenButtonCommand);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(blueButton))
        {
            blueButtonCommand.Activate();
        }
        if (Input.GetKeyDown(redButton))
        {
            redButtonCommand.Activate();
        }
        if (Input.GetKeyDown(yellowButton))
        {
            yellowButtonCommand.Activate();
        }
        if (Input.GetKeyDown(greenButton))
        {
            greenButtonCommand.Activate();
        }
    }
}
