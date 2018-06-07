using Aster.System.Data;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aster.Core.Services.Test {
    public class TestRepository<T> where T : BaseEntity {

        private IList<T> _mockData;



        public TestRepository(IList<T> mockData) {
            _mockData = mockData;
        }

        public Mock<IRepositoryAsync<T>> GetMockRepository() {
            var _mockRepo = new Mock<IRepositoryAsync<T>>();


            /**
             * setup Mock Repository methods */

            //List
            _mockRepo
                .Setup(x => x.List)
                .Returns(_mockData.AsQueryable());

            //ListNoTracking
            _mockRepo
                .Setup(x => x.ListNoTracking)
                .Returns(_mockData.AsQueryable());


            //DeleteAsync
            _mockRepo
                .Setup(x => x.DeleteAsync(It.IsAny<T>()))
                .Returns(async (T entity) => {
                    _mockData.Remove(entity);
                    await Task.Delay(1);
                });


            //DeleteAsync
            _mockRepo
                .Setup(x => x.DeleteAsync(It.IsAny<IEnumerable<T>>()))
                .Returns(async (IEnumerable<T> entities) => {
                    foreach(var entity in entities)
                        _mockData.Remove(entity);
                    await Task.Delay(1);
                });


            //GetByIdAsync
            _mockRepo
                .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .Returns(async (object id) => {
                    var a = _mockData.Where(c => c.Id == (int)id).SingleOrDefault();
                    return await Task.FromResult(a);
                });


            //InsertAsync
            _mockRepo
                .Setup(x => x.InsertAsync(It.IsAny<T>()))
                .Returns(async (T entity) => {
                    _mockData.Add(entity);
                    return await Task.FromResult(entity);
                });
            _mockRepo
                .Setup(x => x.InsertAsync(It.IsAny<IEnumerable<T>>()))
                .Returns(async (IEnumerable<T> entities) => {
                    foreach(var entity in entities)
                        _mockData.Add(entity);
                    return await Task.FromResult(entities);
                });


            _mockRepo
                .Setup(x => x.UpdateAsync(It.IsAny<T>()))
                .Returns(async (T entity) => {
                    var a = _mockData
                        .Where(x => x.Id == entity.Id)
                        .SingleOrDefault();
                    if(a != null) {
                        _mockData.Remove(a);
                        _mockData.Add(entity);
                    }
                    await Task.Delay(1);
                });

            _mockRepo
                .Setup(x => x.UpdateAsync(It.IsAny<IEnumerable<T>>()))
                .Returns(async (IEnumerable<T> entities) => {
                    var l = _mockData
                        .Where(x => 
                            entities.Any(y => y.Id == x.Id));                    
                    foreach(var a in l)
                        _mockData.Remove(a);
                    foreach(var entity in entities)
                        _mockData.Add(entity);                    
                    await Task.Delay(1);
                });

            return _mockRepo;
        }


    }
}