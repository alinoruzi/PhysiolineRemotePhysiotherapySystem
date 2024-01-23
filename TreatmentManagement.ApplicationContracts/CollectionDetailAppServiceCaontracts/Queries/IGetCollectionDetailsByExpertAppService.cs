using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.Queries
{
	public interface IGetCollectionDetailsByExpertAppService
	{
		Task<List<GetCollectionDetailItemDto>> Run(long collectionId,
			long userId, CancellationToken cancellationToken);
	}
}
