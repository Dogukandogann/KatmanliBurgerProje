using KatmanliBurger_DATA.Concretes;
using KatmanliBurger_DATA.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliBurger_DAL.Configurations.Extensions
{
	public static class ParameterTypeConfigurationExtension
	{
		public static void AddSeedData(this EntityTypeBuilder<ParameterType> builder)
		{
			builder.HasData(
			new ParameterType() { Id = 1, TypeName = "About", CreatedDate = DateTime.Now },
			new ParameterType() { Id = 2, TypeName = "Contact", CreatedDate = DateTime.Now },
			new ParameterType() { Id = 3, TypeName = "General", CreatedDate = DateTime.Now },
			new ParameterType() { Id = 4, TypeName = "Exception", CreatedDate = DateTime.Now },
			new ParameterType() { Id = 5, TypeName = "UIMessagges", CreatedDate = DateTime.Now },
			new ParameterType() { Id = 6, TypeName = "AdminMessagges", CreatedDate = DateTime.Now }
			);
		}
	}
}
