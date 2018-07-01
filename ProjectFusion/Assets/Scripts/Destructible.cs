using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {

	public string element;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			GameObject cat = collision.gameObject;
			string elementPlayer = cat.GetComponent<Element>().GetCurrentElem().ToString();
			if(elementPlayer != element)
			{
				//GameManager.Gm.TakeDamage();
				SoundManager.soundMan.PlaySound(0);
			}

		}
	}
}
