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
            // Haz�rl�k
            var service = new AppSettingsReaderProvider(null);

            // Servisi �al��t�r
            var result = service.GetAll();

            // Sonucu kontrol et
            result.ShouldNotBeNull();
            result.ShouldBeEmpty();
        }
    }
}