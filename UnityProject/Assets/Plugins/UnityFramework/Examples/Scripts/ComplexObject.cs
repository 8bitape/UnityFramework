using UnityEngine;
using UnityFramework.Attributes;

public class ComplexObject
{
    [RequiredProperty]
    public GameObject GameObject { get; set; }

    public ComplexObject()
    {

    }

    public ComplexObject(GameObject gameObject)
    {
        this.GameObject = gameObject;
    }
}
