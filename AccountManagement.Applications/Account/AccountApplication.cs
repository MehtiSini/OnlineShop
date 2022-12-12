using AccountManagement.Contracts.Account;
using AcoountManagement.Domain.AccountAgg;
using MyFramework.Tools;

namespace AccountManagement.Applications.Account
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IFileUploader _fileUploader;
        private readonly IPasswordHasher _passwordHasher;

        public AccountApplication(IAccountRepository accountRepository, IFileUploader fileUploader, IPasswordHasher passwordHasher)
        {
            _accountRepository = accountRepository;
            _fileUploader = fileUploader;
            _passwordHasher = passwordHasher;
        }

        public OperationResult ChangePassword(ChangePassword cmd)
        {
            var operation = new OperationResult();

            var Account = _accountRepository.GetById(cmd.Id);

            if (Account == null)
            {
                return operation.Failed(OperationMessage.NotFound);
            }

            if (cmd.Password != cmd.RePassword)
            {
                return operation.Failed(OperationMessage.PasswordNotMatch);
            }

            var Password = _passwordHasher.Hash(cmd.Password);

            Account.ChangePassword(Password);

            _accountRepository.Save();

            return operation.Succeed();

        }

        public OperationResult Create(CreateAccount cmd)
        {
            var operation = new OperationResult();


            if (_accountRepository.Exist(x => x.Username == cmd.Username || x.Mobile == cmd.Mobile))
            {
                return operation.Failed(OperationMessage.DuplicateRecord);
            }

            var Password = _passwordHasher.Hash(cmd.Password);

            var Profile = _fileUploader.Upload(cmd.ProfilePhoto, "ProfilePhotos");

            var Account = new AccountModel(cmd.FullName, cmd.Username, Password, cmd.Mobile, Profile, cmd.RoleId);

            _accountRepository.Create(Account);

            _accountRepository.Save();

            return operation.Succeed();
        }

        public OperationResult Edit(EditAccount cmd)
        {
            var operation = new OperationResult();

            var Account = _accountRepository.GetById(cmd.Id);

            if (_accountRepository.Exist(x =>( x.Username == cmd.Username || x.Mobile == cmd.Mobile) && x.Id != cmd.Id))
            {
                return operation.Failed(OperationMessage.DuplicateRecord);
            }

            if (Account == null)
            {
                return operation.Failed(OperationMessage.NotFound);
            }

            var Profile = _fileUploader.Upload(cmd.ProfilePhoto, "ProfilePhotos");

            Account.Edit(cmd.FullName, cmd.Username, cmd.Mobile, Profile, cmd.RoleId);

            _accountRepository.Save();

            return operation.Succeed();
        }

        public EditAccount GetDetails(long Id)
        {
            return _accountRepository.GetDetails(Id);
        }

        public List<AccountViewModel> Search(AccountSearchModel Search)
        {
            return _accountRepository.Search(Search);
        }
    }
}
