using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Yuya.Net.Configuration.MSNetFrameworkConfiguration;

namespace UnitTests
{

    public class AppSettingsReaderProviderTests
    {
        [Fact]
        public void GetAll_WhenServiceIsNull_ThenReturnEmptyArray()
        {
            // Haz�rl�k
            var service = new AppSettingsReaderProvider(null);

            // Servisi �al��t�r
            var result = service.GetAll();

            // Sonucu kontrol et
            result.ShouldNotBeNull();
            result.ShouldBeEmpty();
        }


        [Fact]
        public void GetAll_WhenServiceReturnEmpty_ThenReturnEmptyArray()
        {
            // Haz�rl�k
            var configurationManagerServiceMock = new Mock<IConfigurationManagerService>();
            var service = new AppSettingsReaderProvider(configurationManagerServiceMock.Object);

            // Servisi �al��t�r
            var result = service.GetAll();

            // Sonucu kontrol et
            result.ShouldNotBeNull();
            result.ShouldBeEmpty();
        }



        [Fact]
        public void GetAll_WhenServiceReturnList_ThenReturnSameList()
        {
            // Haz�rl�k
            var list = new List<KeyValuePair<string, string>>() { 
                new KeyValuePair<string, string>("demo1", "Demo1"),
                new KeyValuePair<string, string>("demo2", "Demo2"),
                new KeyValuePair<string, string>("demo3", "Demo3"),
            };
            var configurationManagerServiceMock = new Mock<IConfigurationManagerService>();

            configurationManagerServiceMock.Setup(m => m.GetAllAppSettings())
                .Returns(list);
                //.Throws(new NullReferenceException()); // E�er metodun exception d�nmesi gerekiyor ise bu y�ntemle exception d�nd�r�lebilir.

            var service = new AppSettingsReaderProvider(configurationManagerServiceMock.Object);

            // Servisi �al��t�r
            var result = service.GetAll();

            // Sonucu kontrol et
            result.ShouldNotBeNull();
            result.ShouldNotBeEmpty();
            result.ShouldBe(list);
            result.ShouldBeOfType<List<KeyValuePair<string, string>>>();
            result.Count().ShouldBe(list.Count);
        }
    }
}