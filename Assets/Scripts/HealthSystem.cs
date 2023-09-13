using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;
    public int resistance = 10;
    public Text healthText;
    // Добавьте любые другие компоненты или переменные, которые вам понадобятся

    private void Start()
    {
        // Инициализация начального здоровья
        health = maxHealth;

        // Обновление текстового поля здоровья (если есть)
        if (healthText != null)
        {
            healthText.text = "Health: " + health.ToString();
        }
    }

    public void TakeDamage(int damage)
    {
        // Вычитаем урон, учитывая сопротивление
        int effectiveDamage = Mathf.Clamp(damage - resistance, 0, damage);

        // Вычитаем здоровье
        health -= effectiveDamage;
        Debug.Log(health);
        // Обновление текстового поля здоровья (если есть)
        if (healthText != null)
        {
            healthText.text = "Health: " + health.ToString();
        }

        // Проверяем, окончилось ли здоровье
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Sdoh");
        // Обработка смерти игрового объекта
        // Например, деактивация объекта или вызов другой функции
    }
}