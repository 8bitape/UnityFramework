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

        [RequiredProperty]
        private Model Model { get; set; }

        private readonly string _dataPath = "Data/$safeitemname$";

        private void Awake()
        {
            this.Data = Resources.Load<Data>(this._dataPath);

            if (!this.Data.IsValidObject())
            {
                return;
            }

            this.Model = new Model(this.Data);

            if (!this.Model.IsValidObject())
            {
                return;
            }

            this.Register(new BehaviorSubject<Model>(this.Model));

            // Add components
        }
    }
}
