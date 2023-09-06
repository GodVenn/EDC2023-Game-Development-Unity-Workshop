using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Token : MonoBehaviour
{
    public AudioClip CaptureTokenSfx;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();
            player.Score++;
            GameManager.instance.OnTokenCaptured(this);

            AudioSource.PlayClipAtPoint(CaptureTokenSfx, transform.position);

            gameObject.SetActive(false);

        }
    }

}
