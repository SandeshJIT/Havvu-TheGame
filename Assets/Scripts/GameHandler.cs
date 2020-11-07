
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameHandler : MonoBehaviour {

    [SerializeField] private Snake snake;

    private LevelGrid levelGrid;

    private void Start() {
        Timer t = new Timer();

        levelGrid = new LevelGrid(35, 24);

        snake.Setup(levelGrid);
        levelGrid.Setup(snake);
    }
  

}
