using System;

namespace Domain.Base
{
    public class BaseModel
    {
        public Guid? Id { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? CreatorId { get; set; }
    }
}