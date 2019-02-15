using UniRx;
using UnityFramework.Attributes;

namespace $rootnamespace$
{
    public class $safeitemname$
    {
        [RequiredProperty]
        public ReactiveProperty<object> ReactiveProperty { get; set; }

        public $safeitemname$(Data data)
        {
            this.ReactiveProperty = new ReactiveProperty<object>(data.Property);
        }
    }
}
