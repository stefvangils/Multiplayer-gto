using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitFactory : MonoBehaviour
{
    public Unit Prototype;
    public Map Map;
    public Text x;
    public Text y;


    public List<ResourceCost> Costs;
    
    // Temporary until we figure out a better way to decide where to spawn.
    private Vector2Int SpawnCoordinate;

    public void SpawnUnit()
    {
        SpawnCoordinate.x = Convert.ToInt32(x.text);
        SpawnCoordinate.y = Convert.ToInt32(y.text);
        bool canAfford = true;
        for (int i = 0; i < Costs.Count; i++)
        {
            if (!Costs[i].CanAfford())
            {
                canAfford = false;
            }
        }
        
        
        if (canAfford)
        {
            for (int i = 0; i < Costs.Count; i++)
            {
                Costs[i].Pay();
            }

            Unit newUnit = Instantiate(Prototype);
            Cell cell = Map.GetCell(SpawnCoordinate.x, SpawnCoordinate.y);
        
            newUnit.transform.SetParent(cell.transform, false);
        }
        else
        {
            Debug.Log("Not enough resources!");
        }

    }

    [System.Serializable]
    public class ResourceCost
    {
        public Resource Resource;
        public int Cost;

        public bool CanAfford()
        {
            return Resource.CanAfford(Cost);
        }

        public void Pay()
        {
            Resource.RemoveAmount(Cost);
        }
        
    }
}