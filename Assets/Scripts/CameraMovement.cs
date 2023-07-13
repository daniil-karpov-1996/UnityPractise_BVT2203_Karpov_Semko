using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    public float smooth = 5.0f;
    public Vector3 offset = new Vector3(0, 10, -5);
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + offset, Time.deltaTime * smooth);
    }
}
