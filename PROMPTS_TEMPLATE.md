# LLM Kullanım Dokümantasyonu

> Bu dosyayı case boyunca kullandığınız LLM (ChatGPT, Claude, Copilot vb.) etkileşimlerini belgelemek için kullanın.
> Dürüst ve detaylı dokümantasyon beklenmektedir.

## Özet

| Bilgi                          | Değer           |
| ------------------------------ | --------------- |
| Toplam prompt sayısı           | 15+             |
| Kullanılan araçlar             | Gemini          |
| En çok yardım alınan konular   | [Dökümantasyon] |
| Tahmini LLM ile kazanılan süre | 12+ saat        |

---

## Prompt 1: [Ludu Arts Dökümanına Göre Script içerikleri veya İsimlendirmeler Uygun Mu Yazıldı?]

**Araç:** [Gemini]
**Tarih/Saat:** 2026-01-31 13:45

**Prompt:**

```
Attığın Naming_Convention_Kilavuzu.md dökümanını inceledim. Durum şöyle:Animasyonların Unity içindeki (Animator penceresindeki) State isimleri veya Parametre isimleri (Open, Close gibi) için özel bir kural belirtilmemiş.ANCAK, Project penceresinde duran Animasyon Dosyaları (Asset) için çok net kurallar var. Puan kaybetmemek için bunlara dikkat etmelisin:1. Dosya İsimlendirme Kuralları (Zorunlu)Project klasöründe duran dosyalar şu şekilde olmalı:Dosya TürüPrefix (Ön Ek)KuralÖrnekAnimator ControllerAC_AC_ + PascalCaseAC_DoorAnimation ClipA_A_ + PascalCaseA_DoorOpen, A_DoorClose

```

**Alınan Cevap (Özet):**

```
Animasyon clip ve animasyon controller isimlerinde düzeltmeler yapılması gerektiğini öğrendim dökümantasyonda
```

**Nasıl Kullandım:**

- [ ] Direkt kullandım (değişiklik yapmadan)
- [x] Adapte ettim (değişiklikler yaparak)
- [ ] Reddettim (kullanmadım)

**Açıklama:**

İsimlendirmek konusunda epey yardımcı oldu

**Yapılan Değişiklikler (adapte ettiyseniz):**

> [LLM cevabını nasıl değiştirdiğinizi açıklayın]

---

## Prompt 2: [Hash tavsiyesi ve ne işe yaradığı]

**Araç:** [Gemini]
**Tarih/Saat:** 2026-01-31 15:30

**Prompt:**

```
peki bu hash nedir açıklar mısın?

```

Tabii ki, bu çok yerinde bir soru. Bir Unity Developer için "string" yerine "hash" kullanmak, "kodum sadece çalışmıyor, aynı zamanda performanslı çalışıyor" demenin en kısa yoludur.

Hash Nedir? (En Basit Anlatımla)
Unity'nin Animator sisteminde oluşturduğun parametreler (örneğin "Open", "IsRunning" gibi kelimeler), aslında Unity'nin arka planında benzersiz tam sayılara (integer) dönüştürülür.

Sen m_Animator.SetTrigger("Open") yazdığında Unity her seferinde şunları yapar:

"Open" kelimesini alır.

Bu kelimenin sayısal karşılığını (hash) hesaplar.

Animator içindeki listede bu sayısal karşılığı arar.

Bulunca tetikler.

Eğer biz bu hesaplamayı en başta bir kere yapıp bir değişkende saklarsak (Animator.StringToHash), Unity'ye her seferinde kelimeyi hesaplatmak zorunda kalmayız. Doğrudan "3 numaralı tetiği çek" demiş oluruz.

Neden Hash Kullanmalısın? (Ludu Arts Neden Buna Bakar?)
Hız (Performance): Bilgisayarlar sayıları (int), metinlerden (string) çok daha hızlı karşılaştırır. Binlerce kez çalışan bir oyunda bu küçük farklar birleşerek performansı etkiler.

Çöp Toplayıcı (Garbage Collector): Sürekli string parametre göndermek, bellekte (RAM) gereksiz yük oluşturabilir. Hash (int) kullanmak belleği yormaz.

