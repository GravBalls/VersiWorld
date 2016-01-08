using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public interface Command
{
    void Execute(Image newIcon, Image oldIcon);
}
