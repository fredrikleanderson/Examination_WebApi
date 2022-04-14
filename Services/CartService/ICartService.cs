using Microsoft.AspNetCore.Mvc;

namespace Examination_WebApi.Services.CartService
{
    public interface ICartService
    {
        Task<ActionResult> AddCart(int userId);
        Task<ActionResult> DeleteCart(int userId);

    }
}
