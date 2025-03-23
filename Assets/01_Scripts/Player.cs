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
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        transform.position += new Vector3(x, 0, z) * speed * Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePosition.position, transform.rotation);
    }
}
