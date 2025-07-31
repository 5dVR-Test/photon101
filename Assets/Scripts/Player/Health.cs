using Photon.Pun;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int currentHealth;

    [PunRPC]
    public void ApplyDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}