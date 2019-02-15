using UniRxEventAggregator.Events;
using UnityFramework.Attributes;
using UnityFramework.Extensions;

namespace $rootnamespace$
{
    public class $safeitemname$ : PubSubMonoBehaviour
    {
        [RequiredProperty]
        private Model Model { get; set; }

        [RequiredProperty]
        private View View { get; set; }

        private void Awake()
        {
            this.Subscribe<Model>(x => this.Model = x);

            this.Subscribe<View>(x => this.View = x);
        }

        private void Start()
        {
            if (!this.IsValidObject())
            {
                return;
            }

            // Setup view model bindings
        }
    }
}
