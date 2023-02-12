using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPipe : MonoBehaviour
{
    [SerializeField]
    private GameObject pipeHolder;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());        
    }
    IEnumerator Spawner()
    {
        yield return new WaitForSeconds (1.2f);
        Vector3 temp = pipeHolder.transform.position;
        temp.y = Random.Range(-2f, 2.5f);

        Instantiate (pipeHolder, temp, Quaternion.identity);
        StartCoroutine(Spawner());
    }
    
}
