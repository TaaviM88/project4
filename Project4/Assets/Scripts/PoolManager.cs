using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PoolManager : MonoBehaviour {
    public static PoolManager current;
    public GameObject bulletPrefab;
    public int ammoReserve = 50;
    private List<GameObject> bullets = new List<GameObject>();
	// Use this for initialization
	void Awake () {
        current = this;
        for (int i = 0; i < ammoReserve; i++)
        {
            GameObject bullet = GameObject.Instantiate(bulletPrefab);
            bullet.transform.parent = this.transform;
            bullet.SetActive(false);
            bullets.Add(bullet);
        }
	}
    public GameObject GetBullet()
    {
        return bullets.FirstOrDefault(x => !x.activeInHierarchy);
    }
}
