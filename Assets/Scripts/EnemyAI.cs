using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float Speed = 5.0f;
    public float CatchDistance = 1.0f;
    public Transform player;
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
    }
}
