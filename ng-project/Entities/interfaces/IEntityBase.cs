using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Entities.interfaces
{
	/// <summary>
	/// Базовый интерфейс сущности
	/// </summary>
	/// <typeparam name="T"></typeparam>
	interface IEntityBase
	{
		int Id { get; set; }
	}
}
