using System.Collections.Generic;
using UnityEngine;

public class TriggerProjectile : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Projectiles;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            // 모든 구체 시작
            foreach (GameObject Projectile in Projectiles)
            {
                if (Projectile == null) continue;
                
                Projectile.SetActive(true);
            }
        }
    }
}
