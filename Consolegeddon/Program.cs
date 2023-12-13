

public class Program{

    public static void Main(string[] args)
    {
        Engine engine = new Engine();

        Scene scene = new Scene(engine);

        Player player = new Player();
        player.x = 15;
        player.y = 20;
        scene.Add(player);

        engine.SetScene(scene);
        engine.Start();
    }

}