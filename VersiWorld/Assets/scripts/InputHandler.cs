using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputHandler : MonoBehaviour
{
    public Image up;
    public Image right;
    public Image down;
    public Image left;

    public Command buttonX = null;
    public Command buttonY = null;

    public Image currentImage;

    void Update()
    {
        Command command = HandleInput();
        if(command != null)
        {
            //command.Execute(gameObject);
        }
    }
    public Command HandleInput()
    {
        //rotate grav clockwise
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Vector3 grav = Physics.gravity;
            //is gravity now pointing up/down
            if (Mathf.Approximately(grav.x, 0))
            {
                float value = grav.y;
                //is gravity pointing down
                if (value < 0)
                {
                    //set grav to left
                    grav.x = value;
                    grav.y = 0;
                    UpdateColor(down, left);
                }
                else
                {
                    //set grav to right
                    grav.x = value;
                    grav.y = 0;
                    UpdateColor(up, right);
                }
            }
            else
            {
                float value = grav.x;
                //is gravity pointing left
                if (value < 0)
                {
                    //set grav to up
                    grav.y = -value;
                    grav.x = 0;
                    UpdateColor(left, up);
                }
                else
                {
                    //set grav to down
                    grav.y = -value;
                    grav.x = 0;
                    UpdateColor(right, down);
                }
            }

            Physics.gravity = grav;
        }
        
        return buttonX;
    }

    void UpdateColor(Image old, Image newby)
    {
        Color c = old.color;
        c.a = 0;
        old.color = c;
        //old.color = new Color(old.color.r, old.color.g, old.color.b, 127);
        c = newby.color;
        c.a = 255;
        newby.color = c;
        //newby.color = new Color(newby.color.r, newby.color.g, newby.color.b, 255);
    }

    }
