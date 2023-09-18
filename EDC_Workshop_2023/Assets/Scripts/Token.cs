using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            player.Score++;

            GameManager.Instance.OnTokenCapture(this);

            this.gameObject.SetActive(false);
        }
    }

}