Profesyonellik: Bir intern adayının StringToHash kullanması, Unity'nin iç çalışma mantığını (internal mechanics) bildiğini ve sadece "tutorial" kopyalamadığını kanıtlar.

**Alınan Cevap (Özet):**

```
Hash ile animasyon isimlendirmenin Field kısmında belirlendiği ve optimize bir yol olduğunu öğrendim
```

**Nasıl Kullandım:**

- [x] Direkt kullandım
- [ ] Adapte ettim
- [ ] Reddettim

**Açıklama:**

Yeni bilgiler ve en iyi optimze yolu öğrendim.

---

## Prompt 3: ...

**Araç:** [Gemini]
**Tarih/Saat:** 2026-01-31 13:45

**Prompt:**

```
Dökümantasyon için Unity Project sayfasından Screen Shot alarak.

bu fotodakileri



Assets/

├── [LuduArts_Intern_Case]/

│   ├── Scripts/

│   │   ├── Runtime/

│   │   │   ├── Audio/

│   │   │   │   ├── IInteractable.cs

│   │   │   │   └── ...

│   │   │   ├── Interactables/

│   │   │   │   ├── Door.cs

│   │   │   │   └── ...

│   │   │   ├── Player/

│   │   │   │   └── ...

│   │   │   └── UI/

│   │   │       └── ...

│   │   └── Editor/

│   ├── ScriptableObjects/

│   ├── Prefabs/

│   ├── Materials/

│   └── Scenes/

│       └── TestScene.unity

├── Docs/

│   ├── CSharp_Coding_Conventions.md

│   ├── Naming_Convention_Kilavuzu.md

│   └── Prefab_Asset_Kurallari.md

├── README.md

├── PROMPTS.md

└── .gitignore



bunun gibi yazar mısın?

```

**Alınan Cevap (Özet):**

```
Readme kısmında hiyeraşide mevcuttur.
```

**Nasıl Kullandım:**

- [x] Direkt kullandım (değişiklik yapmadan)
- [ ] Adapte ettim (değişiklikler yaparak)
- [ ] Reddettim (kullanmadım)

**Açıklama:**

Dökümantasyonu hızlıca bitirmem konusunda yardımcı oldu.

**Yapılan Değişiklikler (adapte ettiyseniz):**

> [LLM cevabını nasıl değiştirdiğinizi açıklayın]

## Prompt 4: ...

**Araç:** [Gemini]
**Tarih/Saat:** 2026-01-31 16:45

**Prompt:**

```
tamamdır şimdi benim için bir github push yazısı istiyorum yaptığım şeyler



*envanter sistemi ekledim

*q ile eşya bırakıyoruz

*etkileşime geçince envantere ekleniyor

*scroll eşyalar arası geçiş

*kapı kilidi açma (kapı ile anahtar idsi uyuşuyorsa)

*lever eklendi

*itemler için scriptable object yapıldı

*lever ile etkileşime geçildikçe inspectordan atanan eventlere göre değişiklik yaşanıyor



**Alınan Cevap **

Vay canına, 12 saatlik sürenin içinde gerçekten dev bir ilerleme kaydetmişsin! Envanter sistemi, eşya düşürme, ID tabanlı kapı kilidi ve event tabanlı Lever sistemi... Bunlar bir "Intern" projesi için oldukça güçlü özellikler.

Ludu Arts dökümanlarında "Tek commit kabul edilmez" ve "Commit history önemli" maddeleri vardı. Eğer bu saydıklarının hepsini tek bir seferde push'layacaksan, mesajın çok açıklayıcı ve profesyonel olmalı.

İşte Ludu Arts standartlarına (Conventional Commits) uygun, teknik derinliği gösteren GitHub commit mesajın:

GitHub Commit Mesajı
Subject (Başlık): feat: implement inventory system, key-door logic, and event-based lever

Body (Açıklama):

Plaintext

Integrated a modular inventory system and expanded the interaction framework with new types and logic. 

Key updates:
- Inventory System: Added support for picking up items, dropping items (Q key), and cycling through slots via Mouse Scroll.
- ScriptableObjects: Implemented SO-based item definitions for scalable item management.
- Key-Door Logic: Developed an ID-matching system between KeyData and Door components to handle locked states.
- Lever System: Added a toggle-based Lever interactable that triggers customizable UnityEvents assigned via Inspector.
- Code Standards: All classes follow m_ prefix naming conventions, use XML documentation for public APIs, and utilize hashed strings for animation triggers.
⚠️ Unutmaman Gereken 3 Kritik Şey
PROMPTS.md'yi Güncelle: Bu saydığın özellikleri yaparken (özellikle scroll sistemi veya UnityEvents mantığı için) AI kullandıysan, bunları PROMPTS.md dosyasına hemen işle. Unutursan doğrudan elenebilirsin.

Namespace ve Klasör Yapısı: Dosyaların dökümanda istenen Interactables, Core, Player ve UI klasörlerine doğru dağıldığından emin ol.

Silent Bypass: Kodunda hata fırlatabilecek yerlerde (mesela envanterde yer yoksa veya anahtar ID'si null ise) Debug.Log veya Debug.LogError kullandığından emin ol. Dökümanda "Silent bypass yapılmamalı" uyarısı vardı.

Bonus Puan İçin Küçük Bir Tavsiye
Eğer vaktin kalırsa, Lever ile bir kapıyı açtığında veya bir eşya aldığında küçük bir Sound Effect (SFX) tetikleme noktası (// TODO: Add SFX here veya boş bir AudioSource) bırak. Bonus puan tablosunda "Sound effects integration points" maddesi vardı, buradan bedava puan alabilirsin.

Şu an teslimat için ne kadar vaktin kaldı? İstersen en kritik dosya olan README.md içeriği için de bir taslak oluşturabiliriz, çünkü projenin "vitrini" orası olacak!

```

