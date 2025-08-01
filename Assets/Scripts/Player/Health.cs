using Photon.Pun;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public int health;

    [Header("UI")]
    public TextMeshProUGUI healthText;

    [PunRPC]
    public void ApplyDamage(int damageAmount)
    {
        health -= damageAmount;

        healthText.text = health.ToString();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}