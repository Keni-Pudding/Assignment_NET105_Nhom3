using Assignment_NET105_Nhom3_Shared.ViewModels;

namespace Assignment_NET105_Nhom3_API.IServices
{
	public interface ILoginService
	{
		Task<Response> LoginAsync(LoginUser loginUser);
	}
}
