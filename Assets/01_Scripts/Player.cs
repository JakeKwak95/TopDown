using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public Bullet bulletPrefab;
    public Transform firePosition;

    public float speed = 1f;

    public int hp = 10;

    float x;
    float z;

    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    void Update()
    {
        RotateToMouse();

        Move();

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

    }

    private void Move()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(x, 0, z).normalized;

        if (direction.magnitude == 0)
        {
            agent.SetDestination(transform.position);
        }
        else
        {
            agent.SetDestination(transform.position + direction);
        }
    }

    private void RotateToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(Camera.main.transform.position, hit.point, Color.red);
            Vector3 lookAt = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.LookAt(lookAt);
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePosition.position, transform.rotation);
    }

    public void GetDamage()
    {
        hp--;

        Debug.Log(hp);

        if (hp <= 0)
        {
            Debug.Log("Dead");
            Destroy(gameObject);
        }
    }
}
