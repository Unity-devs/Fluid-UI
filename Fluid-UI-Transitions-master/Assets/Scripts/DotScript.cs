using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotScript : MonoBehaviour
{
    public bool traversed = false;
    // Start is called before the first frame update


    public void destroyDot()
    {
        Debug.Log("destroy called");
        GetComponentInParent<BackgroundTile>().destroyed();
        if (traversed)
            Destroy(this.gameObject);
    }


}
