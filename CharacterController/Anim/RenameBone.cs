using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class RenameBone : MonoBehaviour
{
    string name;
    bool done;
    void Start()
    {
        if (Application.IsPlaying(this))
        {

        }
        else
        {if(done != true)
            {
                name = this.gameObject.name;
                if (this.gameObject.name != (name + "(copy)"))
                {
                    this.gameObject.name = name + "(copy)";
                }
            }
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
