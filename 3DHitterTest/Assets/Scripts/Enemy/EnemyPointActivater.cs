using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPointActivater : MonoBehaviour
{
    public List<GameObject> enemys;

    public void EnableEnemys()
    {
        if(enemys[0] != null)
        {
            foreach(GameObject enemy in enemys)
            {
               enemy.SetActive(true);
            }
        }
    }
}
