using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinManager : MonoBehaviour
{
	public List<GameObject> coins;

	public void RemoveCoin(GameObject coin) {
		//remove coin
		if (coins.Remove(coin)) {
			Destroy(coin);
			if (coins.Count == 0) {
				SceneManager.LoadScene("End");
			}
		}
	}
}
