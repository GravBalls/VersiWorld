using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GravUIScript : MonoBehaviour {

    Image gravImage;
    GravityCommand gravControler = null;

    public Sprite iconUp;
    public Sprite iconRight;
    public Sprite iconDown;
    public Sprite iconLeft;

    // Use this for initialization
    void Start () {
        gravImage = GetComponentInChildren<Image>();
        gravControler = FindObjectOfType<GravityCommand>();
        if (gravControler == null) {
            gravImage.sprite = iconDown;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (gravControler != null) {
            switch (gravControler.currentDirection)
            {
                case GravityCommand.DIRECTION.UP:
                    gravImage.sprite = iconUp;
                    break;
                case GravityCommand.DIRECTION.RIGHT:
                    gravImage.sprite = iconRight;
                    break;
                case GravityCommand.DIRECTION.DOWN:
                    gravImage.sprite = iconDown;
                    break;
                case GravityCommand.DIRECTION.LEFT:
                    gravImage.sprite = iconLeft;
                    break;
            }
        }
	}
}
