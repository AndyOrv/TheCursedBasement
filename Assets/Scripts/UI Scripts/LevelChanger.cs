using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
-- Author: Andrew Orvis
-- Description: Simple code to be attached to either buttons to tirgger points to speak to the game mamger and change scenes
 */



public class LevelChanger : MonoBehaviour
{
    [SerializeField] int from;
    [SerializeField] int to;

    public void LevelChange()
    {
        FindObjectOfType<GameManager>().LoadGame((SceneIndexes)from, (SceneIndexes)to);
    }

    //this is used for map triggers where the player will enter an end zone and move to the next level
    public void OnTriggerEnter(Collider other)
    {
        LevelChange();
    }
}
