using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Queries
{
	public interface IGetCollectionByExpertAppService
	{
		Task<ValueResult<GetCollectionByExpertDto>> Run(long id,
			long userId, CancellationToken cancellationToken);
	}
}
