using Microsoft.EntityFrameworkCore;
using ng_project.Context;
using ng_project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ng_project.Managers
{
	public class ParticipantManager : EntityManager<Participant, int>
	{
		private static ParticipantManager _instance;
		public static ParticipantManager Instance
		{
			get
			{
				return _instance ?? (_instance = new ParticipantManager());
			}
		}

		public override ICollection<Participant> FindAll()
		{
			using(var db = new NgContext())
			{
				var model = db.Participants
					.Include(t => t.Skills)
					.Include(t => t.User)
					.ToList();
				return model;
			}
		}
		public override ICollection<Participant> FindAll(Func<Participant, bool> func)
		{
			using (var db = new NgContext())
			{
				var model = db.Participants
					.Include(t => t.Skills)
					.Include(t => t.User)
					.Include(t=> t.Skills)
					.Where(func)
					.ToList();
				return model;
			}
		}
	}
}
