using KONE.DataAccess.KONE.Abstract;
using KONE.DataAccess.KONE.Repositories;

namespace KONE.DataAccess.KONE.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Repositories
        private readonly KONEContext _KONEContext;
        private readonly IProductRepository _productRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly IProvinceRepository _provinceRepository;
        private readonly ICoordinatesRepository _coordinatesRepository;
        private readonly IVillageRepository _villageRepository;
        private readonly ICurrentCardsRepository _currentCardsRepository;
        private readonly ICurrentCardLandNameRepository _currentCardLandNameRepository;
        private readonly ICurrentCardAddressMappingsRepository _currentCardAddressMappingsRepository;
        private readonly ICountriesRepository _countriesRepository;
        private readonly IAddressesRepository _addressesRepository;
        private readonly IPermissionRepository _permissionRepository;
        private readonly IUserLoginHistoryRepository _userLoginHistoryRepository;
        private readonly IActivityLogRepository _activityLogRepository;
        private readonly IFirmRepository _firmRepository;
        private readonly IUserFirmMappingRepository _userFirmMappingRepository;
        #endregion

        #region Ctor
        public UnitOfWork(KONEContext context)
        {
            _KONEContext = context;
        }



        #endregion

        #region Implementations
        public IProductRepository Product => _productRepository ?? new ProductRepository(_KONEContext);

        public IDistrictRepository District => _districtRepository ?? new DistrictRepository(_KONEContext);

        public IProvinceRepository Province => _provinceRepository ?? new ProvinceRepository(_KONEContext);

        public ICoordinatesRepository Coordinates => _coordinatesRepository ?? new CoordinatesRepository(_KONEContext);

        public IVillageRepository Village => _villageRepository ?? new VillageRepository(_KONEContext);

        public ICountriesRepository Countries => _countriesRepository ?? new CountriesRepository(_KONEContext);

        public ICurrentCardsRepository CurrentCard => _currentCardsRepository ?? new CurrentCardRepository(_KONEContext);

        public ICurrentCardAddressMappingsRepository CurrentCardAddressMapping => _currentCardAddressMappingsRepository ?? new CurrentCardAddressMappingsRepository(_KONEContext);

        public IAddressesRepository Addresses => _addressesRepository ?? new AddressesRepository(_KONEContext);

        public ICurrentCardLandNameRepository CurrentCardLandName => _currentCardLandNameRepository ?? new CurrentCardLandNameRepository(_KONEContext);
        public IPermissionRepository Permission => _permissionRepository ?? new PermissionRepository(_KONEContext);

        public IUserLoginHistoryRepository UserLoginHistory => _userLoginHistoryRepository ?? new UserLoginHistoryRepository(_KONEContext);

        public IActivityLogRepository ActivityLog => _activityLogRepository ?? new ActivityLogRepository(_KONEContext);

        public IFirmRepository Firm => _firmRepository ?? new FirmRepository(_KONEContext);

        public IUserFirmMappingRepository UserFirmMapping => _userFirmMappingRepository ?? new UserFirmMappingRepository(_KONEContext);
        public void Dispose()
        {
            _KONEContext.Dispose();
        }
        #endregion

        #region Methods
        public async ValueTask DisposeAsync()
        {
            await _KONEContext.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _KONEContext.SaveChangesAsync();
        }
        #endregion
    }
}
