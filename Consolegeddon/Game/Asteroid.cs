using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Asteroid : GameObject
{
    public float speed { get; set; }
    public float size { get; set; }
    public float velX { get; set; }
    public float velY { get; set; }
    private Scene? scene;
    public override void Init(Scene scene)
    {
        this.scene = scene;
    }

    public override void Render(Renderer renderer)
    {
        int normX = (int)MathF.Round(x);
        int normY = (int)MathF.Round(y);

        renderer.Circle('A', normX, normY, size);
        renderer.Text('O', normX, normY);
    }

    public override void Start()
    {
        
    }

    public override void Update(float dt)
    {
        
    }
}
