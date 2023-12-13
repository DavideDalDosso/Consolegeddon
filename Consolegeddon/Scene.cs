using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Scene
{
    private List<GameObject> pendingObjects = new List<GameObject>();
    private List<GameObject> gameObjects = new List<GameObject>();
    private Dictionary<string, List<GameObject>> tagObjects = new Dictionary<string, List<GameObject>>();
    private Engine engine;
    public Scene(Engine engine)
    {
        this.engine = engine;
    }
    public void Update(float dt)
    {
        ApplyPending();
        foreach (var gameObject in gameObjects)
        {
            gameObject.Update(dt);
        }
    }
    public void Render(Renderer renderer)
    {
        foreach(var gameObject in gameObjects)
        {
            gameObject.Render(renderer);
        }
    }
    public void Add(GameObject gameObject)
    {
        pendingObjects.Add(gameObject);
        gameObject.Init(this);
    }
    public void ApplyPending()
    {
        foreach( var gameObject in pendingObjects)
        {
            gameObjects.Add(gameObject);
        }
        foreach (var gameObject in pendingObjects)
        {
            gameObject.Start();//WARNING Do not destroy the added objects in the same frame they're added
        }
        pendingObjects.Clear();
    }
    public void Remove<T>(T gameObject) where T : GameObject
    {
        gameObjects.Remove(gameObject);
        foreach(string tag in gameObject.tags)
        {
            if (tagObjects.ContainsKey(tag))
                tagObjects[tag].Remove(gameObject);
        }
    }
    public Engine GetEngine()
    {
        return engine;
    }
    public GameObject[] GetGameObjects()
    {
        return gameObjects.ToArray();
    }

    public T[] GetGameObjects<T>(string tag) where T : GameObject
    {
        if (!tagObjects.ContainsKey(tag)) return new T[0];
        T[] array = new T[tagObjects[tag].Count];
        for(int i = 0; i < tagObjects[tag].Count; i++)
        {
            array[i] = (T)tagObjects[tag][i];
        }
        return array;
    }
    public T GetSingleton<T>(string tag) where T : GameObject
    {
        if (!tagObjects.ContainsKey(tag)) return null;
        return (T)tagObjects[tag][0];
    }
    public void AddTag(string tag, GameObject gameObject)
    {
        if (!tagObjects.ContainsKey(tag))
        {
            tagObjects.Add(tag, new List<GameObject>());
        }
        tagObjects[tag].Add(gameObject);
    }
}
