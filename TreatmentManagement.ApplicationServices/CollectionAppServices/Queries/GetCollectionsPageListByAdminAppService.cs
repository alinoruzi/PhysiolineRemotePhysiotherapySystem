using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.CollectionAppServices.Queries
{
	public class GetCollectionsPageListByAdminAppService : IGetCollectionsPageListByAdminAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetCollectionsPageListByAdminAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<List<GetCollectionListItemByAdminDto>> Run(int pageNumber,
			int pageSize, CancellationToken cancellationToken)
			=> (await _unitOfWork.CollectionRepository
					.GetPageAsync(pageNumber, pageSize, cancellationToken))
				.Select(CollectionMapper.MapToAdminItem).ToList();
	}
}
