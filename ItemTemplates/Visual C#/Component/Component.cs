using UniRx;
using UniRxEventAggregator.Events;
using UnityFramework.Attributes;
using UnityFramework.Extensions;

namespace $rootnamespace$
{
    public class $safeitemname$ : PubSubMonoBehaviour
    {
        [RequiredProperty]
        private Model Model { get; set; }

        public void Awake()
        {
            this.Subscribe<Model>(x => this.Model = x);
        }

        public void Start()
        {
            if (!this.IsValidObject())
            {
                return;
            }

            PubSub.GetEvent<Event>()
                .Subscribe(this.Handler);
        }

        private void Handler(Event @event)
        {
            // Handle event
        }
    }
}
