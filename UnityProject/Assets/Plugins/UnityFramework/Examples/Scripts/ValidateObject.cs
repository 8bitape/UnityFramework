using UnityEngine;
using UnityFramework.Attributes;
using UnityFramework.Extensions;

namespace UnityFramework.Examples
{
    public class ValidateObject : MonoBehaviour
    {
        [SerializeField]
        private bool _hasGameObject = false;

        [RequiredProperty]
        private GameObject GameObject { get; set; }

        [SerializeField]
        private bool _hasSystemObject = false;

        [RequiredProperty]
        private object SystemObject { get; set; }

        private void OnValidate()
        {
            this.GameObject = this._hasGameObject ? this.gameObject : null;

            this.SystemObject = this._hasSystemObject ? new object() : null;
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
