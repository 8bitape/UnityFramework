using UniRx;
using UniRxEventAggregator.Events;
using UnityEngine;
using UnityFramework.Attributes;
using UnityFramework.Extensions;

namespace $rootnamespace$
{
    public class $safeitemname$ : PubSubMonoBehaviour
    {
        [SerializeField]
        private object _backingField = null;

        [RequiredProperty]
        public object Property { get { return this._backingField; } }

        private void Awake()
        {
            if (!this.IsValidObject())
            {
                return;
            }

            this.Register(new BehaviorSubject<$safeitemname$>(this));
        }
    }
}
