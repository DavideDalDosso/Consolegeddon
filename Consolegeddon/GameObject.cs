using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class GameObject
{
    public float x;
    public float y;
    public List<string> tags = new List<string>();
    public abstract void Init(Scene scene);
    public abstract void Start();
    public abstract void Update(float dt);
    public abstract void Render(Renderer renderer);
}
