namespace Calculator;

public interface ICommand
{
    public decimal Execute();
}

public class PlusCommand : ICommand
{
    private decimal _x;
    private decimal _y;
    public PlusCommand( decimal x, decimal y)
    {
        _x = x;
        _y = y;
    }

    public decimal Execute()
    {
        return _x + _y;
    }
}

public class MinusCommand : ICommand
{
    private decimal _x;
    private decimal _y;
    public MinusCommand( decimal x, decimal y)
    {
        _x = x;
        _y = y;
    }


    public decimal Execute()
    {
        return _x - _y;
    }
}


public interface IHandler
{
    public IHandler SetNext(IHandler handler);

    public object Handle(ICommand command);
}

public abstract class AbstaractHandle : IHandler
{
    private IHandler _handler;
    public IHandler SetNext(IHandler handler)
    {
        _handler = handler;

        return _handler;
    }

    public virtual object Handle(ICommand command)
    {
       return _handler.Handle(command);
    }
}

public class Plus : AbstaractHandle
{
    public override object Handle(ICommand command)
    {
        if (command is PlusCommand)
        {
           return command.Execute();
        }
        else
        {
            return base.Handle(command);

        }

        return null;
    }
}

public class Minus : AbstaractHandle
{
    public override object Handle(ICommand command)
    {
        if (command is MinusCommand)
        {
            return command.Execute();
        }
        else
        {
            return base.Handle(command);

        }

        return null;
    }
}
public class CalcInvoker 
{
    private ICommand _command;
    public void SetCommand( ICommand command)
    {
        _command = command;
    }

    public object execute()
    {
        if (_command is ICommand)
        {
            AbstaractHandle handler = new Plus();
            handler.SetNext(new Minus());
            return handler.Handle(_command);
        }

        throw new ArgumentException("");
    }
}