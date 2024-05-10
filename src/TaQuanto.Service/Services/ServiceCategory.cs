using AutoMapper;
using TaQuanto.Domain.Entities;
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
            var category = await _unityOfWork.RepositoryCategory.GetByIdAsync(id);

            _unityOfWork.RepositoryCategory.Delete(category);
            await _unityOfWork.Commit();
        }

        public async Task<IEnumerable<ReadCategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _unityOfWork.RepositoryCategory.GetAllAsync();

            return _mapper.Map<IEnumerable<ReadCategoryDto>>(categories);
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
                //Lançar exception de Id da Categoria diferente do id vindo do Header
            }
            else if (await _unityOfWork.RepositoryCategory.GetByIdAsync(id) != null)
            {
                var category = _mapper.Map<Category>(c);
                _unityOfWork.RepositoryCategory.Update(category);
                await _unityOfWork.Commit();
            }
        }

        private async Task ValidateAsync(CreateOrUpdateCategoryDto dto)
        {
            var validator = new CategoryValidation();
            var result = await validator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                //Lançar exception caso n seja valido 
            }
        }
    }
}
