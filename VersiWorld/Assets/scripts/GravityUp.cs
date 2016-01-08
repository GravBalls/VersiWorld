using UnityEngine;
using UnityEngine.UI;
using System;

public class Gravity : MonoBehaviour
{
    
    
    public void Execute(Image newIcon, Image oldIcon)
    {
        oldIcon.color = new Color(oldIcon.color.r, oldIcon.color.g, oldIcon.color.b, 127);
        newIcon.color = new Color(newIcon.color.r, newIcon.color.g, newIcon.color.b, 255);

    }
}
