using Aster.Core.Domain.Contractors;
using Aster.Core.Services.Contractors;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Aster.Core.Services.Test {
    public class ContractorServiceTests {
        private readonly IContractorService contractorService;
        public ContractorServiceTests() {
            var _mock = new TestRepository<Contractor>(MockData).GetMockRepository();



            contractorService = new ContractorService(_mock.Object, null);
        }


        [Fact]
        public void TestGetAllContractors() {
            Task.Run(async () => {
                var contractors = await contractorService.GetContractors();
                Assert.True(contractors.Count > 0);
            }).GetAwaiter().GetResult();
        }

        [Fact]
        public void TestSingleContractor() {
            Task.Run(async () => {
                var contractor = await contractorService.GetContractorByReference("test");
                Assert.NotNull(contractor);
            }).GetAwaiter().GetResult();
        }

        [Fact]
        public void TestInsert() {
            Task.Run(async () => {
                var a = new Contractor {
                    ReferenceNo = "REF",
                    Forename = "First names",
                    Surname = "Lastname"
                };
                var b = await contractorService.InsertContrator(a);

                Assert.Equal(a, b);
                var c = contractorService.GetContractorByReference("REFA");
                Assert.NotNull(c);
            }).GetAwaiter().GetResult();
        }

        private List<Contractor> MockData {
            get {
                return new List<Contractor>() {
                    new Contractor { ReferenceNo ="test", Forename = "Mini", Surname = "Alpha", ContactNo = "12345678" },
                    new Contractor { ReferenceNo ="AlphaBETA", Forename = "Alpha", Surname = "Beta", ContactNo = "87654321" }
                };
            }
        }

        private List<ContractorBankAccount> MockAccounts {
            get {
                return new List<ContractorBankAccount>() {
                    new ContractorBankAccount{ Id = 1, ContractorId = 1, AccountNumber = "asldkjf", BankAddress = ""}
                };
            }
        }
    }
}