using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Player player;
    public float speed = 1;

    private void Update()
    {
        if (player.isAppleCollected)
        {
            var direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    public void StopMovement()
    {
        speed = 0;
    }   

}
