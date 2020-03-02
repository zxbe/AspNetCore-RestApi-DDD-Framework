using System;

namespace Domain.Base
{
    public abstract class BaseModel
    {
        public Guid? Id { get; set; }
        public bool? IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Guid? CreatorId { get; set; }
    }
}