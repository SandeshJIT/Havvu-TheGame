
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameHandler1 : MonoBehaviour
{

    [SerializeField] private Snake1 Snake1;

    private LevelGrid1 LevelGrid1;

    private void Start()
    {
        Timer t = new Timer();

        LevelGrid1 = new LevelGrid1(17, 17);

        Snake1.Setup(LevelGrid1);
        LevelGrid1.Setup(Snake1);
    }


}
