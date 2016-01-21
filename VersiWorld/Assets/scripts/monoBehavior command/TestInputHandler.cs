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

    public GameObject UILinkHandler;
    UIScript UIHandler;

    // Use this for initialization
    void Start()
    {
        UIHandler = UILinkHandler.GetComponent<UIScript>();


        
        if (blueButtonItem != null)
        {
            blueButtonCommand = blueButtonItem.GetComponent<CommandParent>();
            blueButtonCommand.LinkInput(Color.blue);
            UIHandler.linkButton(UIScript.UI_BUTTON.BUTTON_BLUE, blueButtonCommand);
        }


        
        if (redButtonItem != null)
        {
            redButtonCommand = redButtonItem.GetComponent<CommandParent>();
            redButtonCommand.LinkInput(Color.red);
            UIHandler.linkButton(UIScript.UI_BUTTON.BUTTON_RED, redButtonCommand);
        }


       
        if (yellowButtonItem != null)
        {
            yellowButtonCommand = redButtonItem.GetComponent<CommandParent>();
            yellowButtonCommand.LinkInput(Color.yellow);
            UIHandler.linkButton(UIScript.UI_BUTTON.BUTTON_YELLOW, yellowButtonCommand);
        }


        
        if (greenButtonItem != null)
        {
            greenButtonCommand = redButtonItem.GetComponent<CommandParent>();
            greenButtonCommand.LinkInput(Color.green);
            UIHandler.linkButton(UIScript.UI_BUTTON.BUTTON_GREEN, greenButtonCommand);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (blueButtonCommand != null && Input.GetAxis(blueButton) > 0)
        {
            blueButtonCommand.Activate();
        }
        if (redButtonCommand != null && Input.GetAxis(redButton) > 0)
        {
            redButtonCommand.Activate();
        }
        if (yellowButtonCommand != null && Input.GetAxis(yellowButton) > 0)
        {
            yellowButtonCommand.Activate();
        }
        if (greenButtonCommand != null && Input.GetAxis(greenButton) > 0)
        {
            greenButtonCommand.Activate();
        }
    }
}
