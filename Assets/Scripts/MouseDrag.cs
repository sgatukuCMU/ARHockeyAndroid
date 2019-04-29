﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    Rigidbody r;
    PhotonView view;
    public Camera playerCam;

    private void Start()
    {
        r = transform.GetComponent<Rigidbody>();
        view = GetComponent<PhotonView>();
        Debug.Log("VIEW + ", view);
    }

    private void Update()
    {
        Debug.Log("POSITION  + " + transform.position);
    }

    void OnMouseDown()
    {
      if (view.isMine)
        {
            Debug.Log(Input.mousePosition);
            mZCoord = (playerCam.WorldToScreenPoint(gameObject.transform.position).z);
            // Store offset = gameobject world pos - mouse world pos
            mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        }
    }



    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;
        // z coordinate of game object on screen
        mousePoint.z = mZCoord;
        // Convert it to world points
        return playerCam.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
       if (view.isMine)
       {
            //700 - 200
            // (A) 250 - (B) 80 -->(C)0 - ((D)-7)
            //X falls between A and B, and you would like Y to fall between C and D, you can apply the following linear transform
            //Y = (X-A)/(B-A) * (D-C) + C
            var newPos = GetMouseAsWorldPoint() + mOffset;
            newPos.y = 0.85f;
            newPos.z = (Input.mousePosition.y - 700) / (200 - 700) * (-0.65f - (0)) + (0);
            if (newPos.z > 0)
            {
                newPos.z = 0;
            }
            if (newPos.z < -0.6)
            {
                newPos.z = -0.6f;
            }
            //1060 - 13
            // (A) 1060 - (B) 13 -->(C)-0.45 - ((D)0.45)
            //X falls between A and B, and you would like Y to fall between C and D, you can apply the following linear transform
            //Y = (X-A)/(B-A) * (D-C) + C
            //newPos.x = (Input.mousePosition.x - 1060) / (13 - 1060) * (0.45f + 0.45f) - 0.45f;
            newPos.x = (Input.mousePosition.x - 1060) / (13 - 1060) * (-0.4f - 0.4f) + 0.4f;
            if (newPos.x > 0.4)
            {
                newPos.x = 0.4f;
            }
            if (newPos.x < -0.4)
            {
                newPos.x = -0.4f;
            }

            Debug.Log("*****************88 " + newPos + "bbbbb " + Input.mousePosition);
            /*
            if (newPos.x > 9)
            {
                newPos.x = 9f;
            }
            if (newPos.x < -9)
            {
                newPos.x = -9f;
            }
            if (newPos.z < 0)
            {
                newPos.z = 0f;
            }*/
            transform.position = newPos;
            r.velocity = new Vector3(0f, 0f, 0f);
       }
    }
}
