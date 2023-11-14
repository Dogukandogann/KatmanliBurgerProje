using KatmanliBurger_DATA.Enums;

namespace KatmanliBurger_DATA.Abstracts
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Status Status { get; set; } = Status.Active;
    }
}
