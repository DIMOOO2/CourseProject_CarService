![logo](https://avatars.mds.yandex.net/get-altay/11383855/2a0000018caaf719893628ac76ef28c89b16/diploma)

# Описание программного модуля

## Содержание
- [Введение](#введение)
- [Требования к системе]()
- [Технические требования]()
- [Заключение](#заключение)

## Введение
Приложение учета и наличия автозапчастей в автомастерской предназначена для облегчения манипулирования данными склада предприятия. Эта система будет использоваться для получения полной информации о детали, формировании отчетов за определенный промежуток времени, оформление заказа необходимых товаров. Целью этого проекта является разработка и реализация приложения, который будет интегрироваться с другими системами компании и обеспечивать безопасность и защиту данных.

## Требования к системе

### Функциональные требования
-	приложение должно поддерживать поиск запчастей внутри программы с использованием поискового запроса пользователя;
-	приложение должно поддерживать работу на ПК с операционной системой Windows.
-	приложение должно иметь возможность интеграции с другими системами компании для обмена данными.

### Производительные требования 
-	приложение должно обеспечивать быстрый доступ к информации о запасных частях и их наличии.
-	приложение должно поддерживать работу с большим объемом данных.
-	приложение должно обеспечивать высокую скорость обработки запросов и обновления данных.

### Требования к безопасности
- приложение должно обеспечивать авторизацию пользователей и контроль доступа к информации о запасных частях.
-	приложение должно иметь возможность аудита действий пользователей для обеспечения безопасности и защиты от утечки данных.
-	приложение должно обеспечивать защиту от вредоносных программ и взлома, а также иметь механизмы резервного копирования и восстановления данных.

## Технические требования

### Архитектура системы
-	десктопное приложение для учета и наличия автозапчастей должно иметь клиент-серверную архитектуру.
-	серверная часть должна быть реализована на языке программирования **C#** для обработки запросов и управления базой данных.
-	клиентская часть должна быть разработана для работы на платформах **Windows**, обеспечивая удобный интерфейс для пользователей.

### Используемые технологии
-	для хранения данных десктопного приложения должно использоваться реляционное хранилище данных, такое как **SQL Server**, для эффективного учета и наличия автозапчастей.
-	для шифрования данных необходимо применять алгоритм **AES-256**, чтобы обеспечить безопасность информации о запчастях и пользователях.
-	для обеспечения безопасности и защиты от несанкционированного доступа должны использоваться следующие технологии: **SSL/TLS** для защищенной передачи данных, двухфакторная аутентификация для повышения уровня безопасности учетных записей, хеширование паролей для защиты пользовательской информации и использование токенов с ограниченным временем жизни для контроля доступа к системе.

### Требования к производительности
-	среднее время ответа системы не должно превышать **1** секунды при запросах на добавление, обновление и получение информации о запчастях.
-	максимальное время ответа системы не должно превышать **5** секунд при выполнении запросов на добавление, обновление и получение данных о запчастях.
-	приложение должно обеспечивать масштабируемость и горизонтальное масштабирование для работы с большим объемом данных и количеством пользователей, а также для эффективного управления инвентаризацией запчастей в автомастерской.

## Заключение
Десктопное приложение для учета и наличия автозапчастей в автомастерской является важным инструментом для управления инвентаризацией и производительностью мастерской. Разработка такой системы должна учитывать требования точности и надежности данных, эффективности использования, а также использовать современные технологии и подходы к программированию. Выбор правильного подхода к проектированию и реализации десктопного приложения, такого как использование шаблонов проектирования и многопоточности, позволит создать эффективную и надежную систему учета запчастей в автомастерской. Помимо этого, важно учесть особенности работы мастерской и потребности пользователей в удобном и интуитивно понятном интерфейсе для максимальной эффективности использования приложения.
