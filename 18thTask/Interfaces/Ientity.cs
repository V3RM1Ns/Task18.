namespace _18thTask.Interfaces;

public interface Ientity
{
    public int Id { get;}
}

public class Entity : Ientity
{
    private static int _id = 0;
    public int Id { get;}

    public Entity()
    {
        Id = ++_id;
    }
}