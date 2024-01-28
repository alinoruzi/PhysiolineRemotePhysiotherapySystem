using TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.CollectionDetailAppServiceCaontracts.Queries
{
	public interface IGetCollectionDetailsByClientAppService
	{
		Task<List<GetCollectionDetailItemDto>> Run(long collectionId,
			CancellationToken cancellationToken);
	}

}
