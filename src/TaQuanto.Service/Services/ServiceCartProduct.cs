using TaQuanto.Infraestructure.Interface;
using TaQuanto.Service.Interfaces;

namespace TaQuanto.Service.Services
{
    public class ServiceCartProduct : IServiceCartProduct
    {
        private readonly IUnityOfWork _unityOfWork;

        public ServiceCartProduct(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public async Task DeleteCartProductAsync(Guid id)
        { 
            var cartProduct = await _unityOfWork.RepositoryCartProduct.GetByIdAsync(id);
            
            _unityOfWork.RepositoryCartProduct.Delete(cartProduct);
        }
    }
}
