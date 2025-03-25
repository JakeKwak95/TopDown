using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Player player;
    public float speed = 1f;

    public int hp = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
        transform.position += transform.forward * speed * Time.deltaTime;
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
