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

    // Use this for initialization
    void Start () {
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
            textComponents[i].text = "Nothing";
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if (redLink != null)
        {
            redButtonText.text = redLink.actionDescription;
        }
	}
}