**Alınan Cevap (Özet):**

```
feat: implement inventory system, key-door logic, and event-based lever


Integrated a modular inventory system and expanded the interaction framework with new types and logic. 

Key updates:
- Inventory System: Added support for picking up items, dropping items (Q key), and cycling through slots via Mouse Scroll.
- ScriptableObjects: Implemented SO-based item definitions for scalable item management.
- Key-Door Logic: Developed an ID-matching system between KeyData and Door components to handle locked states.
- Lever System: Added a toggle-based Lever interactable that triggers customizable UnityEvents assigned via Inspector.
- Code Standards: All classes follow m_ prefix naming conventions, use XML documentation for public APIs, and utilize hashed strings for animation triggers.
```

**Nasıl Kullandım:**

- [ ] Direkt kullandım (değişiklik yapmadan)
- [x] Adapte ettim (değişiklikler yaparak)
- [ ] Reddettim (kullanmadım)

**Açıklama:**

Dökümantasyonu hızlıca bitirmem konusunda yardımcı oldu.

**Yapılan Değişiklikler (adapte ettiyseniz):**

> [LLM cevabını nasıl değiştirdiğinizi açıklayın]

---

## Genel Değerlendirme

### LLM'in En Çok Yardımcı Olduğu Alanlar

1. Dökümantasyon
2. Değişken ve dosya isimlendirmelerde kontrol etmesi.
3. Alınan hataların nerelerden kaynaklandığı.

### LLM'in Yetersiz Kaldığı Alanlar

1. Konuyu çok kısa bir şekikde açıklayabilirken çok uzun ve gereksiz kalabalıklara yol açması.
2. [Alan 2]

### LLM Kullanımı Hakkında Düşüncelerim

> [Bu case boyunca LLM kullanarak neler öğrendiniz?
> Bir çok konuda bana yardımcı oldu. İsimlendirmelerde baya bilgi edindim.
>
> > LLM'siz ne kadar sürede bitirebilirdiniz?
> > Yaklaşık 1 hafta belkide.
> > Gelecekte LLM'i nasıl daha etkili kullanabilirsiniz?]
> > LLM daha fazla bilgi öğrenme ve zorlu yaratıcı mekaniklerde destek sağlayarak yaratıcılığımızı arttıracağını düşünüyorum.

---

## Notlar

- Her önemli LLM etkileşimini kaydedin
- Copy-paste değil, anlayarak kullandığınızı gösterin
- LLM'in hatalı cevap verdiği durumları da belirtin
- Dürüst olun - LLM kullanımı teşvik edilmektedir

---

_Bu şablon Ludu Arts Unity Intern Case için hazırlanmıştır._
