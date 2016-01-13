using UnityEngine;
using System.Collections;

public class CommandChildExample : CommandParent {

    public bool isActivatable = false;
    bool isStartState = true;
    public Sprite startState;
    public Sprite secondState;

    SpriteRenderer mySpriteRenderer;

	// Use this for initialization
	void Start () {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        mySpriteRenderer.color = linkColor;
        mySpriteRenderer.sprite = startState;
        actionDescription = "Change Direction";
	}

    //this is overrided mainly so it can change it's color when linked
    public override void LinkInput(Color in_inputColor)
    {
        base.LinkInput(in_inputColor);

        mySpriteRenderer.color = linkColor;
    }

    //this is where most of the work is done, many objects should work well with switching between two (or more?) states
    public override void Activate()
    {
        if (isActivatable && inputLinked)
        {
            if (isStartState)
            {
                mySpriteRenderer.sprite = secondState;
            } 
            else
            {
                mySpriteRenderer.sprite = startState;
            }
            isStartState = !isStartState;
        }
    }
}
