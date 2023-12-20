using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public interface IStorage
{
    void Save(string key, object data, UnityAction<bool> callback = null);

    void Load<T>(string key, UnityAction<T> callback); 
}
