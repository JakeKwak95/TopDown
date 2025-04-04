using UnityEngine;

public class PlayerFollowCam : MonoBehaviour
{
    public Player player;

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
    }
}
