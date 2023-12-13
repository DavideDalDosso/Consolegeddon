using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

class AsteroidSystem : GameObject
{
    private Scene scene;
    private float timer = 0;
    public float spawnSize { get; set; }
    public float spawnThreshold { get; set; }
    private Random random = new Random();
    public override void Init(Scene scene)
    {
        this.scene = scene;
        scene.AddTag("AsteroidSystem", this);
    }

    public override void Render(Renderer renderer)
    {
        renderer.Text("Asteroid CD: " + (spawnThreshold - timer), 0, 2);
    }

    public override void Start()
    {
        
    }

    public override void Update(float dt)
    {
        timer += dt;
        if(timer >= spawnThreshold)
        {
            timer -= spawnThreshold;

            Asteroid asteroid = new Asteroid();
            asteroid.x = random.Next(220);
            asteroid.y = -spawnSize;
            asteroid.size = spawnSize;
            scene.Add(asteroid);
        }
    }
}
