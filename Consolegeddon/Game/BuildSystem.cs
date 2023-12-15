using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BuildSystem : GameObject
{
    public bool running = true;
    public float minerPrice { get; set; }
    public float turretPrice { get; set; }
    public float wallPrice { get; set; }
    private float increasedMinerPrice = 0;
    private float increasedTurretPrice = 0;
    private MaterialSystem? materialSystem;
    private Scene? scene;

    public override void Init(Scene scene)
    {
        this.scene = scene;
        scene.AddTag("BuildSystem", this);
    }
    public override void Start()
    {
        materialSystem = scene.GetSingleton<MaterialSystem>("MaterialSystem");
    }
    public override void Render(Renderer renderer)
    {
        float clampMiner = MathF.Round(increasedMinerPrice, 1);
        renderer.Text("[R] Miner: " + clampMiner, 220, 2);
        float clampTurret = MathF.Round(increasedTurretPrice, 1);
        renderer.Text("[Q] Turret: " + clampTurret, 220, 3);
        float clampWall = MathF.Round(wallPrice, 1);
        renderer.Text("[E] Wall: " + clampWall, 220, 4);
    }

    public override void Update(float dt)
    {
        if (!running) return;
        int miners = scene.GetGameObjects<Miner>("Miner").Length;
        increasedMinerPrice = minerPrice + minerPrice * miners * miners * 0.5f;
        int turrets = scene.GetGameObjects<Turret>("Turret").Length;
        increasedTurretPrice = turretPrice + turretPrice * turrets * turrets * 0.3f;
    }

    public void SpawnMiner(float x, float y)
    {
        if (!running) return;
        if (materialSystem.materials >= increasedMinerPrice)
        {
            materialSystem.materials -= increasedMinerPrice;

            Miner miner = new Miner();
            miner.x = x;
            miner.y = y;
            miner.health = 3;
            miner.size = 2;

            scene.Add(miner);
        }
    }

    public void SpawnTurret(float x, float y)
    {
        if (!running) return;
        if (materialSystem.materials >= turretPrice)
        {
            materialSystem.materials -= turretPrice;

            Turret turret = new Turret();
            turret.x = x;
            turret.y = y;
            turret.health = 3;
            turret.shootCooldown = 0.5f;
            turret.size = 3;

            scene.Add(turret);
        }
    }

    public void SpawnWall(float x, float y)
    {
        if (!running) return;
        if (materialSystem.materials >= wallPrice)
        {
            materialSystem.materials -= wallPrice;

            Wall wall = new Wall();
            wall.x = x;
            wall.y = y;
            wall.health = 10;
            wall.size = 3;

            scene.Add(wall);
        }
    }
}
