﻿using ng_project.Entities;
using ng_project.SDK;
using System;
using System.Collections.Generic;
using System.Text;

namespace ng_project.Services
{
	[Service]
	public class NotifyService : MainService<Notify, int>, INotifyService
	{
	}
}