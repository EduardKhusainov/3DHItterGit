using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
[SerializeField] float projectileSpeed;
[SerializeField] float sphereCastRadius;
[SerializeField] float damage;

   public IEnumerator MoveProjectile(GameObject projectile, Vector3 targetPoint)
    {
        Vector3 startPosition = projectile.transform.position;
        Vector3 direction = (targetPoint - startPosition).normalized;
        float distance = Vector3.Distance(startPosition, targetPoint);

        while (distance > sphereCastRadius)
        {
            float step = projectileSpeed * Time.deltaTime;
            Vector3 nextPosition = projectile.transform.position + direction * step;
            Ray ray = new Ray(projectile.transform.position, direction);
            RaycastHit hit;

            if (Physics.SphereCast(ray, sphereCastRadius, out hit, step))
            {
                projectile.transform.position = hit.point;
                
                Debug.Log("Hit: " + hit.collider.name);
                if(hit.collider.GetComponent<IDamageble>() != null)
                {
                    hit.collider.GetComponent<IDamageble>().TakeDamage(damage);
                }
                projectile.SetActive(false);
                yield break;
            }

            projectile.transform.position = nextPosition;
            distance -= step;
            yield return null;
        }
        projectile.SetActive(false);
    }
}
