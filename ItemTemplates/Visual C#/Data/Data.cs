using UnityEngine;
using UnityFramework.Attributes;

namespace $rootnamespace$
{
    [CreateAssetMenu(fileName = "$safeitemrootname$", menuName = "$safeitemrootname$")]
    public class $safeitemname$ : ScriptableObject
    {
        [SerializeField]
        private object _backingField = null;

        [RequiredProperty]
        public object Property { get { return this._backingField; } }
    }
}