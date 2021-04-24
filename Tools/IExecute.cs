namespace Tools
{
    public interface IExecute
    {
        void Execute(float deltaTime);
    }

    public interface IExecuteParameterless
    {
        void Execute();
    }
}