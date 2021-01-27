namespace ng_project.Services
{
	/// <summary>
	/// Базовый сервис проекта для работы с основными данными
	/// </summary>
	public interface INgProjectService
	{
		/// <summary>
		/// Получить всех юзеров
		/// </summary>
		void GetAllUsers();
	}
}