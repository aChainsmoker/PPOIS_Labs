# Модель свадьбы

## 1. Основные классы

### Wedding
**Описание**: Класс, представляющий свадьбу. Управляет процессами и состояниями.
- **Поля**:
  - `_currentCurrentWeddingPhase` – текущее состояние свадьбы.
  - `_groom` – жених.
  - `_fiancee` – невеста.
  - `_ceremony` – церемония.
  - `_banquet` – банкет.
  - `_weddingPlace` – место проведения свадьбы.
  - `_guests` – список гостей.
  - `_sharedBudget` – общий бюджет свадьбы.
  - `_isConcluded` – завершена ли свадьба.
- **Методы**:
  - `ChangeState()` – меняет текущее состояние свадьбы.

### WeddingPhase (абстрактный класс)
**Описание**: Базовый класс для состояний свадьбы.
- **Методы**:
  - `GetToTheNextPhase(Wedding wedding)` – переходит в следующее состояние.

  ### PhaseRerouter
**Описание**: Класс переключающий состояния свадьбы.
- **Поля**:
 - `_weddingPhases` – массив состояний свадьбы.
- **Методы**:
  - `AssignThePhase(Wedding wedding, int index)` – Выбирает следующее состояние в зависимости от ввода пользователя.


## 2. Состояния свадьбы

### CreatingNewlywedState
**Описание**: Начальное состояние свадьбы. Ввод имен жениха и невесты, установка бюджета.

### ChoosingWeddingPlaceState
**Описание**: Выбор места свадьбы и его покупка.

### ChoosingFianceeDressState
**Описание**: Покупка свадебного платья невесты.

### ChoosingGroomDressState
**Описание**: Покупка свадебного костюма жениха.

### ChoosingRingState
**Описание**: Покупка обручальных колец.

### ChoosingWeddingMenuState
**Описание**: Выбор свадебного меню.

### GuestInvitationState
**Описание**: Приглашение гостей на свадьбу.

### CeremonyState
**Описание**: Проведение свадебной церемонии.

### PhotoSessionState
**Описание**: Проведение фотосессии.

### BanquetState
**Описание**: Проведение банкета.

### SummarizeState
**Описание**: Подведение итогов, начисление очков.

### ChoosingWeddingPhaseState
**Описание**: Состояние, в котором пользователю даётся выбор состояния.

## 3. Атрибуты свадьбы

### WeddingAttribute
**Описание**: Базовый класс для свадебных атрибутов (костюмов, колец).
- **Поля**:
  - `_price` – цена.
  - `_brand` – бренд.
  - `_attributePrestige` – престижность (Cheap, Normal, Premium).

### Ring
**Описание**: Класс обручального кольца.
- **Наследует**: `WeddingAttribute`.

### Suit
**Описание**: Класс свадебного костюма.
- **Наследует**: `WeddingAttribute`.

## 4. Гости и еда

### Guest
**Описание**: Класс гостя.
- **Поля**:
  - `_name` – имя гостя.
  - `_hungerLevel` – уровень голода.

### Dish
**Описание**: Блюдо свадебного меню.
- **Поля**:
  - `_name` – название.
  - `_price` – цена.
  - `_foodPower` – уровень насыщения.

## 5. Магазины и выбор

### RingStore
**Описание**: Магазин обручальных колец.
- **Поля**:
  - `_rings` – список доступных колец.
  - `_brands` – список доступных брендов.
- **Методы**:
  - `AssignTheRings(Wedding wedding, int ringIndex)` – назначает кольца жениху и невесте.

### SuitStore
**Описание**: Магазин свадебных костюмов.
- **Поля**:
  - `_menSuits`, `_womenSuits` – списки мужских и женских костюмов.
  - `_menBrands`, `_womenBrands` – списки мужских и женских брендов.
- **Методы**:
  - `AssignTheSuitToTheGroom(Wedding wedding, int suitIndex)` – назначает костюм жениху.
  - `AssignTheSuitToTheFiancee(Wedding wedding, int suitIndex)` – назначает платье невесте.

### WeddingMenu
**Описание**: Меню свадебного банкета.
- **Поля**:
  - `_dishes` – список доступных блюд.
- **Методы**:
  - `AssignTheDishes(Wedding wedding, int[] indexesOfDishes)` – назначает блюда свадебному банкету.

## 6. Проведение свадьбы

### Ceremony
**Описание**: Проведение свадебной церемонии.
- **Поля**:
  - `_guests` – список гостей.
