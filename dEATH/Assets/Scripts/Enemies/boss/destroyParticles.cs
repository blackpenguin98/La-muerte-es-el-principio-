using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyParticles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(des());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator des()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }


}
