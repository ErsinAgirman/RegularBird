using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{   
    [SerializeField] private float maxTime = 1, timer = 0, height;
    [SerializeField] GameObject pipe;
    private bool isStarted = false;

    void Update()
    {   
        StartSpawning();
        if (isStarted && timer> maxTime)
        {
            GameObject newpipe = Instantiate(pipe);
            newpipe.transform.position = transform.position +new Vector3(0, Random.Range(-height,height),0);
            Destroy(newpipe, 8);
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    public void StartSpawning()
    {
         if(Input.GetMouseButtonDown(0))
        {
            isStarted= true;
        }
    }
}
