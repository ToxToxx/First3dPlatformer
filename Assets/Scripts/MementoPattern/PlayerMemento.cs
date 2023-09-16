using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMemento
{
    public Vector3 PlayerPoisiton { get; private set; }

    public PlayerMemento(Vector3 playerPosition)
    {
        this.PlayerPoisiton = playerPosition;
    }
}
