using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject toSpawn;

    private HashSet<Collider> _colliders = new HashSet<Collider>();
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Scan", 0f, 5f);
    }

    private void OnTriggerEnter(Collider other) 
    {
        _colliders.Add(other);
    }

    private void OnTriggerExit(Collider other)
    {
        _colliders.Remove(other);
    }


    private void Scan()
    {
        foreach (Collider col in _colliders)
        {
            if (col != null && col.gameObject.name.Equals(toSpawn.name + "(Clone)")) return;
        }

        _colliders.Remove(null);
        
        Instantiate(toSpawn, transform.position + Vector3.up, toSpawn.transform.rotation);
    }
}
