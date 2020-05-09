﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerReserve : MonoBehaviour
{
    public StoneHandle Capstone, Stone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupGame(TakLogic.PlayerState player)
    {
        var stacks = GetComponentsInChildren<StoneStackHandle>();
        for (int stone = 0; stone < player.NumStones; ++stone)
        {
            int randomStackIndex = Random.Range(0, stacks.Length);
            var newStone = Instantiate(Stone);
            newStone.transform.rotation *= Quaternion.Euler(0, Random.Range(-20, 20), 0);
            stacks[randomStackIndex].AddStone(newStone);
        }
        for (int capstone = 0; capstone < player.NumCapstones; ++capstone)
        {
            int randomStackIndex;
            do
            {
                randomStackIndex = Random.Range(0, stacks.Length);
            } while (stacks[randomStackIndex].Stones.Last().StoneType!= TakLogic.StoneType.FlatStone);


            var newStone = Instantiate(Capstone);
            
            stacks[randomStackIndex].AddStone(newStone);
        }

        Stone.GetComponent<MeshRenderer>().enabled = false;
        Capstone.GetComponent<MeshRenderer>().enabled = false;
    }
}
