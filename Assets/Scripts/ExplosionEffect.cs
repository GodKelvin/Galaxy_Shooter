using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Destrua esse objeto depois de 4s
        Destroy(this.gameObject, 4f);
    }
}
