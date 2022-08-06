using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectCoins : MonoBehaviour
{
	[SerializeField] string tagID = "Player";
	public UnityEvent onCollected;
	void OnTriggerEnter(Collider collider){
		if(collider.gameObject.CompareTag(tagID)){
			onCollected?.Invoke();
			Destroy(gameObject);
		}
	}
}
