using AutoMapper;
using TaQuanto.Domain.Entities;
using TaQuanto.Domain.Exception;
using TaQuanto.Domain.Pagination;
using TaQuanto.Infraestructure.Interface;
using TaQuanto.Service.Dtos.Category;
using TaQuanto.Service.Interfaces;
using TaQuanto.Service.Validations;

namespace TaQuanto.Service.Services
{
    public class ServiceCategory : IServiceCategory
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;

        public ServiceCategory(IUnityOfWork unityOfWork, IMapper mapper)
        {
            _unityOfWork = unityOfWork;
            _mapper = mapper;
        }

        public async Task<ReadCategoryDto> CreateCategoryAsync(CreateOrUpdateCategoryDto c)
        {
            await ValidateAsync(c);

            var cat = _mapper.Map<Category>(c);

            var category = await _unityOfWork.RepositoryCategory.CreatAsync(cat);
            await _unityOfWork.Commit();

            return _mapper.Map<ReadCategoryDto>(category);
        }

        public async Task DeleteCategoryByIdAsync(Guid id)
        {
            try
            {
                var category = await _unityOfWork.RepositoryCategory.GetByIdAsync(id);

                _unityOfWork.RepositoryCategory.Delete(category);
                await _unityOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw new RestrictDeleteException("Não é possivel Deletar, pois existe itens associados ao mesmo.");
            }
        }

        public async Task<PagedList<ReadCategoryDto>> GetAllCategoriesAsync(CategoryParameters parameters)
        {
            var categories = await _unityOfWork.RepositoryCategory.GetAllCategoriesAsync(parameters);

             return _mapper.Map<PagedList<ReadCategoryDto>>(categories);
        }

        public async Task<ReadCategoryDto> GetCategoryByIdAsync(Guid id)
        {
            var category = await _unityOfWork.RepositoryCategory.GetByIdAsync(id);

            return _mapper.Map<ReadCategoryDto>(category);
        }

        public async Task UpdateCategoryAsync(CreateOrUpdateCategoryDto c, Guid id)
        {
            await ValidateAsync(c);

            if(c.Id != id)
            {
                throw new HeaderIdException("Verifique se o Id da Categoria não é o mesmo da Categoria passado.");
            }
            
            var category = _mapper.Map<Category>(c);
            _unityOfWork.RepositoryCategory.Update(category);
            await _unityOfWork.Commit();
        }

        private async Task ValidateAsync(CreateOrUpdateCategoryDto dto)
        {
            var validator = new CategoryValidation();
            var result = await validator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors.Select(e => e.ErrorMessage).ToList());
            }
        }
    }
}
