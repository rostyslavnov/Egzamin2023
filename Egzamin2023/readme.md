# Zadanie 1
Zdefiniuj klasę modelu notatki składającej się z właściwości:
- `Title`: tytułu (od 3 do 20 znaków), który jest też identyfikatorem
- `Content`: treści (od 10 do 2000 znaków)
- `Deadline`: daty ważności (do którego dnia i godziny powinna być notatka udostępniana) 
Utwórz widok formularza dla tego modelu z uwzględnieniem komunikatów błędów dla każdego pola. Pole
`Content` w formularzy musi być elementem typu `textarea`! Etykiety pól formularz to odpowiednio:
- `Tytuł`
- `Treść`
- `Data ważności`
Zdefiniuj w klasie `ExamController` metodę `Create`, która zwraca utworzony widok formularza.

# Zadanie 2
Utwórz metodę akcji `Index` w kontrolerze `Exam`, która zwaraca widok `Index`. Na razie umieść w widoku tylko tytuł: 
"Lista notatek". 
Zdefiniuj drugą metodę `Create` w kontrolerze `Exam`, która odbiera dane z formularz notatki wysłane metodą `post`.
Dane notatki są poprawne, jeśli pola spełniają podane warunki w zadaniu 1 oraz data ważności jest późniejsza
o co najmniej godzinę od bieżącej daty.
Jeśli data ważności jest niepoprawna to zgłoś błąd daty ważności poniższą metodą:
`ModelState.AddModelError(<nazwa-pola-daty-ważnosci>, "Czas ważności musi być o godzinę późniejszy od bieżącego czasu!");`
W miejscu <nazwa-pola-daty-ważnosci> wpisz nazwę pola w modelu.
Datę bieżącą pobierz z serwisu `DefaultDateProvider`. Aby z niego skorzystać dodaj odpowiedni wiersz
rejestrujący klasę `DefaultDateProvider` jaki implementację interfejsu `IDateProvider`.
Jeśli notatka jest poprawna to przejdź do widoku `Index`.

# Zadanie  3
Zdefiniuj klasę serwisu o nazwie `NoteService` z trzema metodami:
- `Add()`: dodanie notatki, która zapisuje notatkę w pamięci np. dodaje do listy, słownika
- `GelAll()`: pobranie listy ważnych notatek, która zwraca tylko te notatki, których data ważności jest mniejsza od bieżącej daty
- `GetById()`: zwrócenie jednej, ważnej notatki na podstawie jego tytułu 
Serwis powinien mieć zależność do serwisu  `IDateProvider` i z tego serwisu pobierać czas bieżący. 
Zarejestruj serwis w kontenerze IOC dobierając odpowiedni zasięg. 
Uzupełnij kontroler `Exam` o zapisywanie poprawnej notatki do utworzonego serwisu.

# Zadanie 4
Uzupełnij metodę `Index` oraz widok przez nią zwracany, aby wyświetlała listę tylko ważnych notatek w postaci
listy typu `<ul>`. Każdy element listy typu `<li>` powinien zawierać tylko tytuł notatki w postaci linku, który kieruje do
metody akcji `Details` w kontrolerze `Exam`.
Przykład linku kierującego do treści notatki o tytule "Sprawdzian"
`/Exam/Details/Sprawdzian`.

# Zadanie 5
Zdefiniuj metodę `Details`, aby zwracała widok z tytułem notatki w elemencie `<h1>`, pod tytułe treść notatki
w elemencie `<div>`, który zawiera paragrafy (w elemencie `<p>`). Każdy paragraf zawiera jeden wiersz tekstu treści notatki.
Na dole umieść link powrotu do listy notatek.






