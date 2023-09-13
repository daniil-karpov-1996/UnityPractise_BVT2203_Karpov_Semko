using UnityEngine;

public class Fireball : MonoBehaviour
{
    public int damageToDeal = 10;
    public GameObject targetObject;
    private void OnCollisionEnter(Collision collision)
    {
        EnemyAI System = collision.gameObject.GetComponent<EnemyAI>();
        // Проверяем, есть ли у объекта компонент здоровья
        if (System != null)
        {
            // Наносим урон
            System.TakeDamage(damageToDeal);
            targetObject.SetActive(false);
        }
    }
}