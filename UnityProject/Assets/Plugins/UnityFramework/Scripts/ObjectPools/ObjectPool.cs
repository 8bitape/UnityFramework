using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace UnityFramework.ObjectPools
{
    public class ObjectPool<TComponent> : UniRx.Toolkit.ObjectPool<TComponent>
        where TComponent : Component
    {
        private TComponent Prefab { get; set; }

        private List<TComponent> Instances { get; set; }

        public ObjectPool(TComponent prefab, int preloadCount)
        {
            this.Prefab = prefab;

            this.Instances = new List<TComponent>();

            this.Preload(preloadCount);
        }

        protected override TComponent CreateInstance()
        {
            return GameObject.Instantiate<TComponent>(this.Prefab);
        }

        public void RentAtPosition(Vector3 position)
        {
            var instance = base.Rent();

            instance.transform.position = position;
        }

        protected override void OnBeforeRent(TComponent instance)
        {
            base.OnBeforeRent(instance);

            this.Instances.Add(instance);
        }

        protected override void OnBeforeReturn(TComponent instance)
        {
            base.OnBeforeReturn(instance);

            this.Instances.Remove(instance);
        }

        public void ReturnAll()
        {
            foreach (var instance in this.Instances.AsEnumerable().Reverse())
            {
                this.Return(instance);
            }
        }

        private void Preload(int preloadCount)
        {
            MainThreadDispatcher.StartFixedUpdateMicroCoroutine(this.PreloadCoroutine(preloadCount));
        }

        private IEnumerator PreloadCoroutine(int preloadCount)
        {
            while (this.Count < preloadCount)
            {
                var instance = this.CreateInstance();

                this.Return(instance);

                yield return null;
            }
        }
    }
}