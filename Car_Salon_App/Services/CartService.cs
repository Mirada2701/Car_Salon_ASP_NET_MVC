using Microsoft.AspNetCore.Http;
using Car_Salon_App.Extensions;

namespace Car_Salon_App.Services
{
	public interface ICartService
	{
		int GetCount();
	}
	public class CartService : ICartService
	{
		private readonly HttpContext httpContext;
		public CartService(IHttpContextAccessor contextAccessor)
        {
			httpContext = contextAccessor.HttpContext!;
        }
        public int GetCount()
		{
			var ids = httpContext.Session.Get<List<int>>("cart_items");
			if (ids == null) return 0;

			return ids.Count;
		}
	}
}
