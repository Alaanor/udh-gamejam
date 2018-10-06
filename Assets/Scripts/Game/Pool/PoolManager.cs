using System.Collections.Generic;
using UnityEngine;

namespace Game.Pool
{
    public class PoolManager : MonoBehaviour
    {
        public string DefaultName = "Item";
        public int WarmUpAmount;
        public GameObject Item;
        public Transform UnusedPlace;

        private readonly Stack<GameObject> _instance = new Stack<GameObject>();

        private void Start()
        {
            for (var i = 0; i < WarmUpAmount; i++)
                CreateInstance();
        }
        
        public GameObject GetItem()
        {
            var obj = _instance.Count != 0 ? _instance.Pop() : CreateInstance();
            obj.SetActive(true);
            return obj;
        }

        public void GiveBackItem(GameObject obj)
        {
            PushInstanceInStack(obj);
        }

        private GameObject CreateInstance()
        {
            var obj = Instantiate(Item, UnusedPlace);
            PushInstanceInStack(obj);
            return obj;
        }

        private void PushInstanceInStack(GameObject obj)
        { 
            ResetObj(obj);
            _instance.Push(obj);
            obj.SetActive(false);
        }
        
        private void ResetObj(GameObject obj)
        {
            obj.name = DefaultName;
            obj.transform.position = Vector3.zero;
        }
    }
}