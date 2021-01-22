using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Entities
{
	/// <summary>
	/// Основной класс сущности
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Entity<T> : BaseEntity<T>
	{
		/// <summary>
		/// Generic идентификатор
		/// </summary>
		public override T Id { get; set; }
	}
}
