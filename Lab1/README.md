# Модель свадьбы

## 1. Основные классы

### Wedding
**Описание**: Класс, представляющий свадьбу. Управляет процессами и состояниями.
- **Свойства**:
  - `WeddingPhase` – текущее состояние свадьбы.
  - `Groom` – жених.
  - `Fiancee` – невеста.
  - `Ceremony` – церемония.
  - `Banquet` – банкет.
  - `WeddingPlace` – место проведения свадьбы.
  - `Guests` – список гостей.
  - `SharedBudget` – общий бюджет свадьбы.
  - `IsConcluded` – завершена ли свадьба.
- **Методы**:
  - `ChangeState()` – меняет текущее состояние свадьбы.

### WeddingPhase (абстрактный класс)
**Описание**: Базовый класс для состояний свадьбы.
- **Методы**:
  - `GetToTheNextPhase(Wedding wedding)` – переходит в следующее состояние.

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

### LostGameState
**Описание**: Проигрыш, если бюджет заканчивается до завершения свадьбы.

## 3. Атрибуты свадьбы

### WeddingAttribute
**Описание**: Базовый класс для свадебных атрибутов (костюмов, колец).
- **Свойства**:
  - `Price` – цена.
  - `Brand` – бренд.
  - `Prestige` – престижность (Cheap, Normal, Premium).

### Ring
**Описание**: Класс обручального кольца.
- **Наследует**: `WeddingAttribute`.

### Suit
**Описание**: Класс свадебного костюма.
- **Наследует**: `WeddingAttribute`.

## 4. Гости и еда

### Guest
**Описание**: Класс гостя.
- **Свойства**:
  - `Name` – имя гостя.
  - `HungerLevel` – уровень голода.

### Dish
**Описание**: Блюдо свадебного меню.
- **Свойства**:
  - `Name` – название.
  - `Price` – цена.
  - `FoodPower` – уровень насыщения.

## 5. Магазины и выбор

### RingStore
**Описание**: Магазин обручальных колец.
- **Свойства**:
  - `Rings` – список доступных колец.
- **Методы**:
  - `AssignTheRings(Wedding wedding, int ringIndex)` – назначает кольца жениху и невесте.

### SuitStore
**Описание**: Магазин свадебных костюмов.
- **Свойства**:
  - `MenSuits`, `WomenSuits` – списки мужских и женских костюмов.
- **Методы**:
  - `AssignTheSuitToTheGroom(Wedding wedding, int suitIndex)` – назначает костюм жениху.
  - `AssignTheSuitToTheFiancee(Wedding wedding, int suitIndex)` – назначает платье невесте.

### WeddingMenu
**Описание**: Меню свадебного банкета.
- **Свойства**:
  - `Dishes` – список доступных блюд.
- **Методы**:
  - `AssignTheDishes(Wedding wedding, int[] indexesOfDishes)` – назначает блюда свадебному банкету.

## 6. Проведение свадьбы

### Ceremony
**Описание**: Проведение свадебной церемонии.
- **Методы**:
  - `DeclareHusbandAndWife(Groom groom, Fiancee fiancee)` – женит пару.

### Banquet
**Описание**: Проведение банкета.
- **Свойства**:
  - `Dishes` – блюда банкета.

## 7. Подведение итогов

### ResultSummarizer
**Описание**: Подсчитывает очки по итогам свадьбы.
- **Методы**:
  - `Summarize(Wedding wedding) : int` – подсчитывает финальные очки.
  - `CalculateDeadEnd(Wedding wedding, List<uint> prices) : bool` – проверяет, не закончился ли бюджет.

## 8. Система управления состояниями

### JsonStateManager
**Описание**: Управляет сохранением и загрузкой состояний свадьбы.
- **Методы**:
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
  - `DisplaySummarazation(int amountOfPoints)` – отображение финального результата.

---


