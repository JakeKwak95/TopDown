using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public Bullet bulletPrefab;
    public Transform firePosition;

    public float speed = 1f;

    public int hp = 10;
    int maxHp;
    public HUDManager hudManager;

    float x;
    float z;

    NavMeshAgent agent;

    Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;

        maxHp = hp;
        hudManager.UpdateHealthBar(maxHp, hp);
    }

    void Update()
    {
        if (GameManager.instance.isGameStarted == false)
        {
            return;
        }

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

        animator.SetBool("IsRunning", direction.magnitude != 0);
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
        animator.SetTrigger("Shoot");
    }

    public void GetDamage()
    {
        hp--;

        hudManager.UpdateHealthBar(maxHp, hp);

        if (hp <= 0)
        {
            Destroy(gameObject);

            GameManager.instance.OnLose();
        }
    }
}
