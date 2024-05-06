namespace TaQuanto.Infraestructure.Interface
{
    public interface IUnityOfWork
    {
        IRepositoryState RepositoryState { get; }
        IRepositoryProduct RepositoryProduct { get; }
        IRepositoryCity RepositoryCity { get; }
        IRepositoryEstablishment RepositoryEstablishment { get; }

        Task Commit();
    }
}
