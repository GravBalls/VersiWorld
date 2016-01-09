using UnityEngine;
using System.Collections;

public class CommandParent : MonoBehaviour {

    protected Color linkColor = Color.gray;
    protected bool inputLinked = false;

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
