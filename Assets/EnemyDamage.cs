using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    
    
        public int damageAmount = 25;

        void OnCollisionEnter(Collision collision)
        {
            Health1 health = collision.gameObject.GetComponent<Health1>();
            if (health != null)
            {
                health.TakeDamage(damageAmount);
                Debug.Log("Dealt " + damageAmount + " damage to " + collision.gameObject.name);
            }
        }
    
}
