using ng_project.Entities.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Entities
{
	//</inheritdoc>
	public abstract class BaseEntity : IEntityBase
	{
		//</inheritdoc>
		public abstract int Id { get; set; }
	}
}
