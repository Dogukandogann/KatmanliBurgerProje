using KatmanliBurger_DATA.Abstracts;

namespace KatmanliBurger_DATA.DomainModels
{
	public class ParameterType:BaseEntity
	{
        public string TypeName { get; set; }
        public ICollection<ParameterDetail> ParameterDetails { get; set; }
        public ParameterType()
        {
            ParameterDetails=new HashSet<ParameterDetail>();
        }
    }
}
