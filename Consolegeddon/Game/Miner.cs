using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Miner : Building
{
    private Scene? scene;
    private MaterialSystem? materialSystem;

    public override void Init(Scene scene)
    {
        this.scene = scene;
        scene.AddTag("Miner", this);
        scene.AddTag("Building", this);
    }
    public override void Start()
    {
        materialSystem = scene.GetSingleton<MaterialSystem>("MaterialSystem");
    }
    public override void Render(Renderer renderer)
    {
        int normX = (int)MathF.Round(x);
        int normY = (int)MathF.Round(y);

        renderer.Circle('M', normX, normY, 2f);
        renderer.Text('O', normX, normY);
    }

    public override void Update(float dt)
    {
        materialSystem.materials += dt * 1f;
    }
}
