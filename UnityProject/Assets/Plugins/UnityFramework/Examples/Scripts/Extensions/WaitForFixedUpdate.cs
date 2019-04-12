using UnityEngine;

public class WaitForFixedUpdate : MonoBehaviour
{    
    void Awake()
    {
        this.enabled = true;
    }

    void Start()
    {
        this.WaitForFixedUpdate(() => this.enabled = false);
    }
}
