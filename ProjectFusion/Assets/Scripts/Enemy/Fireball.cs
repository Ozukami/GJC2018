using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
    public float fireSpeed;
    public float VelX;
    public float VelY;
    public string element;

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
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject cat = other.gameObject;
            string elementPlayer = cat.GetComponent<Element>().GetCurrentElem().ToString();
            if (elementPlayer != element)
            {
                GameManager.Gm.TakeDamage();
                SoundManager.soundMan.PlaySound(0);
            }
        }

        if(other.gameObject.tag != "Tower")
        {
            Destroy(this.gameObject);
        }
    }
}
