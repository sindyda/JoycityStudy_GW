public class Stage_Soli
{
    public void update()
    {
        for (int i = 0; i < actors.Length; ++i)
        {
            actors[i].update();
        }

        for (int i = 0; i < actors.Length; ++i)
        {
            actors[i].swap();
        }
    }

    public void add(Actor_Soli actor, int index)
    {
        actors[index] = actor;
    }

    private const int ACTORS_NUM = 3;
    private Actor_Soli[] actors = new Actor_Soli[ACTORS_NUM];
}
