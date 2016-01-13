using UnityEngine;
using System.Collections;

public class CommandParent : MonoBehaviour {

    protected Color linkColor = Color.gray;
    protected bool inputLinked = false;

    //this is a description of the action that Activate preforms for the UI to read. (note: this text can change mid exicution and the UI should expect and handle it)
    private string _actDescipt = "Does Nothing";
    public string actionDescription
    {
        get
        {
            return _actDescipt;
        }

        protected set
        {
            _actDescipt = value;
        }

    }

    //have this return some form of function pointer to Activate so Input can only call activate if it has linked to it
    public virtual void LinkInput(Color in_inputColor)
    {
        if (!inputLinked)
        {
            inputLinked = true;
            linkColor = in_inputColor;
        }
    }

    //this is overridden to do whatever the action is
    public virtual void Activate() { /* do nothing */ }

}
