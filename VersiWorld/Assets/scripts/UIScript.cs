using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIScript : MonoBehaviour {

    Text redButtonText;
    CommandParent redLink = null;
    Text blueButtonText;
    CommandParent blueLink = null;
    Text greenButtonText;
    CommandParent greenLink = null;
    Text yellowButtonText;
    CommandParent yellowLink = null;

    static string defaultText = "Nothing";
    [HideInInspector]
    public bool hasStarted = false;

    // Use this for initialization
    public void Start () {
        if (hasStarted)
        {
            return;
        }

        Text[] textComponents = GetComponentsInChildren<Text>();
        for (int i = 0; i < textComponents.Length; i++) {
            switch (textComponents[i].text[0]) {
                case 'R':
                    redButtonText = textComponents[i];
                    break;
                case 'B':
                    blueButtonText = textComponents[i];
                    break;
                case 'G':
                    greenButtonText = textComponents[i];
                    break;
                case 'Y':
                    yellowButtonText = textComponents[i];
                    break;
                default:
                    Debug.Log("unknow textcomponent found");
                    break;
            }
            textComponents[i].text = defaultText;
        }

        hasStarted = true;
	}
	
	// Update is called once per frame
	void Update () {
	    if (redLink != null)
        {
            redButtonText.text = redLink.actionDescription;
        }
        if (greenLink != null)
        {
            greenButtonText.text = greenLink.actionDescription;
        }
        if (blueLink != null)
        {
            blueButtonText.text = blueLink.actionDescription;
        }
        if (yellowLink != null)
        {
            yellowButtonText.text = yellowLink.actionDescription;
        }
    }

    public enum UI_BUTTON
    {
        BUTTON_RED,
        BUTTON_GREEN,
        BUTTON_BLUE,
        BUTTON_YELLOW
    }

    //ignoring the second parameter unlinks the given button
    public void linkButton(UI_BUTTON linkedButton, CommandParent linkedObject = null) {
        if (linkedObject == null)
        {
            switch (linkedButton)
            {
                case UI_BUTTON.BUTTON_RED:
                    redLink = null;
                    redButtonText.text = defaultText;
                    break;
                case UI_BUTTON.BUTTON_GREEN:
                    greenLink = null;
                    greenButtonText.text = defaultText;
                    break;
                case UI_BUTTON.BUTTON_BLUE:
                    blueLink = null;
                    blueButtonText.text = defaultText;
                    break;
                case UI_BUTTON.BUTTON_YELLOW:
                    yellowLink = null;
                    yellowButtonText.text = defaultText;
                    break;
            }
        }
        else
        {
            switch (linkedButton)
            {
                case UI_BUTTON.BUTTON_RED:
                    redLink = linkedObject;
                    redButtonText.text = linkedObject.actionDescription;
                    break;
                case UI_BUTTON.BUTTON_GREEN:
                    greenLink = linkedObject;
                    greenButtonText.text = linkedObject.actionDescription;
                    break;
                case UI_BUTTON.BUTTON_BLUE:
                    blueLink = linkedObject;
                    blueButtonText.text = linkedObject.actionDescription;
                    break;
                case UI_BUTTON.BUTTON_YELLOW:
                    yellowLink = linkedObject;
                    yellowButtonText.text = linkedObject.actionDescription;
                    break;
            }
        }
    }
}
