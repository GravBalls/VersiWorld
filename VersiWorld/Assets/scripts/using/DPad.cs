using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DPad : MonoBehaviour 
{
    public GravityController gravControl;
    public bool hideDpad = false;

    List<Image> images;
    Direction currentDirection;

    enum Direction
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    void Awake()
    {
        GameObject dPad = GameObject.FindWithTag("DPad");
        images = new List<Image>(dPad.GetComponentsInChildren<Image>());
        gravControl = GameObject.FindObjectOfType<GravityController>();
        currentDirection = Direction.DOWN;
        gravControl.ChangeGravityDirection(GravityController.Direction.DOWN);

        if (hideDpad)
        {
            ChangeAlpha(images[0], 0);
            ChangeAlpha(images[1], 0);
            ChangeAlpha(images[2], 0);
            ChangeAlpha(images[3], 0);
        }
    }
	void Update()
    {
        float up = Input.GetAxis("UP/DOWN");
        float right = Input.GetAxis("LEFT/RIGHT");
        float upKeys = Input.GetAxis("Vertical");
        float rightKeys = Input.GetAxis("Horizontal");
        if (Mathf.Abs(up) > 0 || Mathf.Abs(upKeys) > 0)
        {
            if((up > 0 || upKeys > 0) && currentDirection != Direction.UP)
            {
                ChangeDirection(Direction.UP);
                gravControl.ChangeGravityDirection(GravityController.Direction.UP);
            }
            else if ((up < 0 || upKeys < 0) && currentDirection != Direction.DOWN)
            {
                ChangeDirection(Direction.DOWN);
                gravControl.ChangeGravityDirection(GravityController.Direction.DOWN);
            }
        }
        if (Mathf.Abs(right) > 0 || Mathf.Abs(rightKeys) > 0)
        {
            if ((right > 0 || rightKeys > 0) && currentDirection != Direction.RIGHT)
            {
                ChangeDirection(Direction.RIGHT);
                gravControl.ChangeGravityDirection(GravityController.Direction.RIGHT);
            }
            else if ((right < 0 || rightKeys < 0) && currentDirection != Direction.LEFT)
            {
                ChangeDirection(Direction.LEFT);
                gravControl.ChangeGravityDirection(GravityController.Direction.LEFT);
            }
        }

    }

    void ChangeDirection(Direction newDirection)
    {
        if (!hideDpad)
        {
            ChangeAlpha(images[(int)currentDirection], .5f);
            ChangeAlpha(images[(int)newDirection], 1);
        }
        currentDirection = newDirection;
    }

    void ChangeAlpha(Image image, float alphaValue)
    {
        
        Color c = image.color;
        c.a = alphaValue;
        image.color = c;
    }

}
