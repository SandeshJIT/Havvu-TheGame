using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelGrid1
{

    private Vector2Int foodGridPosition;
    private GameObject foodGameObject;
    private int width;
    private int height;
    private Snake1 Snake1;

    public LevelGrid1(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public void Setup(Snake1 Snake1)
    {
        this.Snake1 = Snake1;

        SpawnFood();
    }

    private void SpawnFood()
    {
        do
        {
            foodGridPosition = new Vector2Int(Random.Range(0, width), Random.Range(2, height));
        } while (Snake1.FullSize().IndexOf(foodGridPosition) != -1);

        foodGameObject = new GameObject("Food", typeof(SpriteRenderer));
        foodGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.i.foodSprite;
        foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y);
    }

    public bool Snake1Moved(Vector2Int Snake1GridPosition)
    {
        if (Snake1GridPosition == foodGridPosition)
        {
            Object.Destroy(foodGameObject);
            SpawnFood();
            return true;
        }
        else
        {
            return false;
        }

    }
    public bool Validate(Vector2Int gridPosition)
    {
        if (gridPosition.x < 0 || gridPosition.x > 18)
        {
            return true;
        }
        if (gridPosition.y < 0 || gridPosition.y > 20)
        {
            return true;
        }
        return false;
    }

}
