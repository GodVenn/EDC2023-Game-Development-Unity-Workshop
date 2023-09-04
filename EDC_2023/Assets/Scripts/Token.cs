using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Token : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();
            player.Score++;
            GameManager.instance.OnTokenCaptured(this, player);
            gameObject.SetActive(false);
        }
    }

}
