using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using System.Linq;
using Simurgh.DAL.Model;
using Simurgh.DAL;
using Microsoft.Extensions.Logging;

namespace Simurgh.XUnitTest
{
    public class DBTests : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly ILogger _logger;

        public DBTests(ITestOutputHelper output, ILogger logger)
        {
            this._output = output;
            _logger = logger;
            //DAL.Constants.DBFilePath = "DataSource=:memory";
        }

        public void Dispose()
        {

        }

        [Fact]
        public async void Test1()
        {


            var clientRepository = new DAL.ClientRepository(_logger, true);
            var newCient = new Client()
            {
                ClientName = "Lorikeet Family",
                ClientDescription = "This family is living a remote place in Sistan and Balouchestan province of Iran.",
                GoogleMapAddress = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d4391842.965895599!2d58.789367776186324!3d28.22707811997935!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3ee7373a9afe43d5%3A0xe92f486ae9df1408!2sSistan+and+Baluchestan+Province%2C+Iran!5e1!3m2!1sen!2sus!4v1560554452394!5m2!1sen!2sus",
            };
            await clientRepository.AddAsync(newCient);

            var repository = new DAL.ProjectRepository(_logger, true);

            var newProject = new Project()
            {
                Name = "Buiding Bathroom",
                MoneyRaised = 1700,
                ClientId = newCient.Id,
                Pictures = new List<Picture> {
                    new Picture(){Type=PictureType.Image, Url = "images/project1/location00.jpeg"},
                    new Picture(){Type=PictureType.Image, Url = "images/project1/location01.jpeg"},
                    new Picture(){Type=PictureType.Image, Url = "images/project1/location02.jpeg"},
                    new Picture(){Type=PictureType.Image, Url = "images/project1/location03.jpeg"},
                    new Picture(){Type=PictureType.Image, Url = "images/project1/location04.jpeg"},
                    new Picture(){Type=PictureType.Image, Url = "images/project1/location05.jpeg"},
                    new Picture(){Type=PictureType.Image, Url = "images/project1/location06.jpeg"},
                    new Picture(){Type=PictureType.Image, Url = "images/project1/location07.jpeg"},
                }
            };

            await repository.AddAsync(newProject);

            var projects = repository.GetAll().Count();
        }



        [Fact]
        public async void SubscriberRepositoryTest()
        {
            var repo = new SubscriberRepository(_logger, false);

            var firstSubscriber = new Subscriber("Amir", "mahfoozi@gmail.com");
            await repo.AddAsync(firstSubscriber);
            var id = firstSubscriber.Id;
            repo.Detach(firstSubscriber);

            var secondSubscriber = new Subscriber("Amir", "mahfoozi@gmail.com");

            await Assert.ThrowsAsync<Microsoft.EntityFrameworkCore.DbUpdateException>(
                        () => repo.AddAsync(secondSubscriber)
                    );

            Assert.Throws<Microsoft.EntityFrameworkCore.DbUpdateException>(
                    () => {
                       repo.Add(secondSubscriber);
                   });

            //we should reconnect to see the deleted objects
            repo = new SubscriberRepository(_logger, false);

            repo.Delete(id);

            var count = repo.GetAll().Count();

            Assert.Equal(0, count);
        }

    }
}
