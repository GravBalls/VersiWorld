using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GravUIScript : MonoBehaviour {

    Image gravImage;
    GravityController gravControler = null;

    public Sprite iconUp;
    public Sprite iconRight;
    public Sprite iconDown;
    public Sprite iconLeft;

    // Use this for initialization
    void Start () {
        gravImage = GetComponentInChildren<Image>();
        gravControler = FindObjectOfType<GravityController>();
        if (gravControler == null) {
            gravImage.sprite = iconDown;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (gravControler != null) {
            switch (gravControler.CurrentDirection)
            {
                case GravityController.Direction.UP:
                    gravImage.sprite = iconUp;
                    break;
                case GravityController.Direction.RIGHT:
                    gravImage.sprite = iconRight;
                    break;
                case GravityController.Direction.DOWN:
                    gravImage.sprite = iconDown;
                    break;
                case GravityController.Direction.LEFT:
                    gravImage.sprite = iconLeft;
                    break;
            }
        }
	}
}
