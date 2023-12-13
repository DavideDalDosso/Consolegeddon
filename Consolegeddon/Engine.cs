using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

class Engine
{
    private Scene? currentScene;
    private Renderer renderer = new Renderer();
    private EngineInput input = new EngineInput();
    public void Start()
    {
        DateTime time1 = DateTime.Now;
        DateTime time2;

        float updateTimer = 0;
        float secondTimer = 0;

        int updates = 0;

        // Here we find DeltaTime in while loop
        while (true)
        {
            time2 = DateTime.Now;

            //We convert the date instances into numbers we can subtract with eachother
            float deltaTime = (time2.Ticks - time1.Ticks) / 10000000f;
            updateTimer += deltaTime;
            if(updateTimer > 1f/60f)
            {
                if (Console.KeyAvailable)
                {
                    input.Register(Console.ReadKey(true));
                }

                input.UpdateAvailable();

                updates++;

                renderer.Rect(' ', 0, 0, Console.WindowWidth, Console.WindowHeight);

                currentScene?.Update(updateTimer);
                currentScene?.Render(renderer);

                secondTimer += updateTimer;
                updateTimer -= 1f / 60f;

                if (secondTimer > 1)
                {
                    secondTimer -= 1;
                    renderer.Text(updates + " FPS", 0, 0);
                    updates = 0;
                }
            }

            time1 = time2;
        }
    }
    public void SetScene(Scene scene)
    {
        currentScene = scene;
    }
    public EngineInput GetInput()
    {
        return input;
    }
}
