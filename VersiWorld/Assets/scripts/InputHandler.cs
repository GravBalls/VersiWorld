using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputHandler : MonoBehaviour
{
    public Command buttonX = new Gravity;
    public Command buttonY = null;

    public Image currentImage;

    void Update()
    {
        Command command = HandleInput();
        if(command != null)
        {
            command.Execute(gameObject);
        }
    }
    public Command HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            return buttonX;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            return buttonY;
        }

        else return null;
    }


}
