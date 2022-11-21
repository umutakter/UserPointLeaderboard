# UserPointLeaderboard
Asp.Net Core 6 and MongoDB Project

## README

Projeyi geliştirirken MongoDB.Driver paketinden yararlıldı. Database ayarları Models klasörü içerisinde bulunan UserPointDatabaseSettings.cs içerisinde oluşturuldu. Gerekli Database işlemleri için UserPointRepository.cs class’ı hazırlanarak yararlanıldı. UserPointRepository.cs ve UserPointDatabaseSettings.cs için ayrı Interfaceler yaratıldı. Proje gereksinimlerini karşılayacak şekilde API Controllerları geliştirildi. Api’lerde yararlanmak üzere HelperFunctions.cs içerisinde yardımcı fonksiyonlar hazırlandı.

#### "api/UserPoint/LeaderBoardAllTime"
Request almıyor. Tüm kullanıcıların, toplam puanları hesaplanıyor. Response olarak ödül alan kullanıcıların bilgileri döndürülür.

#### "api/UserPoint/LeaderBoardSelectedMonth"
Request olarak hesaplanılması istenilen ayın integer cinsinden karşılığını alır (1-12 arası). Tüm kullanıcıların, seçilen aya ait onaylanmış puanları hesaplanır. Response olarak tüm kullanıcılar ve ay içerisindeki toplam puanları döner. Örnek request: "2"

#### "api/UserPoint/SelectedUserPoints"
Request olarak istenilen kullanıcının string cinsinden Id bilgisi gönderilir. Response olarak kullanıcının aldığı tüm puan bilgileri döner. Örnek request: "628d71143a264713dbebe31d"

#### "api/UserPoint/LeaderBoardSelectedUser"
Request olarak istenilen kullanıcının string cinsinden Id bilgisi gönderilir. Seçili kullanıcının puan bilgisi, sıralaması ve ödülü hesaplanır. Hesaplanan kullanıcı bilgileri request olarak döner. Örnek request: "628d71143a264713dbebe31d"
