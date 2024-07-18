using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public float bulletSpeed = 10f;
    public float sphereCastRadius = 0.5f; 
    public Transform shootOrigin; 
    public ObjectsPooler objectsPooler; 
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        objectsPooler = FindObjectOfType<ObjectsPooler>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && EnemyChecker.Instance.AreEnemiesActive())
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Bullet bullet = objectsPooler.GetBullet();
        bullet.transform.position = shootOrigin.position;
        bullet.transform.LookAt(Input.mousePosition);
        bullet.gameObject.SetActive(true);
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPoint = hit.point;
            StartCoroutine(bullet.MoveProjectile(bullet.gameObject, targetPoint));
        }
        else
        {
            Vector3 targetPoint = ray.GetPoint(10);
            StartCoroutine(bullet.MoveProjectile(bullet.gameObject, targetPoint));
        }
    }

}
