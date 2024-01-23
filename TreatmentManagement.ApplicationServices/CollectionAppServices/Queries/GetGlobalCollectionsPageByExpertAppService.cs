using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Queries;
using TreatmentManagement.ApplicationServices.Mappers;
using TreatmentManagement.Domain.Repositories;

namespace TreatmentManagement.ApplicationServices.CollectionAppServices.Queries
{
	public class GetGlobalCollectionsPageByExpertAppService : IGetGlobalCollectionsPageByExpertAppService
	{
		private readonly IUnitOfWork _unitOfWork;
		public GetGlobalCollectionsPageByExpertAppService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<List<GetCollectionListItemByExpertDto>> Run(int pageNumber,
			int pageSize, CancellationToken cancellationToken)
			=> (await _unitOfWork.CollectionRepository
					.GetPageAsync(c=>c.IsGlobal,pageNumber, pageSize, cancellationToken))
				.Select(CollectionMapper.MapToExpertItem).ToList();
	}
}
