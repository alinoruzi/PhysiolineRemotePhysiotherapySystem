using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Queries
{
	public interface IGetCollectionByClientAppService
	{
		Task<ValueResult<GetCollectionByClientDto>> Run(long id,
			CancellationToken cancellationToken);
	}
}
