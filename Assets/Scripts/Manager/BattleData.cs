using System.Collections.Generic;
using UnityEngine;

public class BattleData : Singleton<BattleData>
{
     public GameObject playerPrefab;

    public List<GameObject> enemyPrefabs = new();

    public void Clear()
    {
        playerPrefab = null;
        enemyPrefabs.Clear();
    }
}