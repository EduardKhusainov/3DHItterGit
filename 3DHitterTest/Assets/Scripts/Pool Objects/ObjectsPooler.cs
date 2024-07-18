using System.Collections.Generic;
using UnityEngine;

public class ObjectsPooler : MonoBehaviour
{
    public GameObject objectPrefab;
    public int poolSize = 10;
    [SerializeField] Transform bulletsContainer;
    private List<Bullet> pool;

    void Start()
    {
       CreatePool();
    }

    public Bullet GetBullet()
    {
        foreach (Bullet bullet in pool)
        {
            if (!bullet.gameObject.activeInHierarchy)
            {
                bullet.gameObject.SetActive(true);
                return bullet;
            }
        }

        // Если нет доступных пуль, создаем новую
        GameObject obj = Instantiate(objectPrefab);
        Bullet newBullet = obj.GetComponent<Bullet>();
        pool.Add(newBullet);
        return newBullet;
    }

     public void CreatePool()
    {
        pool = new List<Bullet>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectPrefab, bulletsContainer); // Устанавливаем контейнер как родителя
            obj.SetActive(false);
            Bullet bullet = obj.GetComponent<Bullet>();
            pool.Add(bullet);
        }
    }
}
