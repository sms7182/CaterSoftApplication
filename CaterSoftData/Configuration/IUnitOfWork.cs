namespace CaterSoftData.Configuration
{
    public interface IUnitOfWork
    {
         void BeginTransaction();
         void Commit();
         void Rollback();
    }
}