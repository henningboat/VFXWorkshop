using System;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T:Singleton<T>
{
    public static T Instance { get; private set; }
    protected virtual void Awake()
    {
        if (Instance != null)
        {
            throw new Exception($"More than one instance of {nameof(T)} present in the scene. " +
                                $"This is not allowed. Please delete all but one instances.");
        }

        Instance = this as T;
    }
}
