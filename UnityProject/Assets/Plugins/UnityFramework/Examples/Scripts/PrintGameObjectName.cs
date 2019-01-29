using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityFramework.Attributes;
using UnityFramework.Extensions;

namespace UnityFramework.Examples
{
    public class PrintGameObjectName : MonoBehaviour
    {
        [SerializeField]
        private GameObject _gameObject = null;

        [ValidatePropertyIsNotNull]
        private GameObject GameObject { get { return this._gameObject; } }

        private List<PropertyInfo> ValidatedProperties { get; set; }

        private void Awake()
        {
            // Cache the properties to improve performance
            this.ValidatedProperties = this.GetValidatedProperties();
        }

        private void Update()
        {
            if (this.HasPropertiesWithNullValues(this.ValidatedProperties))
            {
                Debug.Log("There are properties with null values!");
            }
            else
            {
                Debug.Log(this.GameObject.name);
            }
        }
    }
}
