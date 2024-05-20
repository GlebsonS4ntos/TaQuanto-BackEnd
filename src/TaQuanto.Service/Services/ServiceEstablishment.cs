using AutoMapper;
using TaQuanto.Domain.Entities;
using TaQuanto.Domain.Exception;
using TaQuanto.Infraestructure.Interface;
using TaQuanto.Service.Dtos.Establishment;
using TaQuanto.Service.Interfaces;
using TaQuanto.Service.Validations;

namespace TaQuanto.Service.Services
{
    public class ServiceEstablishment : IServiceEstablishment
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;
        private readonly IServicePhoto _photo;

        public ServiceEstablishment(IUnityOfWork unityOfWork, IMapper mapper, IServicePhoto photo)
        {
            _unityOfWork = unityOfWork;
            _mapper = mapper;
            _photo = photo;
        }

        public async Task<ReadEstablishmentDto> CreateEstablishmentAsync(CreateOrUpdateEstablishmentDto e)
        {
            await ValidateAsync(e);

            var establishment = _mapper.Map<Establishment>(e);
            var resultAddImage = await _photo.AddPhoto(e.Image);
            establishment.ImageUrl = resultAddImage.SecureUrl.AbsoluteUri;
            establishment.ImagePublicId = resultAddImage.PublicId;

            var establishmetAdd = await _unityOfWork.RepositoryEstablishment.CreatAsync(establishment);
            await _unityOfWork.Commit();

            return _mapper.Map<ReadEstablishmentDto>(establishmetAdd);
        }

        public async Task DeleteEstablishmentAsync(Guid id)
        {
            try
            {
                var establishment = await _unityOfWork.RepositoryEstablishment.GetByIdAsync(id);
                await _photo.DeletePhoto(establishment.ImagePublicId);
                _unityOfWork.RepositoryEstablishment.Delete(establishment);

                await _unityOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw new RestrictDeleteException("Não é possivel Deletar, pois existe itens associados ao mesmo.");
            }
        }

        public async Task<IEnumerable<ReadEstablishmentDto>> GetAllEstablishmentAsync()
        {
            var establishments = await _unityOfWork.RepositoryEstablishment.GetAllAsync();

            return _mapper.Map<IEnumerable<ReadEstablishmentDto>>(establishments);
        }

        public async Task<ReadEstablishmentDto> GetEstablishmentByIdAsync(Guid id)
        {
            var establishment = await _unityOfWork.RepositoryEstablishment.GetByIdAsync(id);

            return _mapper.Map<ReadEstablishmentDto>(establishment);
        }

        public async Task UpdateEstablishmentAsync(CreateOrUpdateEstablishmentDto e, Guid id)
        {
            await ValidateAsync(e);

            if(e.Id != id)
            {
                throw new HeaderIdException("Verifique se o Id do Estabelecimento não é o mesmo do Estabelecimento passado.");
            }

            var establisment = _mapper.Map<Establishment>(e);
            var establishmentCurrent = await _unityOfWork.RepositoryEstablishment.GetByIdAsync(id);

            establishmentCurrent.CityId = establisment.CityId;
            establishmentCurrent.Address = establisment.Address;
            establishmentCurrent.IsDraft = establisment.IsDraft;
            establishmentCurrent.Name = establisment.Name;

            if (e.Image != null)
            {
                var resultDelete = await _photo.DeletePhoto(establishmentCurrent.ImagePublicId);
                var result = await _photo.AddPhoto(e.Image);

                establishmentCurrent.ImageUrl = result.SecureUrl.AbsoluteUri;
                establishmentCurrent.ImagePublicId = result.PublicId;
            }

            _unityOfWork.RepositoryEstablishment.Update(establishmentCurrent);
            await _unityOfWork.Commit();
        }

        private async Task ValidateAsync(CreateOrUpdateEstablishmentDto dto)
        {
            var validator = new EstablishmentValidation();
            var result = await validator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors.Select(e => e.ErrorMessage).ToList());
            }
        }
    }
}
