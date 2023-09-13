using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;
    public int resistance = 10;
    public Text healthText;
    // �������� ����� ������ ���������� ��� ����������, ������� ��� �����������

    private void Start()
    {
        // ������������� ���������� ��������
        health = maxHealth;

        // ���������� ���������� ���� �������� (���� ����)
        if (healthText != null)
        {
            healthText.text = "Health: " + health.ToString();
        }
    }

    public void TakeDamage(int damage)
    {
        // �������� ����, �������� �������������
        int effectiveDamage = Mathf.Clamp(damage - resistance, 0, damage);

        // �������� ��������
        health -= effectiveDamage;
        Debug.Log(health);
        // ���������� ���������� ���� �������� (���� ����)
        if (healthText != null)
        {
            healthText.text = "Health: " + health.ToString();
        }

        // ���������, ���������� �� ��������
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Sdoh");
        // ��������� ������ �������� �������
        // ��������, ����������� ������� ��� ����� ������ �������
    }
}