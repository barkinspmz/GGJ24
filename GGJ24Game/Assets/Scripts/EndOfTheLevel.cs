using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfTheLevel : MonoBehaviour
{
    public static EndOfTheLevel Instance;

    public delegate void EndOfTheLevelDelegate();
    public event EndOfTheLevelDelegate endOfLevel;
    private void Awake()
    {
        Instance = this;
    }

    public void EndLevelEvents()
    {
        if (endOfLevel != null)
        {
            //This can lock the player movement and occur the other events.
            endOfLevel();
            Debug.Log("Wprlll");
        }
    }

}
