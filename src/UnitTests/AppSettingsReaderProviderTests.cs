using Shouldly;
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
    }
}