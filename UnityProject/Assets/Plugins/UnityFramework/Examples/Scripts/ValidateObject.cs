using UnityEngine;
using UnityFramework.Attributes;
using UnityFramework.Extensions;

namespace UnityFramework.Examples
{
    public class ValidateObject : MonoBehaviour
    {
        [SerializeField]
        private bool _hasGameObject = false;

        [SerializeField]
        private bool _hasSystemObject = false;

        [SerializeField]
        private bool _hasValidComplexObject = false;

        [RequiredProperty]
        private GameObject GameObject { get; set; }

        [RequiredProperty]
        private object SystemObject { get; set; }

        [RequiredProperty, ValidateObject]
        private ComplexObject ComplexObject { get; set; }

        private void OnValidate()
        {
            this.GameObject = this._hasGameObject ? this.gameObject : null;

            this.SystemObject = this._hasSystemObject ? new object() : null;

            this.ComplexObject = this._hasValidComplexObject ? new ComplexObject(this.gameObject) : new ComplexObject();
        }

        private void Update()
        {
            if (this.IsValidObject())
            {
                Debug.Log($"{ this.gameObject.name } object is valid.");
            }
        }
    }
}
