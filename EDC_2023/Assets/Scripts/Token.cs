using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent (typeof(Animator))]
public class Token : MonoBehaviour
{
    public AudioClip CaptureTokenSfx;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();
            player.Score++;
            GameManager.instance.OnTokenCaptured(this);

            _animator.SetTrigger("Die");
        }
    }

    // Called by animator
    private void OnDeathFinish()
    {
        AudioSource.PlayClipAtPoint(CaptureTokenSfx, transform.position);

        gameObject.SetActive(false);
    }

}
