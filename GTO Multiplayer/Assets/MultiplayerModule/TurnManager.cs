using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {
    public List<GameObject> players;
    
	// Use this for initialization
    public void NextTurn()
    {
        if(players[0].activeSelf)
        {
            
            players[1].SetActive(true);
            players[0].SetActive(false);
        }
        else
        {
            
            players[0].SetActive(true);
            players[1].SetActive(false);
        }
        

    }
	// Update is called once per frame
}
