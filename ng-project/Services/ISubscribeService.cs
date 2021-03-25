using ng_project.Entities;

namespace ng_project.Services
{
	public interface ISubscribeService : IBaseService<Subscriber, int>
	{
		Subscriber FindById(int id);
	}
}