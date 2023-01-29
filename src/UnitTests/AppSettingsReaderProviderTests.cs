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
            // Hazýrlýk
            var service = new AppSettingsReaderProvider(null);

            // Servisi Çalýþtýr
            var result = service.GetAll();

            // Sonucu kontrol et
            result.ShouldNotBeNull();
            result.ShouldBeEmpty();
        }


        [Fact]
        public void GetAll_WhenServiceReturnEmpty_ThenReturnEmptyArray()
        {
            // Hazýrlýk
            var configurationManagerServiceMock = new Mock<IConfigurationManagerService>();
            var service = new AppSettingsReaderProvider(configurationManagerServiceMock.Object);

            // Servisi Çalýþtýr
            var result = service.GetAll();

            // Sonucu kontrol et
            result.ShouldNotBeNull();
            result.ShouldBeEmpty();
        }



        [Fact]
        public void GetAll_WhenServiceReturnList_ThenReturnSameList()
        {
            // Hazýrlýk
            var list = new List<KeyValuePair<string, string>>() { 
                new KeyValuePair<string, string>("demo1", "Demo1"),
                new KeyValuePair<string, string>("demo2", "Demo2"),
                new KeyValuePair<string, string>("demo3", "Demo3"),
            };
            var configurationManagerServiceMock = new Mock<IConfigurationManagerService>();

            configurationManagerServiceMock.Setup(m => m.GetAllAppSettings())
                .Returns(list);
                //.Throws(new NullReferenceException()); // Eðer metodun exception dönmesi gerekiyor ise bu yöntemle exception döndürülebilir.

            var service = new AppSettingsReaderProvider(configurationManagerServiceMock.Object);

            // Servisi Çalýþtýr
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