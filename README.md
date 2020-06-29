# WFiIS-BD2-PROJ

Projekt studencki w ramach przedmiotu Bazy Danych 2:

`
Przetwarzanie danych typu CLOB. Opracować API i jego implementację do przetwarzania danych typu CLOB. W ramach projektu można wykorzystać typ danych CLOB oraz technologię wyszukiwania pełnotekstowe FTS. Opracowane API powinno umożliwić zapis i usunięcie wybranego dokumentu oraz wyszukanie określonej informacji w dokumentach umieszczonych w repozytorium.
`

W repozytorium znajdują się 2 projekty oraz folder ze skryptami. Skrypty zostały juz "odpalone" na serwerze podanym w standardowej konfiguracji (plik `appsettings.Development.json` - tam mozna podmienic ConnectionString w razie potrzeby).

Projekt został napsiany w formie REST API - wykaz endpointow:

* GET: `/product/` - lista wszystkichy produktow

* GET: `/product/{id}` - zwraca produkt o zadanym parametrze `{id}`

* GET: `/product/search/{query}` - zwraca liste produktow zawierajacych `{query}` w polu opis produktu. Korzysta z FTS.

* POST: `/product` - Dodaje nowy produkt. Payload mozna znalezc w pliku `ProductSearchTests/AddRemoveTest.cs` (linie 20-25).

* DELETE: `/product/{id}` - usuwa produkt o zadanym parametrze `{id}`

## Testing

Testy aplikacji znajduja sie w projekcie `ProductSearchTests`.

W celu ich uruchomienia nalezy najpierw skonfigurowac i uruchomic projekt `ProductSearch`, a nastepnie testy z projektu `ProductSeardchTests`.

## Development

Aby zainstalowac aplikacje z wlasnym SQL Serverem nalezy:

* Włączyć SQL Server WRAZ Z USŁUGA FULL-TEXT-SEARCH (WAŻNE!)

* Odpalic skrypt z folderu `BD2-scripts` zgodnie z kolejnoscia!

* Zmienic ConnectionString w pliku `appsettings.Development.json`

* Uruchomic projekt `ProductSearch`