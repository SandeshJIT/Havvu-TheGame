

using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;



public class Snake1 : MonoBehaviour
{
    private enum State
    {
        Alive,
        Dead
    }
    private State state;
    private int score;
    private Vector2Int gridMoveDirection;
    private Vector2Int gridPosition;
    private float gridMoveTimer;
    private float gridMoveTimerMax;
    private LevelGrid1 LevelGrid1;
    private int Snake1BodySize;
    private List<Vector2Int> Snake1MovePositionList;
    public AudioClip eatSound, deathSound, winSound;

    public void Setup(LevelGrid1 LevelGrid1)
    {
        this.LevelGrid1 = LevelGrid1;
    }

    private void Awake()
    {
        gridPosition = new Vector2Int(10, 10);
        gridMoveTimerMax = 0.1f;
        gridMoveTimer = gridMoveTimerMax;
        gridMoveDirection = new Vector2Int(1, 0);
        Snake1BodySize = 20;
        state = State.Alive;
        score = 0;
        Snake1MovePositionList = new List<Vector2Int>();


    }

    private void Update()
    {
        switch (state)
        {
            case State.Alive:
                HandleInput();
                HandleGridMovement();
                break;
            case State.Dead:
                break;
        }
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (gridMoveDirection.y != -1)
            {
                gridMoveDirection.x = 0;
                gridMoveDirection.y = +1;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (gridMoveDirection.y != +1)
            {
                gridMoveDirection.x = 0;
                gridMoveDirection.y = -1;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (gridMoveDirection.x != +1)
            {
                gridMoveDirection.x = -1;
                gridMoveDirection.y = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (gridMoveDirection.x != -1)
            {
                gridMoveDirection.x = +1;
                gridMoveDirection.y = 0;
            }
        }
    }

    private void HandleGridMovement()
    {
        gridMoveTimer += Time.deltaTime;
        if (gridMoveTimer >= gridMoveTimerMax)
        {
            gridMoveTimer -= gridMoveTimerMax;
            Snake1MovePositionList.Insert(0, gridPosition);
            gridPosition += gridMoveDirection;
            bool checkBorder = LevelGrid1.Validate(gridPosition);
            if (checkBorder)
            {
                state = State.Dead;
            }
            bool res = LevelGrid1.Snake1Moved(gridPosition);
            if (res)
            {
                AudioSource.PlayClipAtPoint(eatSound, transform.position, 1f);
                Snake1BodySize--;
                score++;
                if (Snake1BodySize == 0)
                {
                    Camera.main.GetComponent<AudioSource>().Stop();
                    AudioSource.PlayClipAtPoint(winSound, transform.position, 1f);
               
                    state = State.Dead;
                }
                Snake1MovePositionList.RemoveAt(Snake1MovePositionList.Count - 1);
            }




            if (Snake1MovePositionList.Count >= Snake1BodySize + 1)
            {
                Snake1MovePositionList.RemoveAt(Snake1MovePositionList.Count - 1);
            }
            foreach (Vector2Int vk in Snake1MovePositionList)
            {
                if (gridPosition == vk)
                {

                    Camera.main.GetComponent<AudioSource>().Stop();
                    AudioSource.PlayClipAtPoint(deathSound, transform.position, 1f);
                 
                    state = State.Dead;
                }
            }
            for (int i = 0; i < Snake1MovePositionList.Count; i++)
            {
                Vector2Int Snake1MovePosition = Snake1MovePositionList[i];
                //World_Sprite worldSprite = World_Sprite.Create(new Vector3(Snake1MovePosition.x , Snake1MovePosition.y), Vector3.one *.5f , Color.green);
                // FunctionTimer.Create(worldSprite.DestroySelf, gridMoveTimerMax);
                GameObject sGameObject = new GameObject("S", typeof(SpriteRenderer));
                sGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.i.sSprite;
                sGameObject.transform.position = new Vector3(Snake1MovePosition.x, Snake1MovePosition.y);
                Object.Destroy(sGameObject, gridMoveTimerMax);
            }

            transform.position = new Vector3(gridPosition.x, gridPosition.y);
            transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridMoveDirection));




        }
    }

    private float GetAngleFromVector(Vector2Int dir)
    {
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }

    public Vector2Int GetGridPosition()
    {
        return gridPosition;
    }
    public List<Vector2Int> FullSize()
    {
        List<Vector2Int> gridPositionList = new List<Vector2Int>() { gridPosition };
        gridPositionList.AddRange(Snake1MovePositionList);
        return gridPositionList;
    }







}

