using UnityEngine;

public class Player : MonoBehaviour
{
    public Bullet bulletPrefab;
    public Transform firePosition;

    public float speed = 1f;

    float x;
    float z;

    void Start()
    {

    }

    void Update()
    {
        RotateToMouse();

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        transform.position += new Vector3(x, 0, z) * speed * Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

    }

    private void RotateToMouse()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
        {
            Vector3 lookAt = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.LookAt(lookAt);
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePosition.position, transform.rotation);
    }
}
