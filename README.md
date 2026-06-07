# Stok ve Satış Yönetim Sistemi

Bilgisayar çevre ekipmanları için geliştirilmiş masaüstü stok ve satış takip uygulaması. C# / Windows Forms ile yazılmıştır; kurulum gerektirmeyen gömülü SQLite veritabanı kullanır.

---

## Özellikler

| Modül | Yapılabilecekler |
|---|---|
| **Ürünler** | Listeleme, ekleme, güncelleme |
| **Müşteriler** | Listeleme |
| **Satış** | Müşteri + ürün + adet seçerek satış oluşturma; stok otomatik düşer |
| **Raporlar** | Düşük stok uyarısı, en çok satılan 10 ürün |

---

## Son Kullanıcı — Kurulum ve Çalıştırma

### Gereksinimler

- **Windows 10 / 11**
- **.NET Framework 4.8** — Windows 10/11'de çoğunlukla yüklü gelir.
  Kurulu değilse: [Microsoft .NET Framework 4.8](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48)

> SQL Server, SQL Express veya başka herhangi bir veritabanı kurulumu **gerekmez**. Uygulama `inventory.db` adlı bir SQLite dosyasını kendi klasöründe otomatik oluşturur.

### Adımlar

1. **Releases** sekmesinden son sürümü indirin.
2. ZIP içindeki tüm dosyaları bir klasöre çıkarın (`SQLite.Interop.dll` ve `System.Data.SQLite.dll` ile birlikte).
3. `InventorySalesSystem.exe` dosyasını çalıştırın.
4. İlk açılışta `inventory.db` otomatik oluşturulur.

> **Dikkat:** `inventory.db` dosyasını silmek tüm verileri kalıcı olarak siler. Düzenli yedek almanız önerilir.

---

## Geliştirici — Projeyi Kurmak ve Çalıştırmak

### Gereksinimler

| Araç | Minimum Sürüm |
|---|---|
| .NET SDK | 6.0+ |
| .NET Framework | 4.8 |
| Visual Studio | 2019+ (isteğe bağlı) |
| Git | herhangi |

### Repoyu Klonlayın

```bash
git clone https://github.com/KULLANICI_ADI/stok-satis-yonetim-sistemi.git
cd stok-satis-yonetim-sistemi
```

### Derleyin ve Çalıştırın

```bash
dotnet build
dotnet run
```

Ya da `InventorySalesSystem.sln` dosyasını Visual Studio ile açıp **F5** ile başlatabilirsiniz.

> `dotnet run` komutu uygulamayı `bin/Debug/net48/` altında çalıştırır. `inventory.db` bu klasörde oluşturulur.

---

## Proje Yapısı

```
stok-satis-yonetim-sistemi/
│
├── Data/
│   ├── SqlConnectionFactory.cs     # SQLiteConnection üreten fabrika sınıfı
│   └── DatabaseInitializer.cs      # İlk açılışta tabloları ve kategorileri oluşturur
│
├── Models/
│   ├── Product.cs                  # Ürün modeli
│   ├── Customer.cs                 # Müşteri modeli
│   ├── Sale.cs                     # Satış başlık modeli
│   ├── SaleItem.cs                 # Satış kalem modeli (LineTotal hesaplar)
│   ├── Category.cs                 # Kategori modeli
│   └── TopProductReport.cs         # Rapor çıktı modeli
│
├── Repositories/
│   ├── ProductRepository.cs        # Ürün CRUD + stok sorgular
│   ├── CustomerRepository.cs       # Müşteri CRUD
│   └── SaleRepository.cs           # Satış + kalem INSERT; stok güncellemesi
│                                   # aynı transaction içinde atomik
│
├── Services/
│   ├── InventoryService.cs         # Ürün iş kuralları ve doğrulama
│   ├── CustomerService.cs          # Müşteri iş kuralları
│   ├── SalesService.cs             # Satış oluşturma; stok yeterliliği kontrolü
│   └── ReportService.cs            # Rapor çağrıları
│
├── Database/
│   ├── schema.sql                  # Eski SQL Server şeması (referans amaçlı)
│   ├── update_products.sql         # Örnek ürün verileri
│   └── update_customers.sql        # Örnek müşteri verileri
│
├── MainForm.cs                     # Ana form — tüm sekme UI'ları
├── MainForm.Designer.cs            # Visual Studio tarafından üretilir
├── Program.cs                      # Giriş noktası; DB init burada çağrılır
├── App.config                      # Uygulama yapılandırması
└── InventorySalesSystem.csproj     # Proje dosyası
```

---

## Mimari

Uygulama üç katmanlı bir yapıya sahiptir:

```
UI (MainForm)
    │
    ▼
Services          ← İş kuralları ve doğrulama
    │
    ▼
Repositories      ← SQL sorguları (ADO.NET / SQLite)
    │
    ▼
SQLite (.db)      ← inventory.db — runtime'da oluşur
```

- **UI → Service:** Form, doğrudan repository'e erişmez; her zaman service katmanından geçer.
- **Service → Repository:** İş kuralı geçildikten sonra veri katmanı tetiklenir.
- **Transaction:** Satış oluşturma ve stok düşme işlemi tek bir SQLite transaction'ı içinde gerçekleşir; birinden biri başarısız olursa ikisi de geri alınır.

---

## Veritabanı Şeması

```
Categories          Products
──────────          ────────────────────────
Id (PK)             Id (PK)
Name                Name
                    CategoryId (FK → Categories)
                    UnitPrice
                    StockQuantity
                    MinimumStockQuantity

Customers           Sales                   SaleItems
─────────           ─────────────────────   ──────────────────────
Id (PK)             Id (PK)                 Id (PK)
FullName            CustomerId (FK)         SaleId (FK → Sales)
Phone               SaleDate (auto)         ProductId (FK → Products)
Email               TotalAmount             Quantity
                                            UnitPrice
```

Tüm tablolar `DatabaseInitializer.cs` tarafından **`CREATE TABLE IF NOT EXISTS`** ile oluşturulur; elle script çalıştırmak gerekmez.

---

## Teknolojiler

| Teknoloji | Kullanım amacı |
|---|---|
| C# / .NET Framework 4.8 | Uygulama dili ve çalışma ortamı |
| Windows Forms | Masaüstü arayüz |
| SQLite (`System.Data.SQLite`) | Gömülü, kurulum gerektirmeyen veritabanı |
| ADO.NET | Ham SQL sorguları, parametre yönetimi |

---

## Katkıda Bulunmak

1. Repoyu fork'layın.
2. Yeni bir dal açın: `git checkout -b ozellik/ozellik-adi`
3. Değişikliklerinizi commit'leyin: `git commit -m "Açıklayıcı mesaj"`
4. Branch'inizi push'layın: `git push origin ozellik/ozellik-adi`
5. Pull Request açın.

---

## Lisans

Bu proje [MIT Lisansı](LICENSE) ile lisanslanmıştır.
