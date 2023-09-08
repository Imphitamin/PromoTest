using JetBrains.Annotations;
using PromoTest.Project.BusinessLogic.Interfaces.Factories;
using UnityEngine;
using Object = UnityEngine.Object;

namespace PromoTest.Project.BusinessLogic.Factories
{
    public abstract class GenericMonoFactory<TResult>
        where TResult : MonoBehaviour, IFactoryObject
    {
        public TResult Create(
            string prefabFullPath,
            [CanBeNull] Transform parent = null)
        {
            return Object.Instantiate(Resources.Load<TResult>(prefabFullPath), parent);
        }
    }

    public abstract class GenericMonoFactory<TParam1, TResult> : GenericMonoFactory<TResult>
        where TResult : MonoBehaviour, IFactoryObject<TParam1>
    {
        public TResult Create(
            string prefabFullPath,
            TParam1 param1,
            [CanBeNull] Transform parent = null)
        {
            var result = Create(prefabFullPath, parent);
            var factoryObject = result as IFactoryObject<TParam1>;

            if (factoryObject == null)
            {
                Debug.LogError($"Cannot create object with the specified path \"{prefabFullPath}\" and with " +
                               $"params: \"{param1.ToString()}\"");
                return null;
            }

            factoryObject.OnCreate(param1);
            
            return result;
        }
    }
}