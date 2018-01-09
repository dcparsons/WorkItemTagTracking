namespace ReleaseWITAlert.Lib
{
    internal interface IFactory<T>
    {
        T Create();
    }
}
