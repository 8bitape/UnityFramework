using UnityEngine;
using UnityFramework.Attributes;
using UnityFramework.Extensions;

namespace UnityFramework.Examples
{
    public class ValidateObject : MonoBehaviour
    {
        [SerializeField]
        private GameObject _gameObject = null;

        [RequireProperty]
        private GameObject GameObject { get { return this._gameObject; } }

        private void Update()
        {
            if (!this.IsValidObject())
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
