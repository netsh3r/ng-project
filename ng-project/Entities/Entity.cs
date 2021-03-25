using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ng_project.Entities
{
	/// <summary>
	/// Основной класс сущности
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Entity : BaseEntity
	{
		/// <summary>
		/// Generic идентификатор
		/// </summary>
		[Key]
		public override int Id { get; set; }
	}
}
