using UnityEngine;
using System.Collections;
using System;

public class MagnetController : MonoBehaviour 
{
    public GameObject top;
    public GameObject bottom;
    public GameObject left;
    public GameObject right;
    public float moveSpeed;

    Transform currentMagnet;

    void Start()
    {
        ActivateMagnet(top);
    }

    void Update()
    {
        if (currentMagnet != null)
        {
            if(currentMagnet == top.transform || currentMagnet == bottom.transform)
            {
                int direction = 1;
                if(currentMagnet == bottom.transform)
                {
                    direction *= -1;
                }
                currentMagnet.Translate(Input.GetAxis("Horizontal") * (Vector3.right * direction) * moveSpeed * Time.deltaTime);
            }
        }

        HandleInput();
    }

    private void HandleInput()
    {
        if(Input.GetKeyUp(KeyCode.I) && currentMagnet != top.transform)
        {
            ActivateMagnet(top);
        }
        else if(Input.GetKeyUp(KeyCode.K) && currentMagnet != bottom.transform)
        {
            ActivateMagnet(bottom);
        }
        else if(Input.GetKeyDown(KeyCode.J) && currentMagnet != left.transform)
        {
            ActivateMagnet(left);
        }
        else if (Input.GetKeyDown(KeyCode.L) && currentMagnet != right.transform)
        {
            ActivateMagnet(right);
        }
    }

    void ActivateMagnet(GameObject magnetToActivate)
    {
        if (currentMagnet != null)
        {
            currentMagnet.GetComponent<Magnet>().Activated = false;
        }
        magnetToActivate.GetComponent<Magnet>().Activated = true;
        currentMagnet = magnetToActivate.transform;
    }
}
