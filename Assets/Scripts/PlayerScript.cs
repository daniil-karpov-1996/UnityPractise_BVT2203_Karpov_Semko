using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public GameObject targetObject;
    public float movespeed = 10.0f;
    public int health = 100;
    public int maxHealth = 100;
    public Text healthText;
    public GameObject Fireball;
    public Transform Pricel;
    public float Firespeed = 500.0f;

    private void Start()
    {
        // Инициализация начального здоровья
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        // Проверяем, окончилось ли здоровье
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        targetObject.SetActive(false);
        // Обработка смерти игрового объекта
    }

    private void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(Horizontal, 0, Vertical) * Time.deltaTime * movespeed, Space.World);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            Vector3 diference = raycastHit.point - transform.position;
            float rotateY = Mathf.Atan2(diference.x, diference.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, rotateY, 0f);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 diference = raycastHit.point - transform.position;
            float direction = diference.x + diference.z;
            GameObject Fireball_clone = Instantiate(Fireball, Pricel.position, Pricel.rotation);
            Fireball_clone.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, 1) * Firespeed);
            Destroy(Fireball_clone, 5);
        }
    }
}