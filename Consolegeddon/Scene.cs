using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Scene
{
    private List<IGameObject> gameObjects = new List<IGameObject>();
    private Engine engine;
    public Scene(Engine engine)
    {
        this.engine = engine;
    }
    public void Update(float dt)
    {
        foreach (var gameObject in gameObjects)
        {
            gameObject.Update(dt, this);
        }
    }
    public void Render(Renderer renderer)
    {
        foreach(var gameObject in gameObjects)
        {
            gameObject.Render(renderer);
        }
    }
    public void Add(IGameObject gameObject)
    {
        gameObjects.Add(gameObject);
    }
    public void Remove(IGameObject gameObject)
    {
        gameObjects.Remove(gameObject);
    }
    public Engine GetEngine()
    {
        return engine;
    }
}
