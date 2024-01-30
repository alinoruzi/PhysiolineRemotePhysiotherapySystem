using AccountManagement.Domain.Repositories;

namespace AccountManagement.Infrastructure.EntityFrameworkCore.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AmContext _context;


		private IAdminRepository _adminRepository;


		private IClientRepository _clientRepository;


		private IExpertRepository _expertRepository;


		private ISpecializedTitleRepository _specializedTitleRepository;

		private IUserRepository _userRepository;
		public UnitOfWork(AmContext context)
		{
			_context = context;
		}

		public IUserRepository UserRepository
			=> _userRepository = _userRepository ?? new UserRepository(_context);

		public IAdminRepository AdminRepository
			=> _adminRepository = _adminRepository ?? new AdminRepository(_context);

		public IExpertRepository ExpertRepository
			=> _expertRepository = _expertRepository ?? new ExpertRepository(_context);

		public IClientRepository ClientRepository
			=> _clientRepository = _clientRepository ?? new ClientRepository(_context);

		public ISpecializedTitleRepository SpecializedTitleRepository
			=> _specializedTitleRepository = _specializedTitleRepository ?? new SpecializedTitleRepository(_context);


		public async Task<int> CommitAsync(CancellationToken cancellationToken)
			=> await _context.SaveChangesAsync(cancellationToken);

		public void Dispose()
			=> _context.Dispose();
	}

}
