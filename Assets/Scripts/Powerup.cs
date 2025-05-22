using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] private float _powerupSpeed = 3.0f;
    [SerializeField] private int powerupID;
    [SerializeField] private AudioClip _clip;
   
    void Update()
    {
        transform.Translate (Vector3.down *  _powerupSpeed * Time.deltaTime);

        if (transform.position.y < -5.45f)
        {
            Destroy (this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.tag == "Player")
        {            
            Player player = other.transform.GetComponent<Player>();

            AudioSource.PlayClipAtPoint(_clip, transform.position);

            if (player != null)
            {
                switch (powerupID)
                {
                    case 0:
                        player.TripleShotActive();
                        break;
                    case 1:
                        player.SpeedBoostActive();
                        break;
                    case 2:
                        player.ShieldActive();
                        break;
                    default:
                        break;
                }
                
            }
            
            Destroy(this.gameObject);
        }
    }
}
