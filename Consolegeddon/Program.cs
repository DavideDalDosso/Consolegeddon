

public class Program{

    public static void Main(string[] args)
    {
        Console.SetBufferSize(240, 60);
        Console.SetWindowSize(Console.BufferWidth, Console.BufferHeight);

        Engine engine = new Engine();

        Scene scene = new Scene(engine);

        MaterialSystem materialSystem = new MaterialSystem();
        materialSystem.materials = 100;
        scene.Add(materialSystem);

        BuildSystem buildSystem = new BuildSystem();
        buildSystem.minerPrice = 20;
        buildSystem.turretPrice = 100;
        buildSystem.wallPrice = 50;
        scene.Add(buildSystem);

        AsteroidSystem asteroidSystem = new AsteroidSystem();
        asteroidSystem.spawnThreshold = 10;
        asteroidSystem.spawnSize = 2;
        scene.Add(asteroidSystem);

        Player player = new Player();
        player.x = 120;
        player.y = 50;
        player.speed = 60;
        scene.Add(player);

        engine.SetScene(scene);
        engine.Start();
    }

}