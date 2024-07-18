using System.Collections.Generic;
using UnityEngine;

public class EnemyChecker : MonoBehaviour
{
    public static EnemyChecker Instance { get; private set; }

    [SerializeField] List<GameObject> activeEnemies = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddEnemy(GameObject enemy)
    {
        if (!activeEnemies.Contains(enemy))
        {
            activeEnemies.Add(enemy);
        }
    }

    public void RemoveEnemy(GameObject enemy)
    {
        if (activeEnemies.Contains(enemy))
        {
            activeEnemies.Remove(enemy);
        }
    }

    public bool AreEnemiesActive()
    {
        return activeEnemies.Count > 0;
    }
}
