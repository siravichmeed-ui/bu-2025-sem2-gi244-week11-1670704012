using UnityEngine;

public class StunPowerUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            other.GetComponent<PlayerController>()?.ActivateStun();

            Destroy(gameObject);
        }
    }
}