- **Методы**:
  - `DeclareHusbandAndWife(Groom groom, Fiancee fiancee)` – провозглашает пару мужем и женой.

### Banquet
**Описание**: Проведение банкета.
- **Поля**:
  - `_dishes` – блюда банкета.
  - `_guests` – гости банкета.

## 7. Подведение итогов

### ResultSummarizer
**Описание**: Подсчитывает очки по итогам свадьбы.
- **Методы**:
  - `Summarize(Wedding wedding) : int` – подсчитывает финальные очки.

## 8. Система управления состояниями

### JsonStateManager
**Описание**: Управляет сохранением и загрузкой состояний свадьбы.
- **Методы**:
  - `GetFilePath(string fileName) : string` – Формирует путь к файлам сохранения.
  - `SaveState<T>(T state, string fileName)` – сохраняет состояние в JSON-файл.
  - `LoadState<T>(string fileName) : T` – загружает состояние из JSON-файла.
  - `DeleteState(string fileName)` – удаляет сохранённое состояние.

## 9. Система ввода/вывода

### IOSystem
**Описание**: Отвечает за взаимодействие с пользователем.
- **Методы**:
  - `ChooseNameForNewlyweds(out string husbandName, out string wifeName)` – ввод имён молодожёнов.
  - `ChooseWeddingPlace(WeddingMap weddingMap, out int indexOfPlace)` – выбор места свадьбы.
  - `ChooseWeddingDressForFiancee(SuitStore suitStore, out int indexOfFianceeDress)` – выбор платья.
  - `ChooseWeddingDressForGroom(SuitStore suitStore, out int indexOfGroomDress)` – выбор костюма.
  - `ChooseWeddingRing(RingStore ringStore, out int indexOfRing)` – выбор кольца.
  - `ChooseWeddingMenu(WeddingMenu weddingMenu, out int[] indexesOfWeddingMenu)` – выбор меню.
  - `InviteGuests(out string[] names)` – приглашение гостей.
  - `DeclareMarriage(Groom groom, Fiancee fiancee)` – объявление брака.
  - `DeclareBanquet()` – объпроведениеявление банкета.
  - `DeclarePhotoSession()` – проведение фотосессии.
  - `DisplaySummarazation(int amountOfPoints)` – отображение финального результата.
  - `DisplayWeddingDishes(List<Dish> weddingDishes)` – отображение доступных блюд.
  - `DisplayWeddingDresses(List<Suit> weddingDresses)` – отображение доступных свадебных нарядов.
  - `DisplayWeddingRings(List<Ring> weddingRings)` – отображение доступных обручальных колец.
  - `DisplayWeddingPlaces(List<WeddingPlace> weddingPlaces)` – отображение доступных мест дял проведения свадьбы.
  - `GetPrestigeString(AttributePrestige attributePrestige) : string` – получение престижности атрибута в формате строки.
  - `GetPrestigeFromString(string attributePrestigeString) : AttributePrestige` – получение престижности артрибута из строки.
  - `PrintBudget(int budget)` – отображение оставшегося бюджета.
  - `GetTheWeddingStateString(WeddingPhase weddingPhase) : string` – получение состояния свадьбы в формате строки.
  - `GetTheWeddingPhaseFromString(string weddingPhaseString) : WeddingPhase` – получение состояния свадьбы из строки.
  - `TakeTheNumericInput : int` – извлечение корректного ввода.
  - `CheckIfTheIndexInTheArrayBounds<T>(int index, List<T> array) : bool` – проверка на соответсвие введённого индекса размера массива.
  - `TakeTheCorrectNumericIndex<T>(List<T> array) : int` – извлечение корректного числового ввода.
  - `DisplayMainMenu()` – - вывод меню выбора состояния.
  - `DisplayCeremonyRequirements()` – вывод требований для проведения церемонии.
  - `DisplayPhotoSessionRequirements()` – вывод требований для проведения фото сессии.
  - `DisplayBanquetRequirements()` – вывод требований для проведения банкета.
  - `DisplaySummarizationRequirements()` – – вывод требований для подведения итогов.
  - `DisplayBuyingAttributesRequirements()` – – вывод требований для покупки свадебной атрибутики.
  - `DisplayFinalResult(Wedding wedding)` – вывод итогов.
  - `ShowAlreadyMarriedStatus()` – вывод статуса проведённой церемонии.
  - `ShowAlreadyHeldBanquetStatus()` вывод статуса проведённого банкета.
---


