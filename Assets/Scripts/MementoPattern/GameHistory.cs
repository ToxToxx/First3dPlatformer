using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHistory : MonoBehaviour 
{
    
    public Stack<PlayerMemento> History { get; private set; }
    public GameHistory()
    {
        History = new Stack<PlayerMemento>();
    }

}
