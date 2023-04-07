using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base
{
    public abstract class EntityBase<Tkey> : IEntityBase<Tkey>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Tkey Id { get; set; }
    }

    public abstract class DeleteEntity<Tkey> : EntityBase<Tkey>, IDeleteEntity<Tkey>
    {
        public bool IsDeleted { get; set; }
    }

    public abstract class AuditEntity<tkey> : DeleteEntity<tkey>, IAuditEntity<tkey>
    {
        public DateTime CreatedDate {  get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set;}
    }
}
