# Projekt "Budżet domowy"
## Projekt na zaliczenie, Politechnika Białostocka

Stworzona aplikacja ma za zadanie ułatwić planowanie wydatków i rozporządzanie finansami.

Niezalogowany użytkownik może zarejestrować się w serwisie podając email, hasło, imię, nazwisko, numer telefonu. Następnie otrzymuje na podany email link aktywacyjny do swojego konta.

Niezalogowany użytkownik ma również możliwość zresetowania hasła w sposób bezpieczny, wymagany jest dostęp do podanego konta mailowego.

Zalogowany użytkownik może tworzyć budżety. Budżet ma swoją nazwę, którą użytkownik może w dowolnym momencie edytować. Każdy budżet składa się z wielu planów. Użytkownik może według swoich potrzeb dodawać, usuwać, zmieniać plany swoich wydatków i przychodów. Podsumowanie każdego budżetu znajduje się na dole strony.

Użytkownicy są "sterylni", żadne wpisy dostępne dla jednego użytkownika nie są dostępne dla drugiego.

Dodatkowo, użytkownik ma możliwość wygenerowania pliku PDF będącego podsumowaniem wybranego budżetu.

##
# Wykorzystane biblioteki, technologie:

- Microsoft.EntityFrameworkCore
- Microsoft.AspNet.Identity
- Microsoft.AspNetCore.Authorization
- SendGrid - obsługa wiadomości email
- html2canvas, jsPDF - generowanie PDF

##
# Instalacja, konfiguracja

W przypadku korzystania ze środowiska Visual Studio, nie jest wymagana konfiguracja projektu. Jedyne działanie wymagane do wykonania, to aktualizacja baz danych i zastosowanie migracji.

W innym przypadku, należy mieć zainstalowany MS SQL serwer, ręczne wygenerowanie migracji i ustawienie odpowiedniej wartości "ConnectionStrings" w pliku *appsetings.json* w projekcie.