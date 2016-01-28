using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class TestInputHandler : MonoBehaviour
{
    /*
    down and dirty implementation, could refactor this into more pretty if we need/want
    */

    public GameObject blueButtonItem = null;
    public GameObject redButtonItem = null;
    public GameObject yellowButtonItem = null;
    public GameObject greenButtonItem = null;


    CommandParent blueButtonCommand;
    CommandParent redButtonCommand;
    CommandParent yellowButtonCommand;
    CommandParent greenButtonCommand;

    string blueButton = "X";
    string redButton = "B";
    string yellowButton = "Y";
    string greenButton = "A";

    public GameObject UILinkHandler = null;
    UIScript UIHandler = null;

    // Use this for initialization
    void Start()
    {
        if (UILinkHandler != null)
        {
            UIHandler = UILinkHandler.GetComponent<UIScript>();
        }

        if (blueButtonItem != null)
        {
            blueButtonCommand = blueButtonItem.GetComponent<CommandParent>();
            blueButtonCommand.LinkInput(Color.blue);
            if (UIHandler != null)
            {
                UIHandler.linkButton(UIScript.UI_BUTTON.BUTTON_BLUE, blueButtonCommand);
            }
        }



        if (redButtonItem != null)
        {
            redButtonCommand = redButtonItem.GetComponent<CommandParent>();
            redButtonCommand.LinkInput(Color.red);
            if (UIHandler != null)
            {
                UIHandler.linkButton(UIScript.UI_BUTTON.BUTTON_RED, redButtonCommand);
            }
        }



        if (yellowButtonItem != null)
        {
            yellowButtonCommand = redButtonItem.GetComponent<CommandParent>();
            yellowButtonCommand.LinkInput(Color.yellow);
            if (UIHandler != null)
            {
                UIHandler.linkButton(UIScript.UI_BUTTON.BUTTON_YELLOW, yellowButtonCommand);
            }
        }



        if (greenButtonItem != null)
        {
            greenButtonCommand = redButtonItem.GetComponent<CommandParent>();
            greenButtonCommand.LinkInput(Color.green);
            if (UIHandler != null)
            {
                UIHandler.linkButton(UIScript.UI_BUTTON.BUTTON_GREEN, greenButtonCommand);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (blueButtonCommand != null && Input.GetButtonDown(blueButton))
        {
            blueButtonCommand.Activate();
        }
        if (redButtonCommand != null && Input.GetButtonDown(redButton))
        {
            redButtonCommand.Activate();
        }
        if (yellowButtonCommand != null && Input.GetButtonDown(yellowButton))
        {
            yellowButtonCommand.Activate();
        }
        if (greenButtonCommand != null && Input.GetButtonDown(greenButton))
        {
            greenButtonCommand.Activate();
        }
    }
}
