using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
    public float fireSpeed;
    public float VelX;
    public float VelY;

    // Use this for initialization
    void Start()
    {
        transform.right = new Vector2(VelX, VelY);
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * fireSpeed);
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Tower")
        {
            if (other.gameObject.tag == "Fire" || other.gameObject.tag == "Earth" ||
                other.gameObject.tag == "Air" || other.gameObject.tag == "Water")
            {
                if (other.gameObject.tag != this.gameObject.tag)
                {
                    Destroy(other.gameObject);
                    SoundManager.soundMan.PlaySound(0);
                }
            }
            Destroy(gameObject);
            
        }
    }

}
