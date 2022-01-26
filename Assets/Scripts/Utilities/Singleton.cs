using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T instance;

    public static T Instance
    {
        get
        {
            if (!instance)
            {
                instance = GameObject.FindObjectOfType<T>();

                if (!instance)
                {
                    GameObject singleton = new GameObject(typeof(T).Name);
                    instance = singleton.AddComponent<T>();
                }
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (!instance)
        {
            instance = this as T;
            OnSingletonAwake();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        if (instance == this)
            instance = null;
    }

    protected virtual void OnSingletonAwake()
    {
    }
}
