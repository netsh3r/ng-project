using ng_project.Entities;
using ng_project.Managers;
using ng_project.SDK;
using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Services
{
	[Service]
	public class SubscriveService : MainService<Subscriber,int>, ISubscribeService
	{
		public Subscriber FindById(int id)
		{
			return SubscriberManager.Instance.FindById(id);
		}
	}
}
