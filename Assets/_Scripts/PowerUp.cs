using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace _Scripts
{
	public class PowerUp : MonoBehaviour 
	{
		public GameObject PickupEffect;

		private AudioSource _audioSource;
		protected GameObject Player;
		private PlayerController _controller;
		public int Duration;

		private void Start()
		{
			_audioSource = GetComponent<AudioSource>();
		}

		protected void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				Player = other.gameObject;
				_controller = Player.GetComponent<PlayerController>();
				_controller.SetPowerUp(this);
				StartCoroutine(Pickup());
			}
		}

		private IEnumerator Pickup()
		{
			_audioSource.Play();
			var clone = Instantiate(PickupEffect, transform.position, transform.rotation);
			Debug.Log("Power up picked up!");

			GetComponent<Collider>().enabled = false;
			GetComponentInChildren<MeshRenderer>().enabled = false;
			
			yield return new WaitForSeconds(1);
			
			Destroy(clone);
			Destroy(this.gameObject);
		}

		public virtual void Activate()
		{
			
		}

		public virtual void Deactivate()
		{
			
		}
	}
}
