using Physioline.Framework.Application.ResultModels;
using TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.DTOs;

namespace TreatmentManagement.ApplicationContracts.CollectionAppServicesContracts.Queries
{
	public interface IGetCollectionByAdminAppService
	{
		Task<ValueResult<GetCollectionByAdminDto>> Run(long id,
			CancellationToken cancellationToken);
	}
}
