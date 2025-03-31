using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Player player;
    public float speed = 1f;

    public int hp = 10;

    NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            GetDamage();
        }
        else if(other.CompareTag("Player"))
        {
            player.GetDamage();
            Destroy(gameObject);
        }
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
