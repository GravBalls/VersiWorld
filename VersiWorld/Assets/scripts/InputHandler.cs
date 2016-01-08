using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputHandler : MonoBehaviour
{
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
                }
                else
                {
                    //set grav to right
                    grav.x = value;
                    grav.y = 0;
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
                }
                else
                {
                    //set grav to down
                    grav.y = -value;
                    grav.x = 0;
                }
            }

            Physics.gravity = grav;
        }
        
        return buttonX;
    }

    }
