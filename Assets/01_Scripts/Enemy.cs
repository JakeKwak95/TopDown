using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Player player;
    public float speed = 1f;

    public int hp = 10;

    NavMeshAgent agent;

    Animator animator;

    public SoundPlayer soundPlayer;
    public AudioClip hitSound;
    public AudioClip deathSound;

    ParticleSystem hitEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hitEffect = GetComponentInChildren<ParticleSystem>();

        animator = GetComponentInChildren<Animator>();
        animator.SetFloat("Speed", speed);

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
        else if (other.CompareTag("Player"))
        {
            player.GetDamage();
            Destroy(gameObject);
        }
    }

    public void GetDamage()
    {
        hp--;
        soundPlayer.PlaySFX(hitSound);
        hitEffect.Play();

        if (hp <= 0)
        {
            hitEffect.transform.SetParent(null);
            Destroy(gameObject);
            soundPlayer.PlaySFX(deathSound);
        }
    }
}
