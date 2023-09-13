using UnityEngine;

public class Fireball : MonoBehaviour
{
    public int damageToDeal = 10;
    public GameObject targetObject;
    private void OnCollisionEnter(Collision collision)
    {
        EnemyAI System = collision.gameObject.GetComponent<EnemyAI>();
        // ���������, ���� �� � ������� ��������� ��������
        if (System != null)
        {
            // ������� ����
            System.TakeDamage(damageToDeal);
            targetObject.SetActive(false);
        }
    }
}