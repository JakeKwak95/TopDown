using UnityEngine;

public class CityPrefab : MonoBehaviour
{
    private void OnDrawGizmosSelected()
    {
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), 0, Mathf.RoundToInt(transform.position.z));
        print(gameObject.name);
    }

}
