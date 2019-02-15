using UniRx;
using UniRxEventAggregator.Events;
using UnityEngine;
using UnityFramework.Attributes;
using UnityFramework.Extensions;

namespace $rootnamespace$
{
    public class $safeitemname$ : PubSubMonoBehaviour
    {
        [RequiredProperty]
        private Data Data { get; set; }

        [RequiredProperty, ValidateObject]
        private Model Model { get; set; }

        private readonly string _dataPath = "Data/$safeitemname$";

        private void Awake()
        {
            this.Data = Resources.Load<Data>(this._dataPath);

            this.Model = new Model(this.Data);

            if (!this.IsValidObject())
            {
                return;
            }

            this.Register(new BehaviorSubject<Model>(this.Model));

            // Add components
        }
    }
}
