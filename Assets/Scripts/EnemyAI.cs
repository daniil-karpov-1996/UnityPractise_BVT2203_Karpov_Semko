using UnityEngine;
using UnityEngine.UI;
public class EnemyAI : MonoBehaviour
{
    public GameObject targetObject;
    public float Speed = 5.0f;
    public float CatchDistance = 1.0f;
    public Transform player;
    public int health = 10;
    public int maxHealth = 10;
    public Text healthText;


    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {

        // Вычитаем здоровье
        health -= damage;
        {
            
        }
        // Проверяем, окончилось ли здоровье
        if (health <= 0)
        {
            Die();
        }
    }

    public int damageToDeal = 10;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        Vector3 diference = transform.position - player.position;
        if (diference.x * diference.x + diference.z * diference.z > CatchDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, Speed * Time.deltaTime);
            float rotateY = Mathf.Atan2(diference.x, diference.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, rotateY, 0f);
        }
        else
        {
            PlayerScript healthSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
            // Проверяем, есть ли у объекта компонент здоровья
            if (healthSystem != null)
            {
                // Наносим урон
                healthSystem.TakeDamage(damageToDeal);
                Die();
            }
        }
    }
    private void Die()
    {
        targetObject.SetActive(false);
        // Обработка смерти игрового объекта
    }
}
