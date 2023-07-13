using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float movespeed = 10.0f;
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
    }
}