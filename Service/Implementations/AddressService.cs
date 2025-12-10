
using AutoMapper;
using CinemaProject.Entities;
using CinemaProject.Models.AddressModels;
using CinemaProject.Repository.Interfaces; 
using CinemaProject.Service.Interfaces; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaProject.Service.Implementations
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressService(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<ResponseAddress?> CreateAddressAsync(CreateAddressModel addressModel)
        {
           
            var addressEntity = _mapper.Map<Address>(addressModel); 
            
            // 2. Veritabanı İşlemi
            await _addressRepository.AddAsync(addressEntity);
            await _addressRepository.SaveChangesAsync();
            
            // 3. Entity'den Response Model'e Dönüşüm ve Dönüş
            return _mapper.Map<ResponseAddress>(addressEntity);
        }

        public async Task<IEnumerable<ResponseAddress>> GetAllAddressesAsync()
        {
            var addresses = await _addressRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ResponseAddress>>(addresses);
        }

        public async Task<ResponseAddress?> GetAddressByIdAsync(int id)
        {
            var address = await _addressRepository.GetByIdAsync(id);
            if (address == null) return null;
            return _mapper.Map<ResponseAddress>(address);
        }
        
        public async Task<ResponseAddress?> UpdateAddressAsync(int id, UpdateAddressModel addressModel)
        {
            var addressToUpdate = await _addressRepository.GetByIdAsync(id);
            if (addressToUpdate == null) return null;

            // Model'deki null olmayan alanları entity üzerine map'le
            _mapper.Map(addressModel, addressToUpdate); 
            await _addressRepository.SaveChangesAsync();
            
            return _mapper.Map<ResponseAddress>(addressToUpdate);
        }
        
        public async Task<bool> DeleteAddressAsync(int id)
        {
            var addressToDelete = await _addressRepository.GetByIdAsync(id);
            if (addressToDelete == null) return false;

            _addressRepository.Delete(addressToDelete);
            await _addressRepository.SaveChangesAsync();
            return true;
        }
    }
}