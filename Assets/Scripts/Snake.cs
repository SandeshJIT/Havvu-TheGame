using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2Int gridPosition,gridMoveDirection;
    private float moveTimer;
    private float moveTimerMax;

   private void Awake()
    {
        gridPosition = new Vector2Int(25, 25);
        gridMoveDirection = new Vector2Int(1, 0);
        moveTimerMax = 1f;
        moveTimer = moveTimerMax;

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            gridPosition.y += 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            gridPosition.y -= 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gridPosition.x -= 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gridPosition.x += 1;
        }
        moveTimer += Time.deltaTime;
        if(moveTimer >= moveTimerMax)
        {
            gridPosition += gridMoveDirection;
            moveTimer += moveTimerMax;
        }
        transform.position = new Vector3(gridPosition.x, gridPosition.y);
    }

}
