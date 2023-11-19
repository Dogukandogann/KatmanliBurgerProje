using KatmanliBurger_DAL.Configurations.Extensions;
using KatmanliBurger_DATA.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KatmanliBurger_DAL.Configurations
{
	public class ParameterTypeConfiguration : IEntityTypeConfiguration<ParameterType>
	{
		public void Configure(EntityTypeBuilder<ParameterType> builder)
		{
			builder.AddSeedData();
		}
	}
}
