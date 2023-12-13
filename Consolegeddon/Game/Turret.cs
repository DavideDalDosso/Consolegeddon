using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Turret : Building
{
    private Scene? scene;

    public override void Init(Scene scene)
    {
        this.scene = scene;
        scene.AddTag("Turret", this);
        scene.AddTag("Building", this);
    }
    public override void Start()
    {
        
    }
    public override void Render(Renderer renderer)
    {
        int normX = (int)MathF.Round(x);
        int normY = (int)MathF.Round(y);

        renderer.Circle('T', normX, normY, 3f);
        renderer.Text('O', normX, normY);
    }

    public override void Update(float dt)
    {

    }
}
