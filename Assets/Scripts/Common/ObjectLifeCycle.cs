
public class ObjectLifeCycle
{
    public enum Status
    {
        toInit, running, paused, ended
    }

    private Status state = Status.toInit;


    public Status GetCurrentStatus()
    {
        return state;
    }

    public void Pause()
    {
        if(state == Status.running)
        {
            state = Status.paused;
        }
    }

    public void Play()
    {
        if (state == Status.paused)
        {
            state = Status.running;
        }
    }

    public void Initializated()
    {
        if ( state == Status.toInit)
        {
            state = Status.paused;
        }
    }

    public void End()
    {
        state = Status.ended;
    }
}
