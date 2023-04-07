namespace Domain.Base
{
    public interface IEntityBase<Tkey>
    {
        public Tkey Id { get; set; }
    }

    public interface IDeleteEntity
    {
        bool IsDeleted { get; set; }
    }

    public interface IDeleteEntity<Tkey> : IDeleteEntity, IEntityBase<Tkey>
    {

    }

    public interface IAuditEntity
    {
        DateTime CreatedDate { get; set; }
        string CreatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
        string UpdatedBy { get; set; }
    }

    public interface IAuditEntity<Tkey> : IAuditEntity, IEntityBase<Tkey>
    {
    }
}
