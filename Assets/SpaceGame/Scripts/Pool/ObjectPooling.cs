using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SpaceGame.Scripts.Pool
{
    public class ObjectPooling
    {
        private List<PoolObject> _objects;
        private PoolObject       _sample;

        public void Initialize(PoolObject sample)
        {
            _objects = new List<PoolObject>();
            _sample  = sample;
        }

        public PoolObject GetObject(Transform parent)
        {
            var gObject = (from o in _objects
                           where !o.gameObject.activeInHierarchy
                           select o).FirstOrDefault();

            if ( gObject == null ) {
                gObject = AddObject(parent);
            }

            return gObject;
        }

        private PoolObject AddObject(Transform objects_parent)
        {
            GameObject temp;
            temp      = GameObject.Instantiate(_sample.gameObject);
            temp.name = _sample.name;
            temp.transform.SetParent(objects_parent);
            var poolObject = temp.GetComponent<PoolObject>();
            _objects.Add(poolObject);
            temp.SetActive(false);

            return poolObject;
        }
    }
}